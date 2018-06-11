using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using ViaroNetworksApp.Data;
using ViaroNetworksApp.Models;

namespace ViaroNetworksApp.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            // SQL Connection TEST
            /*SqlConnection connection = DBConfig.GetInstance().GetConnection();

            SqlCommand query = new SqlCommand("SELECT * FROM Alumno;", connection);
            SqlDataReader reader = query.ExecuteReader();

            StringBuilder sb = new StringBuilder();

            while(reader.Read())
            {
                sb.Append(" [").Append(reader[1]).Append("] ");
            }*/
            // SQL Connection TEST

            AlumnoRepository alumnoRepository = new AlumnoRepository();
            List<Alumno> alumnos = alumnoRepository.GetAll();

            StringBuilder sb = new StringBuilder();

            foreach (Alumno alumno in alumnos)
            {
                sb.Append(alumno.ID + " - " + alumno.Nombre + " - " + alumno.Apellidos + " - " + alumno.Genero + " - " + alumno.FechaDeNacimiento);
            }

            return new string[] { "value1", sb.ToString() };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
