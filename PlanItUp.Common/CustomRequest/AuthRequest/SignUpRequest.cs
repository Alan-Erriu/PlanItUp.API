using System.ComponentModel.DataAnnotations;

namespace PlanItUp.Common.CustomRequest.AuthRequest
{
    public class SignUpRequest
    {
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener al menos 3 caracteres y máximo 100 caracteres")]
        public string? name { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "El apellido debe tener al menos 3 caracteres y máximo 100 caracteres")]
        public string? lastname { get; set; }

        [EmailAddress(ErrorMessage = "Formato de correo electrónico no válido")]
        public string? email { get; set; }

        [MinLength(10, ErrorMessage = "El número de celular debe tener al menos 10 dígitos")]
        [MaxLength(14, ErrorMessage = "El número de teléfono no puede tener más de 14 dígitos")]
        [RegularExpression(@"^[0-9+]+$", ErrorMessage = "El campo celular debe contener solo valores numéricos")]
        public string? phone_number { get; set; }

        [Required(ErrorMessage = "Se requiere la contraseña del usuario")]
        public string? password_hash { get; set; }
    }
}
