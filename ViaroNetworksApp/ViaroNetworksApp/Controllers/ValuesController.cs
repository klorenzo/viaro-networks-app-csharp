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
        public IEnumerable<Alumno> Get()
        {

            AlumnoRepository alumnoRepository = new AlumnoRepository();
            

            return alumnoRepository.GetAll();
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
