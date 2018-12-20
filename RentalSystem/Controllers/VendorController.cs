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
    public class VendorController : ApiController
    {
       readonly AccountDetails account = null;

        public VendorController()
        {
            account = new AccountDetails();
        }



        // GET: api/Vendor/5
        public string Get(int id)
        {
            return "value";
        }



        // PUT: api/Vendor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vendor/5
        public void Delete(int id)
        {
        }
    }
}
