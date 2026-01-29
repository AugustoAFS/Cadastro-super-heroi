export interface IApiError {
    statusCode: number;
    message: string;
    details?: string;
    errors?: { [key: string]: string[] };
    timestamp?: string;
    path?: string;
}

export interface IErrorResponse {
    error: IApiError;
    status: number;
    statusText: string;
}
