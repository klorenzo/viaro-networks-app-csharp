using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViaroNetworksApp.Models
{
    public class AlumnoGrado
    {
        public int ID { get; set; }

        public int AlumnoID { get; set; }

        public int GradoID { get; set; }

        public string Seccion { get; set; }
    }
}