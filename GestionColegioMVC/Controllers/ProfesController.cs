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
    public class ProfesController : Controller
    {
        private DireccionColegio_DBEntidades db = new DireccionColegio_DBEntidades();

        // GET: Profes
        public async Task<ActionResult> Index()
        {
            return View(await db.Profes.ToListAsync());
        }

        // GET: Profes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profe profe = await db.Profes.FindAsync(id);
            if (profe == null)
            {
                return HttpNotFound();
            }
            return View(profe);
        }

        // GET: Profes/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: Profes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Crear([Bind(Include = "IdProfe,Nombre,Apellidos")] Profe profe)
        {
            if (ModelState.IsValid)
            {
                db.Profes.Add(profe);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(profe);
        }

        // GET: Profes/Edit/5
        public async Task<ActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profe profe = await db.Profes.FindAsync(id);
            if (profe == null)
            {
                return HttpNotFound();
            }
            return View(profe);
        }

        // POST: Profes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar([Bind(Include = "IdProfe,Nombre,Apellidos")] Profe profe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profe).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(profe);
        }

        // GET: Profes/Delete/5
        public async Task<ActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profe profe = await db.Profes.FindAsync(id);
            if (profe == null)
            {
                return HttpNotFound();
            }
            return View(profe);
        }

        // POST: Profes/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Profe profe = await db.Profes.FindAsync(id);
            db.Profes.Remove(profe);
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
