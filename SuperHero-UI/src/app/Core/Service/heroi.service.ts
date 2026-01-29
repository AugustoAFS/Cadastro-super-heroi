import { Injectable, inject, resource } from '@angular/core';
import { IHeroi } from '../Interfaces/IHeroi';
import { IApiError } from '../Interfaces/IApiError';
import { ErrorHandlerService } from './error-handler.service';

@Injectable({
    providedIn: 'root'
})
export class HeroiService {
    private readonly apiUrl = 'https://localhost:7176/api/Herois';
    private errorHandler = inject(ErrorHandlerService);

    readonly heroisResource = resource({
        loader: async () => {
            const response = await fetch(this.apiUrl);
            if (!response.ok) {
                const error = await this.errorHandler.handleApiError(response);
                throw error;
            }
            return (await response.json()) as IHeroi[];
        }
    });

    async createHero(heroi: Partial<IHeroi>): Promise<IHeroi> {
        const response = await fetch(this.apiUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(heroi)
        });

        if (!response.ok) {
            const error = await this.errorHandler.handleApiError(response);
            throw error;
        }

        this.heroisResource.reload();
        return await response.json();
    }

    async getHeroById(id: number): Promise<IHeroi> {
        const response = await fetch(`${this.apiUrl}/${id}`);
        if (!response.ok) {
            const error = await this.errorHandler.handleApiError(response);
            throw error;
        }
        return await response.json();
    }

    async updateHero(id: number, heroi: Partial<IHeroi>): Promise<IHeroi> {
        const response = await fetch(`${this.apiUrl}/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(heroi)
        });

        if (!response.ok) {
            const error = await this.errorHandler.handleApiError(response);
            throw error;
        }

        this.heroisResource.reload();
        return await response.json();
    }

    async deleteHero(id: number): Promise<void> {
        const response = await fetch(`${this.apiUrl}/${id}`, {
            method: 'DELETE'
        });

        if (!response.ok) {
            const error = await this.errorHandler.handleApiError(response);
            throw error;
        }

        this.heroisResource.reload();
    }
}
