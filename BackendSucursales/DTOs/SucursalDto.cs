namespace BackendSucursales.DTOs
{
    public class SucursalDto
    {
        public int IdSucursal { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Identificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdMoneda { get; set; }
    }

}
