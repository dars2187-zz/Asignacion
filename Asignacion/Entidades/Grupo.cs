using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asignacion.Entidades
{
    public class Grupo
    {
        public int idgrupo { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        [StringLength(10, ErrorMessage = "La {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 3)]
        public string descripcion { get; set; }

        [Required]
        [Display(Name = "Horario")]
        public int idhorario { get; set; }

        public List<Horario> horario { get; set; }

        [Required]
        [Display(Name = "Asignatura")]
        public int idasignatura { get; set; }

        public List<GrupoAula> grupoaulas { get; set; }

        public ICollection<Aula> aulas { get; set; }
    }
}
