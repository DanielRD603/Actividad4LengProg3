using Microsoft.AspNetCore.Mvc;
using ActividadUnidad2.Models;
using System.Collections.Generic;
using System.Linq;

namespace ActividadUnidad2.Controllers
{
    public class RecintosController : Controller
    {
        private static List<RecintoViewModel> recintos = new List<RecintoViewModel>();

        // GET: Recintos
        public IActionResult Index()
        {
            return View(recintos);
        }

        // GET: Recintos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recintos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RecintoViewModel model)
        {
            if (ModelState.IsValid)
            {
                recintos.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Recintos/Edit/5
        public IActionResult Edit(int codigo)
        {
            var recinto = recintos.FirstOrDefault(r => r.Codigo == codigo);
            if (recinto == null)
                return NotFound();

            return View(recinto);
        }

        // POST: Recintos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RecintoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var recinto = recintos.FirstOrDefault(r => r.Codigo == model.Codigo);
                if (recinto == null)
                    return NotFound();

                recinto.Nombre = model.Nombre;
                recinto.Direccion = model.Direccion;
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Recintos/Delete/5
        public IActionResult Delete(int codigo)
        {
            var recinto = recintos.FirstOrDefault(r => r.Codigo == codigo);
            if (recinto == null)
                return NotFound();

            return View(recinto);
        }

        // POST: Recintos/DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int codigo)
        {
            var recinto = recintos.FirstOrDefault(r => r.Codigo == codigo);
            if (recinto != null)
                recintos.Remove(recinto);

            return RedirectToAction(nameof(Index));
        }
    }
}
