import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  // Substituir pela url da minha api
  private baseUrl = 'https://localhost:44373/api/Bicicleta'
  constructor(private http: HttpClient) { }

  getIBicicletas(): Observable<any> {
    //return this.http.get(`${this.baseUrl}/Bicicleta`);
    return this.http.get(this.baseUrl);
  }

  // Outros métodos
}
