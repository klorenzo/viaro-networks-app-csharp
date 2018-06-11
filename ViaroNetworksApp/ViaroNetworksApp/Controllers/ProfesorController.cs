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
    public class ProfesorController : ApiController
    {
        // GET: api/profesor
        public IEnumerable<Profesor> Get()
        {
            return ProfesorRepository.GetAll();
        }

        // GET: api/profesor/1
        public Profesor Get(int id)
        {
            return ProfesorRepository.GetByID(id);
        }

        // POST: api/profesor
        public JObject Post([FromBody]Profesor profesor)
        {
            JObject response = new JObject
            {
                { "error", false },
                { "msg", "Profesor created successfully." }
            };

            if (!ProfesorRepository.Create(profesor))
            {
                response["error"] = true;
                response["msg"] = "Profesor not created.";
            }

            return response;
        }

        // PUT: api/profesor/5
        public JObject Put(int id, [FromBody]Profesor profesor)
        {
            profesor.ID = id;

            JObject response = new JObject
            {
                { "error", false },
                { "msg", "Profesor updated successfully." }
            };

            if(!ProfesorRepository.Update(profesor))
            {
                response["error"] = true;
                response["msg"] = "Profesor not updated.";
            }
            return response;
        }

        // DELETE: api/profesor/1
        public JObject Delete(int id)
        {
            JObject response = new JObject
            {
                { "error", false },
                { "msg", "Profesor deleted successfully." }
            };

            if(!ProfesorRepository.Delete(id))
            {
                response["error"] = true;
                response["msg"] = "Profesor not deleted.";
            }

            return response;
        }
    }
}