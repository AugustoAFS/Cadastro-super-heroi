import { Injectable, inject, resource } from '@angular/core';
import { ISuperpoder } from '../Interfaces/ISuperpoder';
import { ErrorHandlerService } from './error-handler.service';

@Injectable({
    providedIn: 'root'
})
export class SuperpoderService {
    private readonly apiUrl = 'https://localhost:7176/api/Superpoderes';
    private errorHandler = inject(ErrorHandlerService);

    readonly superpoderesResource = resource({
        loader: async () => {
            const response = await fetch(this.apiUrl);
            if (!response.ok) {
                const error = await this.errorHandler.handleApiError(response);
                throw error;
            }
            return (await response.json()) as ISuperpoder[];
        }
    });
}
