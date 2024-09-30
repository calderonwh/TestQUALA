import { Component,OnInit  } from '@angular/core';
import { Sucursal } from '../models/sucursal.model';
import { SucursalService } from '../services/sucursal.service';

@Component({
  selector: 'app-sucursales',
  templateUrl: './sucursales.component.html',
  styleUrls: ['./sucursales.component.css']
})
export class SucursalesComponent implements OnInit {
  sucursales: Sucursal[] = [];

  constructor(private sucursalService: SucursalService) { }

  ngOnInit(): void {
    this.loadSucursales();
  }

  loadSucursales(): void {
    this.sucursalService.getSucursales().subscribe(
      (data: Sucursal[]) => {
        this.sucursales = data;
      },
      error => {
        console.error('Error al cargar las sucursales', error);
      }
    );
  }

  deleteSucursal(id: number): void {
    if (confirm('¿Estás seguro de que deseas eliminar esta sucursal?')) {
      this.sucursalService.deleteSucursal(id).subscribe(
        () => {
          this.loadSucursales(); // Recargar la lista después de eliminar
        },
        (error) => {
          console.error('Error al eliminar la sucursal', error);
        }
      );
    }
  }
  
}
