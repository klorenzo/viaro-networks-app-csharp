using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ViaroNetworksApp.Models;

namespace ViaroNetworksApp.Data
{
    public class AlumnoRepository
    {
        public List<Alumno> GetAll()
        {
            List<Alumno> alumnos = new List<Alumno>();

            using (SqlConnection connection = DBConfig.GetInstance().GetConnection())
            {
                
            }

            return null;
        }
    }
}