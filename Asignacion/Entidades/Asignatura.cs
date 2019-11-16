using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asignacion.Entidades
{
    public class Asignatura
    {
        public int idasignatura { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        [StringLength(50, ErrorMessage = "La {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 3)]
        public string descripcion { get; set; }

        [Required]
        [Display(Name = "Cantidad de Créditos")]
        public int credito { get; set; }

        [Required]
        [Display(Name = "Modalidad")]
        public int idmodalidad { get; set; }

        public List<Modalidad> modalidad { get; set; }

        public ICollection<ProgramaAsignatura> programaasignaturas { get; set; }
    }
}
