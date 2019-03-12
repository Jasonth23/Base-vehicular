using SCFV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCFV.Controllers
{
    public class HomeController : Controller
    {

        BD_CFVEntities db = new BD_CFVEntities();
        public ActionResult Index()
        {
            return View();
            //Vehiculo vehi = db.Vehiculo.SingleOrDefault(x => x.idVehiculo == 1);
            //VehiculoViewModel vm = new VehiculoViewModel();

            //vm.idVehiculo = vehi.idVehiculo;
            
        }

        public ActionResult About()
        {
            var model = db.Vehiculo.ToList();
            return View(model);

           
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}