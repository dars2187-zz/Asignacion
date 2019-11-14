using System.ComponentModel.DataAnnotations;

namespace Asignacion.Entidades
{
    public class TipoDocumento
    {
        public int idtipodocumento { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        public string descripcion { get; set; }
    }
}
