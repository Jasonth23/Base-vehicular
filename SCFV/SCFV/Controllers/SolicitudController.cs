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
    public class SolicitudController : Controller
    {
        private BD_CFVEntities db = new BD_CFVEntities();

        // GET: Solicitud
        public ActionResult Index()
        {
            var solicitud = db.Solicitud.Include(s => s.Conductor).Include(s => s.Usuario).Include(s => s.Vehiculo);
            return View(solicitud.ToList());
        }

        // GET: Solicitud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = db.Solicitud.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return View(solicitud);
        }

        // GET: Solicitud/Create
        public ActionResult Create()
        {
            ViewBag.idConductor = new SelectList(db.Conductor, "idConductor", "nombreChofer");
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nomUsuario");
            ViewBag.idVehiculo = new SelectList(db.Vehiculo, "idVehiculo", "placa");
            return View();
        }

        // POST: Solicitud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSolicitud,idUsuario,idVehiculo,idConductor,nombreSolicitante,nomDeparta,destino,justificacionSalida,fechaSolicitud,fechaSalida,fechaEntrada,numConsecutivo,funcionarioViaja,observaciones,estado")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                db.Solicitud.Add(solicitud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idConductor = new SelectList(db.Conductor, "idConductor", "nombreChofer", solicitud.idConductor);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nomUsuario", solicitud.idUsuario);
            ViewBag.idVehiculo = new SelectList(db.Vehiculo, "idVehiculo", "placa", solicitud.idVehiculo);
            return View(solicitud);
        }

        // GET: Solicitud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = db.Solicitud.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            ViewBag.idConductor = new SelectList(db.Conductor, "idConductor", "nombreChofer", solicitud.idConductor);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nomUsuario", solicitud.idUsuario);
            ViewBag.idVehiculo = new SelectList(db.Vehiculo, "idVehiculo", "placa", solicitud.idVehiculo);
            return View(solicitud);
        }

        // POST: Solicitud/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSolicitud,idUsuario,idVehiculo,idConductor,nombreSolicitante,nomDeparta,destino,justificacionSalida,fechaSolicitud,fechaSalida,fechaEntrada,numConsecutivo,funcionarioViaja,observaciones,estado")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idConductor = new SelectList(db.Conductor, "idConductor", "nombreChofer", solicitud.idConductor);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "nomUsuario", solicitud.idUsuario);
            ViewBag.idVehiculo = new SelectList(db.Vehiculo, "idVehiculo", "placa", solicitud.idVehiculo);
            return View(solicitud);
        }

        // GET: Solicitud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = db.Solicitud.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return View(solicitud);
        }

        // POST: Solicitud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitud solicitud = db.Solicitud.Find(id);
            db.Solicitud.Remove(solicitud);
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
