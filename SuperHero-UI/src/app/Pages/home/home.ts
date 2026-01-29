import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeroiService } from '../../Core/Service/heroi.service';
import { LoaderComponent } from '../../Components/loader/loader';
import { HeroCardComponent } from '../../Components/hero-card/hero-card';

@Component({
  selector: 'SH-home',
  standalone: true,
  imports: [CommonModule, LoaderComponent, HeroCardComponent],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home {
  private heroiService = inject(HeroiService);
  herois = this.heroiService.heroisResource;


}
