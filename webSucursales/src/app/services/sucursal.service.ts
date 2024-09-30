import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sucursal } from '../models/sucursal.model';

@Injectable({
  providedIn: 'root'
})
export class SucursalService {

  private apiUrl = 'http://localhost:5085/api/sucursales';

  constructor(private http: HttpClient) { }

  getSucursales(): Observable<Sucursal[]> {
    return this.http.get<Sucursal[]>(this.apiUrl);
  }
  
  getSucursalById(id: number): Observable<Sucursal> {
    return this.http.get<Sucursal>(`${this.apiUrl}/${id}`);
  }
  
  createSucursal(sucursal: Sucursal): Observable<Sucursal> {
    return this.http.post<Sucursal>(this.apiUrl, sucursal);
  }
  
  updateSucursal(id: number, sucursal: Sucursal): Observable<Sucursal> {
    return this.http.put<Sucursal>(`${this.apiUrl}/${id}`, sucursal);
  }

  deleteSucursal(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

}
