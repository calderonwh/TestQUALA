import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SucursalesComponent } from './sucursales/sucursales.component';
import { SucursalFormComponent } from './sucursal-form/sucursal-form.component';
import { ReactiveFormsModule } from '@angular/forms'; 

@NgModule({
  declarations: [
    AppComponent,
    SucursalesComponent,
    SucursalFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
