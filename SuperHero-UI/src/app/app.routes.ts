import { Routes } from '@angular/router';
import { Layout } from './Pages/layout/layout';
import { Home } from './Pages/home/home';
import { Heroi } from './Pages/heroi/heroi';

export const routes: Routes = [
    {
        path: '',
        component: Layout,
        children: [
            {
                path: '',
                component: Home,
            },
            {
                path: 'heroi',
                component: Heroi,
            },
            {
                path: 'cadastro-heroi',
                loadComponent: () => import('./Pages/cadastro-heroi/cadastro-heroi').then(m => m.CadastroHeroi)
            },
            {
                path: 'editar-heroi/:id',
                loadComponent: () => import('./Pages/editar-heroi/editar-heroi').then(m => m.EditarHeroi)
            },
        ],
    },
];
