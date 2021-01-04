//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using GestionColegioMVC.Models;

//namespace GestionColegioMVC.Controllers
//{
//    public class MatriculasController : Controller
//    {
//        private DireccionColegio_DBEntidades db = new DireccionColegio_DBEntidades();

//        // GET: Matriculas
//        public async Task<ActionResult> Index()
//        {
//            var matriculas = db.Matriculas.Include(m => m.Curso).Include(m => m.Estudiante).Include(m => m.Profe);//Esta xa cambia totalmente respecto os outros controladores, e ten Include porque cada include leva a clave de calquer entidade relacionada no modelo entidade relacion
//            return View(await matriculas.ToListAsync());
//        }

//        public PartialViewResult _matriculasPartial(int? idCurso)
//        {
//            var matriculas = db.Matriculas.Where(q => q.IdCurso == idCurso)
//                .Include(m => m.Curso)
//                .Include(m => m.Estudiante);
//            return PartialView(matriculas.ToList());
//        }

//        // GET: Matriculas/Detalles/5
//        public async Task<ActionResult> Detalles(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Matricula matricula = await db.Matriculas.FindAsync(id);
//            if (matricula == null)
//            {
//                return HttpNotFound();
//            }
//            return View(matricula);
//        }

//        // GET: Matriculas/Crear
//        //Este metodo tamen cambia respecto a metodos similares noutras taboas. Aqui inclue os elementos da BD en menus desplegables (dropdown list)
//        public ActionResult Crear()
//        {
//            ViewBag.IdCurso = new SelectList(db.Cursoes, "IdCurso", "Titulo");
//            ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "Nombre");
//            ViewBag.IdProfe = new SelectList(db.Profes, "IdProfe", "Nombre");
//            return View();
//        }

//        // POST: Matriculas/Crear
//        // Para protexer de ataques de overposting, podense activar as propiedades especificas as que queremos asociar coa Base de Datos, 
//        // para mais detalles mira https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Crear([Bind(Include = "IdMatricula,Nota,IdCurso,IdEstudiante,IdProfe")] Matricula matricula)
//        {

//            if (ModelState.IsValid)
//            {
//                db.Matriculas.Add(matricula);
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }

//            ViewBag.IdCurso = new SelectList(db.Cursoes, "IdCurso", "Titulo", matricula.IdCurso);
//            ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "Apellido", matricula.IdEstudiante);
//            ViewBag.IdProfe = new SelectList(db.Profes, "IdProfe", "Nombre", matricula.IdProfe);
//            return View(matricula);
//        }

//        [HttpPost]
//        public async Task<JsonResult> AgregarEstudiante([Bind(Include = "IdCurso,IdEstudiante")] Matricula matricula)
//        {
//            try
//            {
//                var estaMatriculado = db.Matriculas.Any(q => q.IdCurso == matricula.IdCurso && q.IdEstudiante == matricula.IdEstudiante); //se a IdCurso e a IdEstudiante na matricula coinciden cun valor que xa hai, isto e verdadeiro, co cal debemos advertir que ese/a estudiante xa esta matriculado
//                if (ModelState.IsValid && !estaMatriculado) //tb vale escribir estaMatriculado == false
//                {
//                    db.Matriculas.Add(matricula);
//                    await db.SaveChangesAsync();
//                    return Json(new { IsSuccess = true, Message = "Estudiante engadido con exito" }, JsonRequestBehavior.AllowGet);
//                }
//                return Json(new { IsSuccess = false, Message = "Estudiante non se engadiu con exito por non estar rexistrado na base de datos ou por estar xa matriculado noutro curso" }, JsonRequestBehavior.AllowGet);//se falla o anterior o programa pasa a estal inea indicando que algo fallou
//            }
//            catch (Exception)
//            {
//                return Json(new { IsSuccess = false, Message = "Fallo do sistema, por favor contacta co administrador" }, JsonRequestBehavior.AllowGet);//s
//            }
//        }

//        // GET: Matriculas/Editar/5
//        public async Task<ActionResult> Editar(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Matricula matricula = await db.Matriculas.FindAsync(id);
//            if (matricula == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.IdCurso = new SelectList(db.Cursoes, "IdCurso", "Titulo", matricula.IdCurso);
//            ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "Apellido", matricula.IdEstudiante);
//            ViewBag.IdProfe = new SelectList(db.Profes, "IdProfe", "Nombre", matricula.IdProfe);
//            return View(matricula);
//        }

//        // POST: Matriculas/Eliminar/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Editar([Bind(Include = "IdMatricula,Nota,IdCurso,IdEstudiante,IdProfe")] Matricula matricula)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(matricula).State = EntityState.Modified;
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            ViewBag.IdCurso = new SelectList(db.Cursoes, "IdCurso", "Titulo", matricula.IdCurso);
//            ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "Apellido", matricula.IdEstudiante);
//            ViewBag.IdProfe = new SelectList(db.Profes, "IdProfe", "Nombre", matricula.IdProfe);
//            return View(matricula);
//        }

//        // GET: Matriculas/Eliminar/5
//        public async Task<ActionResult> Eliminar(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Matricula matricula = await db.Matriculas.FindAsync(id);
//            if (matricula == null)
//            {
//                return HttpNotFound();
//            }
//            return View(matricula);
//        }

//        // POST: Matriculas/Eliminar/5
//        [HttpPost, ActionName("Eliminar")]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> DeleteConfirmed(int id)
//        {
//            Matricula matricula = await db.Matriculas.FindAsync(id);
//            db.Matriculas.Remove(matricula);
//            await db.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

//        /// <summary>
//        /// Esta funcion e para crear un metodo HttpPost cara o script jquery, que lle pasa un parametro chamado term no script de jquery
//        /// </summary>
//        /// <param name="disposing"></param>
//        [HttpPost]
//        public JsonResult GetEstudiantes(string term)
//        {
//            var estudiantes = db.Estudiantes.Select(q => new
//            {
//                Nombre = q.Nombre + " " + q.Apellido,
//                Id = q.IdEstudiante
//            }).Where(q => q.Nombre.Contains(term)); //crea un obxeto que crear un novo obxeto do que seleccinamos as propiedades que queiramos, e obten unha lista abstracta de estudiantes na que tamen iran os apelidos par facer a busqueda de jquery mais completa

//            return Json(estudiantes, JsonRequestBehavior.AllowGet);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}

