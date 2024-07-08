using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POO_Examen3.Models
{
    public class UserModel
    {
        public UserModel()
        {
            
        }
        public string? User { get; set; }

        public string? Email { get; set;}

        public bool Confirmed { get; set; }

        public bool IsAdmin { get; set; }

    }
}