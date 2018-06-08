using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViaroNetworksApp.Models
{
    public class Grado
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public int ProfesorID { get; set; }
    }
}