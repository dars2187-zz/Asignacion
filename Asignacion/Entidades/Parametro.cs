using System.ComponentModel.DataAnnotations;

namespace Asignacion.Entidades
{
    public class Parametro
    {
        public int idparametro { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "La descripción no debe de tener más de {0} caracteres, ni menos de {2} caracteres.", MinimumLength = 3)]
        public string descripcion { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El valor no debe de tener más de {0} caracteres, ni menos de {2} caracteres.", MinimumLength = 3)]
        public string valor { get; set; }
    }
}
