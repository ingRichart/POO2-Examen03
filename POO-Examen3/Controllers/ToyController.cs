using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POO_Examen3.Entities;
using POO_Examen3.Models;

namespace POO_Examen3.Controllers
{
    public class ToyController : Controller
    {
                private readonly ApplicationDbContext _context;

        public ToyController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult ToyList()
        {
            var list = _context.Toys.Select(model => new ToyModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            }).ToList();

            return View(list);
        }   

        public IActionResult ToyAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ToyAdd(ToyModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = new Toy();
            entity.Id = new Guid();
            entity.Name = model.Name;
            entity.Description = model.Description;

            this._context.Toys.Add(entity);
            this._context.SaveChanges();
            
            return RedirectToAction("ToyList","Toy");
        }

        public IActionResult ToyEdit(Guid Id)
        {
            // SENTENCIA EN LINQ
            var entity = this._context.Toys
                .Where(p => p.Id == Id).FirstOrDefault();
            
            //VALIDACION SI NO LO ENCUENTRA 
            if (entity == null)
            {
                return RedirectToAction("ToyList","Toy");
            }

            //Se asigna la info de la BD al MODELO.
            ToyModel model = new ToyModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Description = entity.Description;

            //PASAMOS LA INFORMACION AL MODELO
            return View(model);
        }

        [HttpPost]
        public IActionResult ToyEdit(ToyModel model)
        {
            //Carga la información de la BD
            var entity = this._context.Toys
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
            this._context.Toys.Update(entity);
            this._context.SaveChanges();
            
            //Muestra otravez la lista 
            return RedirectToAction("ToyList","Toy");
        }

        public IActionResult ToyDeleted(Guid Id)
        {
            var entity = this._context.Toys
            .Where(p => p.Id == Id).FirstOrDefault();
            
            if (entity == null)
            {
                return RedirectToAction("ToyList","Toy");
            }


            var model = new ToyModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Description = entity.Description;

            return View(model);
        }

        [HttpPost]
        public IActionResult ToyDeleted(ToyModel model)
        {
            bool exits = this._context.Toys.Any(p => p.Id == model.Id);
            if (!exits)
            {
                return View(model);
            }


            var entity = this._context.Toys
            .Where(p => p.Id == model.Id).First();

            this._context.Toys.Remove(entity);
            this._context.SaveChanges();
            
            return RedirectToAction("ToyList","Toy");
        }

    }
}