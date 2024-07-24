using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoMod10.Models;

namespace ProyectoMod10.Controllers
{
    public class ActividadController : Controller
    {
        private readonly ContextoDeDatos db;
        public ActividadController(ContextoDeDatos contexto)
        {
            db = contexto;
        }

        // GET: ActividadController
        public ActionResult Index()
        {
            var actividad = db.Actividades.ToList(); 
            return View(actividad);
        }

        // GET: ActividadController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var actividad = await db.Actividades.SingleOrDefaultAsync(d => d.Id == id);
            return View(actividad);
        }

        // GET: ActividadController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActividadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                db.Actividades.Add(actividad);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Actividad");
            }
            return View(actividad);
        }

        // GET: ActividadController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var actividad = await db.Actividades.SingleOrDefaultAsync(d => d.Id == id);
            return View(actividad);
        }

        // POST: ActividadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Actividad actividad)
        {
            if (ModelState.IsValid)
            {
                var temp = await db.Actividades.SingleOrDefaultAsync(d => d.Id == actividad.Id);
                temp.Título = actividad.Título;

                db.Actividades.Update(temp);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            else return View(actividad);

        }

        // GET: ActividadController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var actividad = await db.Actividades.SingleOrDefaultAsync(d => d.Id == id);
            return View(actividad);
        }

        // Accion que recibe la confirmacion para eliminar la actividad
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Actividad actividad)
        {
            var temp = await db.Actividades.SingleOrDefaultAsync(d => d.Id == id);

            if (temp != null)
            {
                db.Actividades.Remove(temp);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(temp);

        }
    }
}
