import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { HeroiService } from '../../Core/Service/heroi.service';
import { SuperpoderService } from '../../Core/Service/superpoder.service';
import { LoaderComponent } from '../../Components/loader/loader';
import { HeroCardComponent } from '../../Components/hero-card/hero-card';
import { ErrorDisplay } from '../../Components/error-display/error-display';
import { IApiError } from '../../Core/Interfaces/IApiError';

@Component({
  selector: 'SH-heroi',
  imports: [CommonModule, LoaderComponent, HeroCardComponent, ErrorDisplay],
  templateUrl: './heroi.html',
  styleUrl: './heroi.scss',
})
export class Heroi {
  private heroiService = inject(HeroiService);
  private superpoderService = inject(SuperpoderService);
  private router = inject(Router);

  herois = this.heroiService.heroisResource;
  superpoderes = this.superpoderService.superpoderesResource;

  errorStatus: number = 0;
  errorMessage: string = '';
  errorDetails?: string;
  errorValidation?: { [key: string]: string[] };

  editHero(id: number) {
    this.router.navigate(['/editar-heroi', id]);
  }

  async deleteHero(id: number) {
    if (confirm('Tem certeza que deseja excluir este herói?')) {
      try {
        await this.heroiService.deleteHero(id);
      } catch (error: any) {
        console.error('Erro ao excluir:', error);
        this.handleError(error);
      }
    }
  }

  private handleError(error: any) {
    if (this.isApiError(error)) {
      this.errorStatus = error.statusCode;
      this.errorMessage = error.message;
      this.errorDetails = error.details;
      this.errorValidation = error.errors;
    } else {
      this.errorStatus = 500;
      this.errorMessage = error.message || 'Erro desconhecido ao processar a solicitação.';
    }
  }

  private isApiError(error: any): error is IApiError {
    return error && typeof error.statusCode === 'number' && typeof error.message === 'string';
  }

  reloadPage() {
    this.errorStatus = 0;
    this.errorMessage = '';
    this.errorDetails = undefined;
    this.errorValidation = undefined;
    this.herois.reload();
  }
}
