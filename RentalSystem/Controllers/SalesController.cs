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
        readonly RentDetails rentDetails = null;
        public SalesController()
        {
            rentDetails = new RentDetails();
        }


        // POST: api/Sales
        public HttpResponseMessage Post(RentProductsModel prod)
        {
            RentProductsModel product = null;
            try
            {
                product = rentDetails.Insert(prod);
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in SalesController in POST:api/sales Method", e);
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

        // GET: api/Sales/Rent/vendorId
        [HttpGet]
        [Route("api/sales/rent/{vendorId?}")]
        public IEnumerable<RentProductsModel> GetAllOnRent(int vendorId = 0)
        {
            IEnumerable<RentProductsModel> list = null;
            try
            {
                list = rentDetails.GetAllOnRent(vendorId);
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in SalesController in POST:api/sales/rent/vendorId Method", e);
            }
            return list;
        }
    }
}
