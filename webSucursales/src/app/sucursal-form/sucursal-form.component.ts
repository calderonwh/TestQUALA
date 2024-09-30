import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SucursalService } from '../services/sucursal.service';
import { Moneda } from '../models/moneda.model';
import { MonedaService } from '../services/moneda.service';

@Component({
  selector: 'app-sucursal-form',
  templateUrl: './sucursal-form.component.html',
  styleUrls: ['./sucursal-form.component.css']
})
export class SucursalFormComponent implements OnInit {
  
  sucursalForm: FormGroup;
  isEdit: boolean = false;
  idSucursal: number | null = null;
  monedas: Moneda[] = []; 

  constructor(
    private fb: FormBuilder,
    private sucursalService: SucursalService,
    private monedaService: MonedaService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.sucursalForm = this.fb.group({
      idSucursal: [null], 
      codigo: ['', [Validators.required, Validators.min(1)]],
      descripcion: ['', [Validators.required, Validators.minLength(3)]], 
      direccion: ['', [Validators.required, Validators.minLength(5)]],
      identificacion: ['', [Validators.required, Validators.pattern('[a-zA-Z0-9]+')]],
      idMoneda: [1, Validators.required],
      fechaCreacion: [{ value: null, disabled: true }] // Campo de fecha deshabilitado
    });
  }

  ngOnInit(): void {
    this.idSucursal = this.route.snapshot.params['id'];
    this.loadMonedas();
    if (this.idSucursal) {
      this.isEdit = true;
      this.loadSucursal(this.idSucursal);
    }
  }

  loadMonedas(): void {
    this.monedaService.getMonedas().subscribe(
      (data) => {
        this.monedas = data; // Asignar los datos a la propiedad monedas
      },
      (error) => {
        console.error('Error al cargar las monedas', error);
      }
    );
  }

  loadSucursal(id: number): void {
    this.sucursalService.getSucursalById(id).subscribe(
      (data) => {
        this.sucursalForm.patchValue({
          idSucursal: data.idSucursal,
          codigo: data.codigo,
          descripcion: data.descripcion,
          direccion: data.direccion,
          identificacion: data.identificacion,
          idMoneda: data.idMoneda,
          fechaCreacion: data.fechaCreacion
        });
      },
      (error) => {
        console.error('Error al cargar la sucursal', error);
      }
    );
  }

  get codigo(): AbstractControl | null {
    return this.sucursalForm.get('codigo');
  }

  get descripcion(): AbstractControl | null {
    return this.sucursalForm.get('descripcion');
  }

  get direccion(): AbstractControl | null {
    return this.sucursalForm.get('direccion');
  }

  get identificacion(): AbstractControl | null {
    return this.sucursalForm.get('identificacion');
  }

  onCancel(): void {
    this.router.navigate(['/sucursales']); // Redirige a la lista de sucursales
  }

  onSubmit(): void {
    if (this.sucursalForm.valid) {
      const sucursalData = {
        ...this.sucursalForm.value,
        idSucursal: this.isEdit ? this.idSucursal : undefined, // Enviar idSucursal solo en edición
        fechaCreacion: this.isEdit ? this.sucursalForm.get('fechaCreacion')?.value : new Date().toISOString() // Establecer fecha de creación
      };

      if (this.isEdit) {
        this.sucursalService.updateSucursal(this.idSucursal!, sucursalData).subscribe(
          () => {
            this.router.navigate(['/sucursales']);
          },
          (error) => {
            console.error('Error al actualizar la sucursal', error);
          }
        );
      } else {
        this.sucursalService.createSucursal(sucursalData).subscribe(
          () => {
            this.router.navigate(['/sucursales']);
          },
          (error) => {
            console.error('Error al crear la sucursal', error);
          }
        );
      }
    }
  }
}
