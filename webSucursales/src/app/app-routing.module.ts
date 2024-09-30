import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SucursalesComponent } from './sucursales/sucursales.component';
import { SucursalFormComponent } from './sucursal-form/sucursal-form.component';

const routes: Routes = [
  { path: 'sucursales', component: SucursalesComponent },
  { path: 'sucursales/new', component: SucursalFormComponent },
  { path: 'sucursales/edit/:id', component: SucursalFormComponent },
  { path: '', redirectTo: '/sucursales', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
