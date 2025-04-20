import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';  // Importa CommonModule
import { ProductosService } from '../../core/services/productos.service';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Producto } from '../../shared/models/producto.model';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  standalone: true,  // Asegúrate de que el componente sea standalone
  imports: [CommonModule, ReactiveFormsModule]  // Agrega CommonModule aquí
})
export class ProductosComponent implements OnInit {
  productos: Producto[] = [];
  productoForm: any;

  constructor(private productosService: ProductosService, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.productoForm = this.fb.group({
      id: [0],
      nombre: ['', Validators.required],
      descripcion: [''],
      precio: [0, [Validators.required, Validators.min(1)]],
      estado: [true]
    });

    this.obtenerProductos();
  }

  obtenerProductos(): void {
    this.productosService.getProductos().subscribe(p => this.productos = p);
  }

  guardar(): void {
    const producto = this.productoForm.value as Producto;
    if (producto.id) {
      this.productosService.actualizarProducto(producto.id, producto).subscribe(() => this.obtenerProductos());
    } else {
      this.productosService.crearProducto(producto).subscribe(() => this.obtenerProductos());
    }
    this.productoForm.reset({ id: 0, estado: true });
  }

  editar(p: Producto): void {
    this.productoForm.patchValue(p);
  }

  eliminar(id: number): void {
    this.productosService.eliminarProducto(id).subscribe(() => this.obtenerProductos());
  }
}
