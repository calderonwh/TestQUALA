using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendSucursales.Entities;

[Table("SucursalesTest")]
public partial class Sucursale
{
    public int IdSucursal { get; set; }

    public int Codigo { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Identificacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public int IdMoneda { get; set; }
}
