import { Injectable } from '@angular/core';
import { IApiError } from '../Interfaces/IApiError';

@Injectable({
    providedIn: 'root'
})
export class ErrorHandlerService {

    async handleApiError(response: Response): Promise<IApiError> {
        let errorData: any;

        try {
            const contentType = response.headers.get('content-type');

            if (contentType && contentType.includes('application/json')) {
                errorData = await response.json();
            } else {
                errorData = await response.text();
            }
        } catch (e) {
            errorData = null;
        }

        if (errorData && typeof errorData === 'object') {
            return {
                statusCode: errorData.statusCode || errorData.status || response.status,
                message: errorData.message || errorData.title || this.getDefaultMessage(response.status),
                details: errorData.details || errorData.detail,
                errors: errorData.errors,
                timestamp: errorData.timestamp || new Date().toISOString(),
                path: errorData.path || response.url
            };
        }

        if (typeof errorData === 'string') {
            return {
                statusCode: response.status,
                message: errorData || this.getDefaultMessage(response.status),
                timestamp: new Date().toISOString(),
                path: response.url
            };
        }

        return {
            statusCode: response.status,
            message: this.getDefaultMessage(response.status),
            timestamp: new Date().toISOString(),
            path: response.url
        };
    }

    private getDefaultMessage(statusCode: number): string {
        switch (statusCode) {
            case 400:
                return 'Requisição inválida. Verifique os dados enviados.';
            case 401:
                return 'Não autorizado. Faça login para continuar.';
            case 403:
                return 'Acesso negado. Você não tem permissão para esta ação.';
            case 404:
                return 'Recurso não encontrado.';
            case 409:
                return 'Conflito. O recurso já existe ou há um conflito de dados.';
            case 422:
                return 'Dados inválidos. Verifique os campos do formulário.';
            case 500:
                return 'Erro interno do servidor. Tente novamente mais tarde.';
            case 503:
                return 'Serviço temporariamente indisponível.';
            default:
                return `Erro ${statusCode}. Ocorreu um problema ao processar sua solicitação.`;
        }
    }

    formatValidationErrors(errors?: { [key: string]: string[] }): string {
        if (!errors) return '';

        const errorMessages: string[] = [];
        for (const [field, messages] of Object.entries(errors)) {
            errorMessages.push(`${field}: ${messages.join(', ')}`);
        }

        return errorMessages.join('\n');
    }

    getFullErrorMessage(error: IApiError): string {
        let message = error.message;

        if (error.details) {
            message += `\n\nDetalhes: ${error.details}`;
        }

        if (error.errors) {
            const validationErrors = this.formatValidationErrors(error.errors);
            if (validationErrors) {
                message += `\n\nErros de validação:\n${validationErrors}`;
            }
        }

        return message;
    }
}
