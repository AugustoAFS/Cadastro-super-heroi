import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IHeroi } from '../../Core/Interfaces/IHeroi';

@Component({
    selector: 'SH-hero-card',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './hero-card.html',
    styleUrl: './hero-card.scss'
})
export class HeroCardComponent {
    @Input() hero: any;
    @Input() showActions: boolean = false;

    @Output() onEdit = new EventEmitter<number>();
    @Output() onDelete = new EventEmitter<number>();

    edit(event: Event) {
        event.stopPropagation();
        this.onEdit.emit(this.hero.id);
    }

    delete(event: Event) {
        event.stopPropagation();
        this.onDelete.emit(this.hero.id);
    }
}
