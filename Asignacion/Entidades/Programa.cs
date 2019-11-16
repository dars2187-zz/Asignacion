using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asignacion.Entidades
{
    public class Programa
    {
        public int idprograma { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        [StringLength(50, ErrorMessage = "La {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 3)]
        public string descripcion { get; set; }

        [Required]
        [Display(Name = "Facultad")]
        public int idfacultad { get; set; }

        public List<Facultad> facultad { get; set; }

        public ICollection<ProgramaAsignatura> programaasignaturas { get; set; }

        [Required]
        [Display(Name = "Jornada")]
        public int idjornada { get; set; }

        public List<Jornada> jornada { get; set; }
    }
}
