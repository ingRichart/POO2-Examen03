using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace POO_Examen3.Models
{
    public class ToyModel : BaseModel
    {
        public ToyModel()
        {
            CategoryList = new List<SelectListItem>();
        }

        public Guid? CategoryId { get; set; }

        public CategoryModel? CategoryModel { get; set; }

        public string? CategoryName { get; set; }

        public List<SelectListItem>? CategoryList { get; set; }

    }
}