using System.ComponentModel.DataAnnotations;

namespace Asignacion.Entidades
{
    public class Horario
    {
        public int idhorario { get; set; }

        [Display(Name = "Hora de inicio")]
        [StringLength(5, ErrorMessage = "La {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 5)]
        public string horainicio { get; set; }

        [Display(Name = "Hora de fin")]
        [StringLength(5, ErrorMessage = "La {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 5)]
        public string horafin { get; set; }

        [Required]
        [Display(Name = "Día de la semana")]
        public int iddiasemana { get; set; }

        public DiaSemana diasemana { get; set; }
    }
}
