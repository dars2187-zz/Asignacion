using System.ComponentModel.DataAnnotations;

namespace Asignacion.Entidades
{
    public class DiaSemana
    {
        public int iddiasemana { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        [StringLength(10, ErrorMessage = "La {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 3)]
        public string descripcion { get; set; }
    }
}
