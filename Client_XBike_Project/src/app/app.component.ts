import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ProjetoBikeAngular';

  public onSearch(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
    console.log(`buscar por: ${value}`)

    // lógica da busca
  }
}
