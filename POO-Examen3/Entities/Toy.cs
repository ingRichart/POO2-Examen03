using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POO_Examen3.Entities
{
    public class Toy : BaseEntity
    {
        public Toy()
        {
        }

        public Guid? CategoryId { get; set; }

        public Category? Category { get; set; }

        
    }
}