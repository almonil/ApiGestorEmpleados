import { Component, Input, OnInit } from '@angular/core';
import { ImagenesService } from '../../core/services/imagenes.service';
import { ImagenProducto } from '../../shared/models/imagen-producto.model';

@Component({
  selector: 'app-imagenes-producto',
  templateUrl: './imagenes-producto.component.html',
  styleUrls: ['./imagenes-producto.component.css']
})
export class ImagenesProductoComponent implements OnInit {
  @Input() productoId!: number;

  imagenes: ImagenProducto[] = [];
  archivoSeleccionado!: File;

  constructor(private imagenesService: ImagenesService) {}

  ngOnInit(): void {
    this.obtenerImagenes();
  }

  obtenerImagenes(): void {
    if (!this.productoId) return;

    this.imagenesService.obtenerPorProducto(this.productoId).subscribe({
      next: (res) => this.imagenes = res,
      error: (err) => console.error('Error al cargar imágenes:', err)
    });
  }

  seleccionarArchivo(event: any): void {
    this.archivoSeleccionado = event.target.files[0];
  }

  subirImagen(): void {
    if (!this.archivoSeleccionado || !this.productoId) return;

    this.imagenesService.subirImagen(this.archivoSeleccionado, this.productoId).subscribe({
      next: () => {
        this.obtenerImagenes();
        this.archivoSeleccionado = undefined!;
      },
      error: (err) => console.error('Error al subir imagen:', err)
    });
  }

  eliminarImagen(id: number): void {
    if (confirm('¿Estás seguro de que deseas eliminar esta imagen?')) {
      this.imagenesService.eliminarImagen(id).subscribe(() => this.obtenerImagenes());
    }
  }

  obtenerUrlCompleta(imagen: ImagenProducto): string {
    return `https://localhost:5145/${imagen.url}`;
  }
}
