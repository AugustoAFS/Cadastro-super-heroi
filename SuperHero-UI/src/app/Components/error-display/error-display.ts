import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'SH-error-display',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './error-display.html',
  styleUrl: './error-display.scss',
})
export class ErrorDisplay {
  @Input() statusCode: number = 0;
  @Input() message: string = 'Unknown Error';
  @Input() details?: string;
  @Input() errors?: { [key: string]: string[] };
  @Output() retry = new EventEmitter<void>();

  showDetails: boolean = false;

  onRetry() {
    this.retry.emit();
  }

  toggleDetails() {
    this.showDetails = !this.showDetails;
  }

  get errorType(): string {
    switch (this.statusCode) {
      case 400: return 'BAD REQUEST';
      case 401: return 'UNAUTHORIZED';
      case 403: return 'FORBIDDEN';
      case 404: return 'NOT FOUND';
      case 409: return 'CONFLICT';
      case 422: return 'UNPROCESSABLE ENTITY';
      case 500: return 'SERVER ERROR';
      case 503: return 'SERVICE UNAVAILABLE';
      default: return 'ERROR';
    }
  }

  get hasAdditionalInfo(): boolean {
    return !!(this.details || this.errors);
  }

  get validationErrors(): string[] {
    if (!this.errors) return [];

    const errorMessages: string[] = [];
    for (const [field, messages] of Object.entries(this.errors)) {
      errorMessages.push(...messages);
    }

    return errorMessages;
  }
}
