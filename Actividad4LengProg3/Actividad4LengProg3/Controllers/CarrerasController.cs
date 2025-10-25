using Microsoft.AspNetCore.Mvc;
using ActividadUnidad2.Models;
using System.Collections.Generic;
using System.Linq;

namespace ActividadUnidad2.Controllers
{
    public class CarrerasController : Controller
    {
        private static List<CarreraViewModel> carreras = new List<CarreraViewModel>();

        // GET: Carreras
        public IActionResult Index()
        {
            return View(carreras);
        }

        // GET: Carreras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carreras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarreraViewModel model)
        {
            if (ModelState.IsValid)
            {
                carreras.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Carreras/Edit/5
        public IActionResult Edit(int codigo)
        {
            var carrera = carreras.FirstOrDefault(c => c.Codigo == codigo);
            if (carrera == null)
                return NotFound();

            return View(carrera);
        }

        // POST: Carreras/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CarreraViewModel model)
        {
            if (ModelState.IsValid)
            {
                var carrera = carreras.FirstOrDefault(c => c.Codigo == model.Codigo);
                if (carrera == null)
                    return NotFound();

                carrera.Nombre = model.Nombre;
                carrera.CantidadCreditos = model.CantidadCreditos;
                carrera.CantidadMaterias = model.CantidadMaterias;
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Carreras/Delete/5
        public IActionResult Delete(int codigo)
        {
            var carrera = carreras.FirstOrDefault(c => c.Codigo == codigo);
            if (carrera == null)
                return NotFound();

            return View(carrera);
        }

        // POST: Carreras/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int codigo)
        {
            var carrera = carreras.FirstOrDefault(c => c.Codigo == codigo);
            if (carrera != null)
                carreras.Remove(carrera);

            return RedirectToAction(nameof(Index));
        }
    }
}
