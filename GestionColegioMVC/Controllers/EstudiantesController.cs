using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionColegioMVC.Models;

namespace GestionColegioMVC.Controllers
{
    //[Authorize(Roles = "Profe, Admin")] //restriccion para TODO este controlador, para que non todo o mundo poida ver todas as opcions de estudiantes, neste caso solo as poderan ver os Admins e Profesorado
    public class EstudiantesController : Controller
    {
        private DireccionColegio_DBEntidades db = new DireccionColegio_DBEntidades();

        // GET: Estudiantes
        [AllowAnonymous] //Aqui rectificamos Authorize para permitir que calquera persona poida ver a lista de estudiantes pero se non esta rexistrada, non pode crear matricula e demais
        public async Task<ActionResult> Index()
        {
            return View(await db.Estudiantes.ToListAsync());
        }

        // GET: Estudiantes/Detalles/5
        public async Task<ActionResult> Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = await db.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear([Bind(Include = "IdEstudiante,Apellido,Nombre,FechaMatriculacion,SegundoNombre")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Estudiantes.Add(estudiante);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Editar/5
        public async Task<ActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = await db.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar([Bind(Include = "IdEstudiante,Apellido,Nombre,FechaMatriculacion,SegundoNombre")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiante).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Borrar/5
        public async Task<ActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = await db.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Borrar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Estudiante estudiante = await db.Estudiantes.FindAsync(id);
            db.Estudiantes.Remove(estudiante);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
