import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ProjetoBikeAngular';

  subNavLinks = [
    { label: 'Nossas Lojas', path: '/' },
    { label: 'Seja um Parceiro X-Bike', path: '/' },
    { label: 'Trabalhe Conoso', path: '/' },
    { label: 'BAIXE O APP', path: '/' }
  ]

  primaryNavLinks = [
    { label: 'Home', path: '/' },
    { label: 'Sobre', path: '/' },
    { label: 'Contato', path: '/' }
  ]

  secondaryNavLinks = [
    { label: 'Botão 1', path: '/' },
    { label: 'Botão 2', path: '/' },
    { label: 'Botão 3', path: '/' },
    { label: 'Botão 4', path: '/' },
    { label: 'Botão 5', path: '/' },
  ]

  public onSearch(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
    console.log(`buscar por: ${value}`)

    // lógica da busca
  }
}
