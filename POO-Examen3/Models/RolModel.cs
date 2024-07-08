using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POO_Examen3.Models
{
    public class RolModel
    {
        public Guid Id { get; set;}
        [Required(ErrorMessage = "El {0} es obligatorio")]
        [Display(Name = "Rol")]
        public string Name { get; set;}
    }
}