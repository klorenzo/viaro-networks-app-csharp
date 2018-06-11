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
    public class AlumnoGradoController : ApiController
    {
        // GET: api/alumnogrado
        public IEnumerable<AlumnoGrado> Get()
        {
            return AlumnoGradoRepository.GetAll();
        }

        // GET: api/alumnogrado/1
        public AlumnoGrado Get(int id)
        {
            return AlumnoGradoRepository.GetByID(id);
        }

        // POST: api/alumnogrado
        public JObject Post([FromBody]AlumnoGrado alumnoGrado)
        {
            JObject response = new JObject
            {
                { "error", false },
                { "msg", "AlumnoGrado created successfully." }
            };

            if (!AlumnoGradoRepository.Create(alumnoGrado))
            {
                response["error"] = true;
                response["msg"] = "AlumnoGrado not created.";
            }

            return response;
        }

        // PUT: api/alumnogrado/5
        public JObject Put(int id, [FromBody]AlumnoGrado alumnoGrado)
        {
            alumnoGrado.ID = id;

            JObject response = new JObject
            {
                { "error", false },
                { "msg", "AlumnoGrado updated successfully." }
            };

            if(!AlumnoGradoRepository.Update(alumnoGrado))
            {
                response["error"] = true;
                response["msg"] = "AlumnoGrado not updated.";
            }
            return response;
        }

        // DELETE: api/alumnogrado/1
        public JObject Delete(int id)
        {
            JObject response = new JObject
            {
                { "error", false },
                { "msg", "AlumnoGrado deleted successfully." }
            };

            if(!AlumnoGradoRepository.Delete(id))
            {
                response["error"] = true;
                response["msg"] = "AlumnoGrado not deleted.";
            }

            return response;
        }
    }
}