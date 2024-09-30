import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Moneda } from '../models/moneda.model';

@Injectable({
  providedIn: 'root'
})
export class MonedaService {

  private apiUrl = 'http://localhost:5085/api/moneda';

  constructor(private http: HttpClient) { }

  getMonedas(): Observable<Moneda[]> {
    return this.http.get<Moneda[]>(this.apiUrl);
  }
}
