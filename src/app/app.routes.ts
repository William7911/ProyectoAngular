import { Routes } from '@angular/router';
import { Inicio } from './components/inicio/inicio.component';
import { ListaProductosComponent } from './components/lista-productos/lista-productos.component';


export const routes: Routes = [
  { path: '', component: Inicio },
  { path: 'productos', component: ListaProductosComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];