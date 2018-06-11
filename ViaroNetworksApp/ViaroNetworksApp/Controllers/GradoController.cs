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
    public class GradoController : ApiController
    {
        // GET: api/grado
        public IEnumerable<Grado> Get()
        {
            return GradoRepository.GetAll();
        }

        // GET: api/grado/1
        public Grado Get(int id)
        {
            return GradoRepository.GetByID(id);
        }

        // POST: api/grado
        public JObject Post([FromBody]Grado grado)
        {
            JObject response = new JObject
            {
                { "error", false },
                { "msg", "Grado created successfully." }
            };

            if (!GradoRepository.Create(grado))
            {
                response["error"] = true;
                response["msg"] = "Grado not created.";
            }

            return response;
        }

        // PUT: api/grado/5
        public JObject Put(int id, [FromBody]Grado grado)
        {
            grado.ID = id;

            JObject response = new JObject
            {
                { "error", false },
                { "msg", "Grado updated successfully." }
            };

            if(!GradoRepository.Update(grado))
            {
                response["error"] = true;
                response["msg"] = "Grado not updated.";
            }
            return response;
        }

        // DELETE: api/grado/1
        public JObject Delete(int id)
        {
            JObject response = new JObject
            {
                { "error", false },
                { "msg", "Grado deleted successfully." }
            };

            if(!GradoRepository.Delete(id))
            {
                response["error"] = true;
                response["msg"] = "Grado not deleted.";
            }

            return response;
        }
    }
}