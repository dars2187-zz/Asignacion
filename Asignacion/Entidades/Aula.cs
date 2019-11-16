using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asignacion.Entidades
{
    public class Aula
    {
        public int idaula { get; set; }

        [Required]
        [Display(Name = "Número de Aula")]
        [StringLength(10, ErrorMessage = "Los {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 1)]
        public string numaula { get; set; }

        [Required]
        [Display(Name = "Sedes")]
        public int idsede { get; set; }

        public List<Sede> sede { get; set; }

        public ICollection<GrupoAula> grupoaulas { get; set; }
    }
}
