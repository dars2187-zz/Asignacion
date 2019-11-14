using System.ComponentModel.DataAnnotations;

namespace Asignacion.Entidades
{
    public class Facultad
    {
        public int idfacultad { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El nombre no debe de tener más de {0} caracteres, ni menos de {2} caracteres.", MinimumLength = 3)]
        public string descripcion { get; set; }
    }
}
