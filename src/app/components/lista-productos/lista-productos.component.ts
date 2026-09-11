import { Component } from '@angular/core';
import { Producto } from '../../interfaces/producto';
import { CommonModule } from '@angular/common'; // Necesario para ngIf y ngFor si no usas la nueva sintaxis

@Component({
  selector: 'app-lista-productos',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './lista-productos.component.html',
  styleUrl: './lista-productos.component.css'
})
export class ListaProductosComponent {
  // Arreglo de productos simulando el inventario de la tienda
  productos: Producto[] = [
    { id: 1, nombre: 'Gaseosa 3 Litros', precio: 15.50, disponible: true },
    { id: 2, nombre: 'Bolsa de Tortrix', precio: 1.50, disponible: true },
    { id: 3, nombre: 'Lata de Frijoles', precio: 8.00, disponible: false }
  ];
}