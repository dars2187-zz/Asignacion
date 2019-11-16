using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asignacion.Entidades
{
    public class Usuario
    {
        public int idusuario { get; set; }

        [Required]
        [Display(Name = "Número de documento")]
        [StringLength(10, ErrorMessage = "Los {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 5)]
        public string numdocumento { get; set; }

        [Required]
        [Display(Name = "Nombres")]
        [StringLength(100, ErrorMessage = "Los {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 3)]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        [StringLength(100, ErrorMessage = "Los {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 3)]
        public string apellido { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string correo { get; set; }

        [Display(Name = "Teléfono")]
        public int telefono { get; set; }
        
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "El {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 8)]
        [Display(Name = "Clave")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "La contraseña debe tener por lo menos 8 caracteres y contener 3 o 4 caracteres de los siguientes: Mayúsculas (A-Z), minúsculas (a-z), números (0-9) y un carácter especial (ej. !@#$%^&*)")]
        public string clave { get; set; }

        [Display(Name = "Activo")]
        public bool estado { get; set; }

        [Required]
        [Display(Name = "Roles")]
        public int idrol { get; set; }

        [Required]
        [Display(Name = "Tipos de Documento")]
        public int idtipodocumento { get; set; }

        public Rol rol { get; set; }
        public TipoDocumento tipodocumento { get; set; }

        [Required]
        [Display(Name = "Programa")]
        public int idprograma { get; set; }

        public List<Programa> programa { get; set; }
    }
}
