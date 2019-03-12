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
    public class ReparacionController : Controller
    {
        private BD_CFVEntities db = new BD_CFVEntities();

        // GET: Reparacion
        public ActionResult Index()
        {
            var reparaciones = db.Reparaciones.Include(r => r.Conductor).Include(r => r.Taller).Include(r => r.Vehiculo);
            return View(reparaciones.ToList());
        }

        // GET: Reparacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparaciones reparaciones = db.Reparaciones.Find(id);
            if (reparaciones == null)
            {
                return HttpNotFound();
            }
            return View(reparaciones);
        }

        // GET: Reparacion/Create
        public ActionResult Create()
        {
            ViewBag.idConductor = new SelectList(db.Conductor, "idConductor", "nombreChofer");
            ViewBag.tallerId = new SelectList(db.Taller, "idTaller", "cedJuridica");
            ViewBag.idVehiculo = new SelectList(db.Vehiculo, "idVehiculo", "placa");
            return View();
        }

        // POST: Reparacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reparacionId,tallerId,fecha,costoTotal,descripcion,montoReserva,kmInicial,kmFinal,numFactura,idConductor,idVehiculo")] Reparaciones reparaciones)
        {
            if (ModelState.IsValid)
            {
                db.Reparaciones.Add(reparaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idConductor = new SelectList(db.Conductor, "idConductor", "nombreChofer", reparaciones.idConductor);
            ViewBag.tallerId = new SelectList(db.Taller, "idTaller", "cedJuridica", reparaciones.tallerId);
            ViewBag.idVehiculo = new SelectList(db.Vehiculo, "idVehiculo", "placa", reparaciones.idVehiculo);
            return View(reparaciones);
        }

        // GET: Reparacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparaciones reparaciones = db.Reparaciones.Find(id);
            if (reparaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.idConductor = new SelectList(db.Conductor, "idConductor", "nombreChofer", reparaciones.idConductor);
            ViewBag.tallerId = new SelectList(db.Taller, "idTaller", "cedJuridica", reparaciones.tallerId);
            ViewBag.idVehiculo = new SelectList(db.Vehiculo, "idVehiculo", "placa", reparaciones.idVehiculo);
            return View(reparaciones);
        }

        // POST: Reparacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reparacionId,tallerId,fecha,costoTotal,descripcion,montoReserva,kmInicial,kmFinal,numFactura,idConductor,idVehiculo")] Reparaciones reparaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reparaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idConductor = new SelectList(db.Conductor, "idConductor", "nombreChofer", reparaciones.idConductor);
            ViewBag.tallerId = new SelectList(db.Taller, "idTaller", "cedJuridica", reparaciones.tallerId);
            ViewBag.idVehiculo = new SelectList(db.Vehiculo, "idVehiculo", "placa", reparaciones.idVehiculo);
            return View(reparaciones);
        }

        // GET: Reparacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reparaciones reparaciones = db.Reparaciones.Find(id);
            if (reparaciones == null)
            {
                return HttpNotFound();
            }
            return View(reparaciones);
        }

        // POST: Reparacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reparaciones reparaciones = db.Reparaciones.Find(id);
            db.Reparaciones.Remove(reparaciones);
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
