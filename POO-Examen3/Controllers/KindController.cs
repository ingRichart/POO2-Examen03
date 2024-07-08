using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POO_Examen3;
using POO_Examen3.Entities;
using POO_Examen3.Models;

namespace PruebaEntityFrameworkCore.Controllers
{
    public class KindController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KindController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult KindList()
        {
            var list = _context.KindToys.Select(model => new KindModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            }).ToList();

            return View(list);
        }   

        public IActionResult KindAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KindAdd(KindModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = new Kind();
            entity.Id = new Guid();
            entity.Name = model.Name;
            entity.Description = model.Description;

            this._context.KindToys.Add(entity);
            this._context.SaveChanges();
            
            return RedirectToAction("KindList","Kind");
        }

        public IActionResult KindEdit(Guid Id)
        {
            // SENTENCIA EN LINQ
            var entity = this._context.KindToys
                .Where(p => p.Id == Id).FirstOrDefault();
            
            //VALIDACION SI NO LO ENCUENTRA 
            if (entity == null)
            {
                return RedirectToAction("KindList","Kind");
            }

            //Se asigna la info de la BD al MODELO.
            KindModel model = new KindModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Description = entity.Description;

            //PASAMOS LA INFORMACION AL MODELO
            return View(model);
        }

        [HttpPost]
        public IActionResult KindEdit(KindModel model)
        {
            //Carga la información de la BD
            var entity = this._context.KindToys
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
            this._context.KindToys.Update(entity);
            this._context.SaveChanges();
            
            //Muestra otravez la lista 
            return RedirectToAction("KindList","Kind");
        }

        public IActionResult KindDeleted(Guid Id)
        {
            var entity = this._context.KindToys
            .Where(p => p.Id == Id).FirstOrDefault();
            
            if (entity == null)
            {
                return RedirectToAction("KindList","Kind");
            }


            var model = new KindModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Description = entity.Description;

            return View(model);
        }

        [HttpPost]
        public IActionResult KindDeleted(KindModel model)
        {
            bool exits = this._context.KindToys.Any(p => p.Id == model.Id);
            if (!exits)
            {
                return View(model);
            }


            var entity = this._context.KindToys
            .Where(p => p.Id == model.Id).First();

            this._context.KindToys.Remove(entity);
            this._context.SaveChanges();
            
            return RedirectToAction("KindList","Kind");
        }

    }
}