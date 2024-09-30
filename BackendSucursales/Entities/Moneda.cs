using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendSucursales.Entities;

[Table("MonedaTest")]
public partial class Moneda
{
    public int IdMoneda { get; set; }

    public string Nombre { get; set; } = null!;

    public string Simbolo { get; set; } = null!;
}
