import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ImagenProducto } from "../../shared/models/imagen-producto.model";

@Injectable({ providedIn: 'root' })
export class ImagenesService {
  private apiUrl = 'https://localhost:5145/api/imagenesproducto';

  constructor(private http: HttpClient) {}

  subirImagen(imagen: File, productoId: number): Observable<any> {
    const formData = new FormData();
    formData.append('imagen', imagen);
    formData.append('productoId', productoId.toString());
    return this.http.post(this.apiUrl, formData);
  }

  obtenerPorProducto(productoId: number): Observable<ImagenProducto[]> {
    return this.http.get<ImagenProducto[]>(`${this.apiUrl}/producto/${productoId}`);
  }

  eliminarImagen(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
