using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Actividad4LengProg3.Models;

namespace Actividad4LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private static readonly List<EstudianteViewModel> _estudiantes = new();
        private static readonly List<string> _carreras = new(){
            "Administración de Empresas","Contabilidad","Derecho","Psicología Clínica",
            "Orientación Escolar","Administración y Supervisión Escolar","Enfermería",
            "Odontología","Ingeniería","Ciencias Naturales"
        };
        private void CargarListas() => ViewBag.Carreras = new SelectList(_carreras);

        public IActionResult Index() { CargarListas(); return View(new EstudianteViewModel()); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(EstudianteViewModel estudiante)
        {
            CargarListas();
            if (_estudiantes.Any(e => string.Equals(e.Matricula, estudiante.Matricula, StringComparison.OrdinalIgnoreCase)))
                ModelState.AddModelError(nameof(estudiante.Matricula), "Ya existe un estudiante con esa matrícula.");
            if (!ModelState.IsValid) return View("Index", estudiante);
            _estudiantes.Add(new EstudianteViewModel
            {
                Matricula = estudiante.Matricula.Trim(),
                NombreCompleto = estudiante.NombreCompleto.Trim(),
                Carrera = estudiante.Carrera.Trim(),
                Recinto = estudiante.Recinto,
                CorreoInstitucional = estudiante.CorreoInstitucional.Trim(),
                Celular = estudiante.Celular.Trim(),
                Telefono = estudiante.Telefono.Trim(),
                Direccion = estudiante.Direccion.Trim(),
                FechaNacimiento = estudiante.FechaNacimiento,
                Genero = estudiante.Genero,
                Turno = estudiante.Turno,
                Becado = estudiante.Becado,
                PorcentajeBeca = estudiante.PorcentajeBeca
            });
            return RedirectToAction(nameof(Lista));
        }

        public IActionResult Lista()
        {
            var data = _estudiantes.OrderBy(e => e.Matricula, StringComparer.OrdinalIgnoreCase).ToList();
            return View(data);
        }

        public IActionResult Editar(string matricula)
        {
            if (string.IsNullOrWhiteSpace(matricula)) return NotFound();
            var est = _estudiantes.FirstOrDefault(e => string.Equals(e.Matricula, matricula, StringComparison.OrdinalIgnoreCase));
            if (est is null) return NotFound();
            CargarListas();
            return View(est);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(EstudianteViewModel estudiante)
        {
            CargarListas();
            if (!ModelState.IsValid) return View(estudiante);
            var ex = _estudiantes.FirstOrDefault(e => string.Equals(e.Matricula, estudiante.Matricula, StringComparison.OrdinalIgnoreCase));
            if (ex is null) return NotFound();
            ex.NombreCompleto = estudiante.NombreCompleto.Trim();
            ex.Carrera = estudiante.Carrera.Trim();
            ex.Recinto = estudiante.Recinto;
            ex.CorreoInstitucional = estudiante.CorreoInstitucional.Trim();
            ex.Celular = estudiante.Celular.Trim();
            ex.Telefono = estudiante.Telefono.Trim();
            ex.Direccion = estudiante.Direccion.Trim();
            ex.FechaNacimiento = estudiante.FechaNacimiento;
            ex.Genero = estudiante.Genero;
            ex.Turno = estudiante.Turno;
            ex.Becado = estudiante.Becado;
            ex.PorcentajeBeca = estudiante.PorcentajeBeca;
            return RedirectToAction(nameof(Lista));
        }

        public IActionResult Eliminar(string matricula)
        {
            var est = _estudiantes.FirstOrDefault(e => string.Equals(e.Matricula, matricula, StringComparison.OrdinalIgnoreCase));
            if (est != null) _estudiantes.Remove(est);
            return RedirectToAction(nameof(Lista));
        }
    }
}
