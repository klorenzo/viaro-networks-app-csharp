using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViaroNetworksApp.Models
{
    public class Alumno
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Genero { get; set; }

        public DateTime FechaDeNacimiento { get; set; }
    }
}