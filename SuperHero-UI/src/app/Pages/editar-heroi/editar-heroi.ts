import { Component, inject, signal, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HeroiService } from '../../Core/Service/heroi.service';
import { SuperpoderService } from '../../Core/Service/superpoder.service';
import { ErrorHandlerService } from '../../Core/Service/error-handler.service';
import { IApiError } from '../../Core/Interfaces/IApiError';

import { Counter } from '../../Components/counter/counter';
import { ErrorDisplay } from '../../Components/error-display/error-display';

@Component({
    selector: 'SH-editar-heroi',
    standalone: true,
    imports: [FormsModule, Counter, ErrorDisplay],
    templateUrl: './editar-heroi.html',
    styleUrl: './editar-heroi.scss'
})
export class EditarHeroi implements OnInit {
    private heroiService = inject(HeroiService);
    private superpoderService = inject(SuperpoderService);
    private errorHandler = inject(ErrorHandlerService);
    private router = inject(Router);
    private route = inject(ActivatedRoute);

    superpoderesResource = this.superpoderService.superpoderesResource;

    heroId!: number;
    nome = signal('');
    nomeHeroi = signal('');
    altura = signal<number | null>(null);
    peso = signal<number | null>(null);
    dataNascimento = signal<string>('');
    selectedSuperpoderes = signal<number[]>([]);

    showError = signal(false);
    errorData = signal<IApiError | null>(null);

    async ngOnInit() {
        const id = this.route.snapshot.paramMap.get('id');
        if (id) {
            this.heroId = +id;
            await this.loadHero(this.heroId);
        }
    }

    async loadHero(id: number) {
        try {
            const hero = await this.heroiService.getHeroById(id);
            this.nome.set(hero.nome);
            this.nomeHeroi.set(hero.nomeHeroi);
            this.altura.set(hero.altura);
            this.peso.set(hero.peso);

            if (hero.dataNascimento) {
                const date = new Date(hero.dataNascimento);
                this.dataNascimento.set(date.toISOString().split('T')[0]);
            }

            if (hero.superpoderes) {
                this.selectedSuperpoderes.set(hero.superpoderes.map(s => s.id as unknown as number));
            }
        } catch (error: any) {
            console.error('Error loading hero', error);

            let apiError: IApiError;

            if (error.statusCode && error.message && typeof error.message === 'string') {
                try {
                    const parsedMessage = JSON.parse(error.message);
                    apiError = {
                        statusCode: parsedMessage.status || error.statusCode || 500,
                        message: parsedMessage.title || 'Erro ao carregar herói',
                        details: parsedMessage.detail,
                        errors: parsedMessage.errors,
                        timestamp: new Date().toISOString()
                    };
                } catch (e) {
                    apiError = error as IApiError;
                }
            } else {
                apiError = {
                    statusCode: error.status || 500,
                    message: error.statusText || 'Erro ao carregar herói',
                    timestamp: new Date().toISOString()
                };
            }

            this.errorData.set(apiError);
            this.showError.set(true);
        }
    }

    async onSubmit() {
        const updatedHero: any = {
            id: this.heroId,
            nome: this.nome(),
            nomeHeroi: this.nomeHeroi(),
            altura: this.altura() ?? 0,
            peso: this.peso() ?? 0,
            dataNascimento: this.dataNascimento() ? new Date(this.dataNascimento()) : undefined,
            superpoderesIds: this.selectedSuperpoderes()
        };

        try {
            await this.heroiService.updateHero(this.heroId, updatedHero);
            this.router.navigate(['/heroi']);
        } catch (error: any) {
            console.error('Erro ao atualizar herói:', error);

            let apiError: IApiError;

            if (error.statusCode && error.message && typeof error.message === 'string') {
                try {
                    const parsedMessage = JSON.parse(error.message);
                    apiError = {
                        statusCode: parsedMessage.status || error.statusCode || 400,
                        message: parsedMessage.title || 'Erro ao atualizar herói',
                        details: parsedMessage.detail,
                        errors: parsedMessage.errors,
                        timestamp: new Date().toISOString()
                    };
                } catch (e) {
                    apiError = error as IApiError;
                }
            } else {
                apiError = {
                    statusCode: error.status || 400,
                    message: error.statusText || 'Erro ao atualizar herói',
                    timestamp: new Date().toISOString()
                };
            }

            this.errorData.set(apiError);
            this.showError.set(true);
        }
    }

    toggleSuperpoder(id: number, event: Event) {
        const isChecked = (event.target as HTMLInputElement).checked;
        const current = this.selectedSuperpoderes();
        if (isChecked) {
            this.selectedSuperpoderes.set([...current, id]);
        } else {
            this.selectedSuperpoderes.set(current.filter(sid => sid !== id));
        }
    }

    isSuperpoderSelected(id: number): boolean {
        return this.selectedSuperpoderes().includes(id);
    }

    onRetryError() {
        this.showError.set(false);
        this.errorData.set(null);
        this.router.navigate(['/heroi']);
    }
}
