using System.ComponentModel.DataAnnotations;

namespace Asignacion.Entidades
{
    public class Parametro
    {
        public int idparametro { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        [StringLength(50, ErrorMessage = "La {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 3)]
        public string descripcion { get; set; }

        [Required]
        [Display(Name = "Valor")]
        [StringLength(50, ErrorMessage = "El {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 3)]
        public string valor { get; set; }
    }
}
