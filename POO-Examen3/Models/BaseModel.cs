using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POO_Examen3.Models
{
    public class BaseModel
    {
        
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}