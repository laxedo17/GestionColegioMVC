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
    public class MatriculasController : Controller
    {
        private DireccionColegio_DBEntidades db = new DireccionColegio_DBEntidades();

        // GET: Matriculas
        public async Task<ActionResult> Index()
        {
            var matriculas = db.Matriculas.Include(m => m.Curso).Include(m => m.Estudiante).Include(m => m.Profe);
            return View(await matriculas.ToListAsync());
        }

        // GET: Matriculas/Detalles/5
        public async Task<ActionResult> Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = await db.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: Matriculas/Crear
        public ActionResult Crear()
        {
            ViewBag.IdCurso = new SelectList(db.Cursoes, "IdCurso", "Titulo");
            ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "Nombre", "Apellido");
            ViewBag.IdProfe = new SelectList(db.Profes, "IdProfe", "Nombre", "Apellidos");
            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear([Bind(Include = "IdMatricula,Nota,IdCurso,IdEstudiante,IdProfe")] Matricula matricula)
        {
            var estaMatriculado = db.Matriculas.Any(q => q.IdCurso == matricula.IdCurso && q.IdEstudiante == matricula.IdEstudiante); //se a IdCurso e a IdEstudiante na matricula coinciden cun valor que xa hai, isto e verdadeiro, co cal debemos advertir que ese/a estudiante xa esta matriculado
            if (ModelState.IsValid && !estaMatriculado)
            {
                db.Matriculas.Add(matricula);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdCurso = new SelectList(db.Cursoes, "IdCurso", dataTextField: "Titulo", matricula.IdCurso);
            ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "Nombre", "Apellido", matricula.IdEstudiante);
            ViewBag.IdProfe = new SelectList(db.Profes, "IdProfe", "Nombre", "Apellidos", matricula.IdProfe);
            //return Json(new { IsSuccess = false, Message = "Estudiante non se engadiu con exito por non estar rexistrado na base de datos ou por estar xa matriculado noutro curso" }, JsonRequestBehavior.AllowGet);//se falla o anterior o programa pasa a estal inea indicando que algo fallou
            return View(matricula);
        }

        // GET: Matriculas/Editar/5
        public async Task<ActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = await db.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCurso = new SelectList(db.Cursoes, "IdCurso", dataTextField: "Titulo", matricula.IdCurso);
            ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "Nombre", "Apellido", matricula.IdEstudiante);
            ViewBag.IdProfe = new SelectList(db.Profes, "IdProfe", "Nombre", "Apellidos", matricula.IdProfe);
            return View(matricula);
        }

        // POST: Matriculas/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar([Bind(Include = "IdMatricula,Nota,IdCurso,IdEstudiante,IdProfe")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matricula).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdCurso = new SelectList(db.Cursoes, "IdCurso", dataTextField: "Titulo", matricula.IdCurso);
            ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "Nombre", "Apellido", matricula.IdEstudiante);
            ViewBag.IdProfe = new SelectList(db.Profes, "IdProfe", "Nombre", "Apellidos", matricula.IdProfe);
            return View(matricula);
        }

        // GET: Matriculas/Eliminar/5
        public async Task<ActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = await db.Matriculas.FindAsync(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: Matriculas/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Matricula matricula = await db.Matriculas.FindAsync(id);
            db.Matriculas.Remove(matricula);
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
