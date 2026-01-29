import { Component, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HeroiService } from '../../Core/Service/heroi.service';
import { SuperpoderService } from '../../Core/Service/superpoder.service';
import { ErrorHandlerService } from '../../Core/Service/error-handler.service';
import { IApiError } from '../../Core/Interfaces/IApiError';
import { IHeroi } from '../../Core/Interfaces/IHeroi';

import { Counter } from '../../Components/counter/counter';
import { ErrorDisplay } from '../../Components/error-display/error-display';

@Component({
    selector: 'SH-cadastro-heroi',
    standalone: true,
    imports: [FormsModule, Counter, ErrorDisplay],
    templateUrl: './cadastro-heroi.html',
    styleUrl: './cadastro-heroi.scss'
})
export class CadastroHeroi {
    private heroiService = inject(HeroiService);
    private superpoderService = inject(SuperpoderService);
    private errorHandler = inject(ErrorHandlerService);
    private router = inject(Router);

    superpoderesResource = this.superpoderService.superpoderesResource;

    nome = signal('');
    nomeHeroi = signal('');
    altura = signal<number | null>(0);
    peso = signal<number | null>(0);
    dataNascimento = signal<string>('');
    selectedSuperpoderes = signal<number[]>([]);

    showError = signal(false);
    errorData = signal<IApiError | null>(null);

    async onSubmit() {
        const novoHeroi: any = {
            nome: this.nome(),
            nomeHeroi: this.nomeHeroi(),
            altura: this.altura() || 0,
            peso: this.peso() || 0,
            dataNascimento: this.dataNascimento() ? new Date(this.dataNascimento()) : undefined,
            superpoderesIds: this.selectedSuperpoderes()
        };

        try {
            await this.heroiService.createHero(novoHeroi);
            this.router.navigate(['/heroi']);
        } catch (error: any) {
            console.error('Erro ao criar herói:', error);
            console.log('Tipo do erro:', typeof error);
            console.log('error.message:', error.message);

            let apiError: IApiError;

            if (error.statusCode && error.message && typeof error.message === 'string') {
                try {
                    const parsedMessage = JSON.parse(error.message);
                    apiError = {
                        statusCode: parsedMessage.status || error.statusCode || 400,
                        message: parsedMessage.title || 'Erro ao criar herói',
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
                    message: error.statusText || 'Erro ao criar herói',
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

    onRetryError() {
        this.showError.set(false);
        this.errorData.set(null);
    }
}
