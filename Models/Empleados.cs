using System.ComponentModel.DataAnnotations;

namespace Api_Empresa.Models
{
    public class Empleados
    {
        [Key]
        public int idEmpleado { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public string? correo { get; set; }
        public int cui { get; set; }
        public string? telefono { get; set; }
        public string? direccion { get; set; }
        public int idPuesto { get; set; }
    }
}
