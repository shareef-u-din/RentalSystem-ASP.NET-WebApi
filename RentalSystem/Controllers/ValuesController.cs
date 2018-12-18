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
    public class ValuesController : ApiController
    {
        ProductDetails p = null;
        public ValuesController()
        {
            p = new ProductDetails();
        }
        // GET api/values
        public IEnumerable<ProductModel> Get()
        {

            return p.GetAll();
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
