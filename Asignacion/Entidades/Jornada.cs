using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asignacion.Entidades
{
    public class Jornada
    {
        public int idjornada { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        [StringLength(100, ErrorMessage = "La {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 3)]
        public string descripcion { get; set; }

        public ICollection<Programa> programa { get; set; }
    }
}
