using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POO_Examen3.Models
{
    public class ChangePasswordModel
    {
        public ChangePasswordModel()
        {
            OldPassword = string.Empty;
            NewPassword = string.Empty;
            ConfirmPassword = string.Empty;
            HelpPassword = string.Empty;
        }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Password)]
        [Display(Name = "Password Actual")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Password)]
        [Display(Name = "Nuevo Password")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Nuevo Password")]
        [Compare("NewPassword", ErrorMessage = "El campo {0} y el campo {1} no coincide")]
        public string ConfirmPassword { get; set; }

        public string HelpPassword { get; set; }

        public string? MessageConfirmed { get; set; }

    }
}