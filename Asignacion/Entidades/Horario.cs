using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asignacion.Entidades
{
    public class Horario : IValidatableObject
    {
        public int idhorario { get; set; }

        [Required]
        [Display(Name = "Hora de inicio")]
        [StringLength(5, ErrorMessage = "La {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 5)]
        [RegularExpression("^([01]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "El formato de la hora es incorrecto.")]
        public string horainicio { get; set; }

        [Required]
        [Display(Name = "Hora de fin")]
        [StringLength(5, ErrorMessage = "La {0} deben tener por lo menos {2} caracteres de longitud.", MinimumLength = 5)]
        [RegularExpression("^([01]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "El formato de la hora es incorrecto.")]
        public string horafin { get; set; }

        [Required]
        [Display(Name = "Día de la semana")]
        public int iddiasemana { get; set; }

        public DiaSemana diasemana { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateTime.Parse("01/01/1900 " + horainicio) >= DateTime.Parse("01/01/1900 " + horafin))
            {
                yield return new ValidationResult(
                    $"La hora de inicio no puede ser mayor o igual a la hora de fin.",
                    new[] { "horainicio" });
            }

            if (DateTime.Parse("01/01/1900 " + horafin) == DateTime.Parse("01/01/1900 " + horainicio))
            {
                yield return new ValidationResult(
                    $"La hora de fin no puede ser igual a la hora de inicio.",
                    new[] { "horafin" });
            }
        }
    }
}
