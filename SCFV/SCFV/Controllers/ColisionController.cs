using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCFV.Models;

namespace SCFV.Controllers
{
    public class ColisionController : Controller
    {
        private BD_CFVEntities db = new BD_CFVEntities();

        // GET: Colision
        public ActionResult Index()
        {
            var colisiones = db.Colisiones.Include(c => c.Conductor).Include(c => c.Vehiculo);
            return View(colisiones.ToList());
        }

        // GET: Colision/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colisiones colisiones = db.Colisiones.Find(id);
            if (colisiones == null)
            {
                return HttpNotFound();
            }
            return View(colisiones);
        }

        // GET: Colision/Create
        public ActionResult Create()
        {
            ViewBag.idConductor = new SelectList(db.Conductor, "idConductor", "nombreChofer");
            ViewBag.idVehiculo = new SelectList(db.Vehiculo, "idVehiculo", "placa");
            return View();
        }

        // POST: Colision/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idColision,idConductor,idVehiculo,fechaColision,descripcion,sentenciaFirme,avisoAccidente,seguro")] Colisiones colisiones)
        {
            if (ModelState.IsValid)
            {
                db.Colisiones.Add(colisiones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idConductor = new SelectList(db.Conductor, "idConductor", "nombreChofer", colisiones.idConductor);
            ViewBag.idVehiculo = new SelectList(db.Vehiculo, "idVehiculo", "placa", colisiones.idVehiculo);
            return View(colisiones);
        }

        // GET: Colision/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colisiones colisiones = db.Colisiones.Find(id);
            if (colisiones == null)
            {
                return HttpNotFound();
            }
            ViewBag.idConductor = new SelectList(db.Conductor, "idConductor", "nombreChofer", colisiones.idConductor);
            ViewBag.idVehiculo = new SelectList(db.Vehiculo, "idVehiculo", "placa", colisiones.idVehiculo);
            return View(colisiones);
        }

        // POST: Colision/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idColision,idConductor,idVehiculo,fechaColision,descripcion,sentenciaFirme,avisoAccidente,seguro")] Colisiones colisiones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colisiones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idConductor = new SelectList(db.Conductor, "idConductor", "nombreChofer", colisiones.idConductor);
            ViewBag.idVehiculo = new SelectList(db.Vehiculo, "idVehiculo", "placa", colisiones.idVehiculo);
            return View(colisiones);
        }

        // GET: Colision/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colisiones colisiones = db.Colisiones.Find(id);
            if (colisiones == null)
            {
                return HttpNotFound();
            }
            return View(colisiones);
        }

        // POST: Colision/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colisiones colisiones = db.Colisiones.Find(id);
            db.Colisiones.Remove(colisiones);
            db.SaveChanges();
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
