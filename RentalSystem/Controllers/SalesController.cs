using RentalSystem.BL;
using RentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RentalSystem.Controllers
{
    public class SalesController : ApiController
    {
        RentDetails rd = null;
        public SalesController()
        {
            rd = new RentDetails();
        }
        // GET: api/Sales
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Sales/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sales
        public HttpResponseMessage Post(RentProductsModel prod)
        {
            RentProductsModel product = null;
            try
            {
                product = rd.Insert(prod);
            }
            catch (Exception e)
            {
                throw e;
            }
            if (product != null)
                return Request.CreateResponse(HttpStatusCode.Created, product);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest,"Error");

        }

        // PUT: api/Sales/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sales/5
        public void Delete(int id)
        {
        }
    }
}
