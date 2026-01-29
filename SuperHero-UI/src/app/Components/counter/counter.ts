import { Component, model } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'SH-counter',
    standalone: true,
    imports: [CommonModule, FormsModule],
    template: `
    <div class="wrapper">
      <div class="container">
        <svg 
            (click)="decrement()"
            xmlns="http://www.w3.org/2000/svg" 
            width="24" height="24" 
            viewBox="0 0 24 24" 
            fill="none" 
            stroke="currentColor" 
            stroke-width="2" 
            stroke-linecap="round" 
            stroke-linejoin="round" 
             class="icon"
            >
            <path d="M5 12h14"></path>
        </svg>

        <span class="number">{{ value() || 0 }}</span>

        <svg 
            (click)="increment()"
            xmlns="http://www.w3.org/2000/svg" 
            width="24" height="24" 
            viewBox="0 0 24 24" 
            fill="none" 
            stroke="currentColor" 
            stroke-width="2" 
            stroke-linecap="round" 
            stroke-linejoin="round" 
             class="icon"
            >
            <path d="M12 5v14M5 12h14"></path>
        </svg>
      </div>
    </div>
  `,
    styles: [`
    .wrapper {
        display: flex;
        justify-content: flex-start;
        align-items: center;
        width: 100%;
    }
    .container {
        display: flex;
        align-items: center;
        justify-content: space-between;
        gap: 15px;
        background: rgba(36, 0, 70, 0.3);
        padding: 10px 20px;
        border-radius: 30px;
        border: 1px solid var(--color-secondary);
        box-shadow: inset 0 2px 4px rgba(0,0,0,0.3);
        width: 100%;
        max-width: 200px;
    }
    .number {
        font-size: 1.5rem;
        font-weight: bold;
        min-width: 50px;
        text-align: center;
        color: var(--color-text-main);
    }
    .icon {
        cursor: pointer;
        width: 24px;
        height: 24px;
        color: var(--color-primary);
        transition: color 0.2s, transform 0.1s;
        
        &:hover {
            color: #fff;
            filter: drop-shadow(0 0 5px var(--color-primary));
        }
        &:active {
            transform: scale(0.9);
        }
    }
  `]
})
export class Counter {
    value = model<number | null>(0);

    increment() {
        this.value.update(v => (v || 0) + 1);
    }

    decrement() {
        this.value.update(v => Math.max(0, (v || 0) - 1));
    }
}
