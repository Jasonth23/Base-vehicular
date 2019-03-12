using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCFV.Models
{
    public class VehiculoViewModel
    {
        public int idVehiculo { get; set; }
        public string placa { get; set; }
        public string marca { get; set; }
        public string color { get; set; }
        public string tipoLlanta { get; set; }
        public string tipoChasis { get; set; }
        public string tipoMotor { get; set; }
        public string tipoVehiculo { get; set; }
        public string poliza { get; set; }
        public bool comprado { get; set; }
        public string numFactura { get; set; }
        public double costo { get; set; }
        public bool habilitado { get; set; }
        public string descripHabilitado { get; set; }
        public string donadoPor { get; set; }
    }
}