using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ViaroNetworksApp.Data;
using ViaroNetworksApp.Models;

namespace ViaroNetworksApp.Controllers
{
    public class AlumnoController : ApiController
    {
        // GET: api/alumno
        public IEnumerable<Alumno> Get()
        {
            return AlumnoRepository.GetAll();
        }

        // GET: api/alumno/1
        public Alumno Get(int id)
        {
            return AlumnoRepository.GetByID(id);
        }

        // POST: api/alumno
        public JObject Post([FromBody]Alumno alumno)
        {
            JObject response = new JObject
            {
                { "error", false },
                { "msg", "Alumno created successfully." }
            };

            if (!AlumnoRepository.Create(alumno))
            {
                response["error"] = true;
                response["msg"] = "Alumno not created.";
            }

            return response;
        }

        // PUT: api/alumno/5
        public JObject Put(int id, [FromBody]Alumno alumno)
        {
            alumno.ID = id;

            JObject response = new JObject
            {
                { "error", false },
                { "msg", "Alumno updated successfully." }
            };

            if(!AlumnoRepository.Update(alumno))
            {
                response["error"] = true;
                response["msg"] = "Alumno not updated.";
            }
            return response;
        }

        // DELETE: api/alumno/1
        public JObject Delete(int id)
        {
            JObject response = new JObject
            {
                { "error", false },
                { "msg", "Alumno deleted successfully." }
            };

            if(!AlumnoRepository.Delete(id))
            {
                response["error"] = true;
                response["msg"] = "Alumno not deleted.";
            }

            return response;
        }
    }
}