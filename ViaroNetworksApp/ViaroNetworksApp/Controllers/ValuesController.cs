using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using ViaroNetworksApp.DataAccess;

namespace ViaroNetworksApp.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            // SQL Connection TEST
            SqlConnection connection = DBConfig.GetInstance().GetConnection();

            SqlCommand query = new SqlCommand("SELECT * FROM Alumno;", connection);
            SqlDataReader reader = query.ExecuteReader();

            StringBuilder sb = new StringBuilder();

            while(reader.Read())
            {
                sb.Append(" [").Append(reader[1]).Append("] ");
            }
            // SQL Connection TEST

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
