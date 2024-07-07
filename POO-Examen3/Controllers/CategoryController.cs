using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POO_Examen3.Entities;
using POO_Examen3.Models;

namespace PruebaEntityFrameworkCore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult CategoryList()
        {
            var list = _context.CategoryToys.Select(model => new CategoryModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            }).ToList();

            return View(list);
        }   

        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = new Category();
            entity.Id = new Guid();
            entity.Name = model.Name;
            entity.Description = model.Description;

            this._context.CategoryToys.Add(entity);
            this._context.SaveChanges();
            
            return RedirectToAction("CategoryList","Category");
        }

        public IActionResult CategoryEdit(Guid Id)
        {
            // SENTENCIA EN LINQ
            var entity = this._context.CategoryToys
                .Where(p => p.Id == Id).FirstOrDefault();
            
            //VALIDACION SI NO LO ENCUENTRA 
            if (entity == null)
            {
                return RedirectToAction("CategoryList","Category");
            }

            //Se asigna la info de la BD al MODELO.
            CategoryModel model = new CategoryModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Description = entity.Description;

            //PASAMOS LA INFORMACION AL MODELO
            return View(model);
        }

        [HttpPost]
        public IActionResult CategoryEdit(CategoryModel model)
        {
            //Carga la información de la BD
            var entity = this._context.CategoryToys
             .Where(p => p.Id == model.Id).First();

            //VALIDACION
            if (entity == null)
            {
                return View(model);
            }
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //REmplaza lo del modelo en el objeto de la BD
            entity.Name = model.Name;
            entity.Description = model.Description;

            //Actualiza y guarda
            this._context.CategoryToys.Update(entity);
            this._context.SaveChanges();
            
            //Muestra otravez la lista 
            return RedirectToAction("CategoryList","Category");
        }

        public IActionResult CategoryDeleted(Guid Id)
        {
            var entity = this._context.CategoryToys
            .Where(p => p.Id == Id).FirstOrDefault();
            
            if (entity == null)
            {
                return RedirectToAction("CategoryList","Category");
            }


            var model = new CategoryModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Description = entity.Description;

            return View(model);
        }

        [HttpPost]
        public IActionResult CategoryDeleted(CategoryModel model)
        {
            bool exits = this._context.CategoryToys.Any(p => p.Id == model.Id);
            if (!exits)
            {
                return View(model);
            }


            var entity = this._context.CategoryToys
            .Where(p => p.Id == model.Id).First();

            this._context.CategoryToys.Remove(entity);
            this._context.SaveChanges();
            
            return RedirectToAction("CategoryList","Category");
        }

    }
}