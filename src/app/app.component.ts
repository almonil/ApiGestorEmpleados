import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';  // Importa RouterOutlet

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],  // Asegúrate de importar RouterOutlet
  templateUrl: './app.component.html',
})
export class AppComponent {}
