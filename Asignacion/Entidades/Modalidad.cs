using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asignacion.Entidades
{
    public class Modalidad
    {
        public int idmodalidad { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        [StringLength(50, ErrorMessage = "La {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 3)]
        public string descripcion { get; set; }

        public ICollection<Asignatura> asignatura { get; set; }
    }
}
