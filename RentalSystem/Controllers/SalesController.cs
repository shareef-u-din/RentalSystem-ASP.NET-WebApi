using RentalSystem.BL;
using RentalSystem.BL.Interfaces;
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
        readonly IRent<RentProductsModel> rentDetails = null;
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error");

        }

        // PUT: api/Sales/CheckDate
        [HttpPost]
        [Route("api/sales/CheckDate")]
        public HttpResponseMessage CheckDate(DateViewModel dvm)
        {
            int rValue = 0;

            try
            {
                rValue = rentDetails.CheckDate(dvm.date, dvm.ProductId, dvm.Value);
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in SalesController in POST:api/sales Method", e);
            }

            if (rValue > 0)
                return Request.CreateResponse(HttpStatusCode.OK, 1);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, 0);

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

        [HttpGet]
        [Route("api/sales/rent/unapproved/{vendorId?}")]
        public IEnumerable<RentProductsModel> GetAllOnRentUnApproved(int vendorId)
        {
            IEnumerable<RentProductsModel> list = null;
            try
            {
                list = rentDetails.GetAllOnRentUnApproved(vendorId);
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in SalesController in POST:api/sales/rent/vendorId Method", e);
            }
            return list;
        }

        [HttpGet]
        [Route("api/sales/rent/approve/{productId?}")]
        public HttpResponseMessage Approve(int productId)
        {
            int res = 0;
            try
            {
                res = rentDetails.Approve(productId);
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in SalesController in POST:api/sales/rent/unapproved/productId Method", e);
            }
            if (res >= 0)
                return Request.CreateResponse(HttpStatusCode.OK, 1);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, 0);
        }

        // GET: api/Sales/Rent/vendorId
        [HttpGet]
        [Route("api/sales/rent/")]
        public IEnumerable<RentProductsModel> GetAllOnRent(string email)
        {
            IEnumerable<RentProductsModel> list = null;
            try
            {
                list = rentDetails.GetAllOnRent(email);
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in SalesController in POST:api/sales/rent/vendorId Method", e);
            }
            return list;
        }

        // GET: api/Sales/Rent/vendorId
        [HttpGet]
        [Route("api/sales/rent/approve")]
        public IEnumerable<RentProductsModel> GetAllUnApproved(string email)
        {
            IEnumerable<RentProductsModel> list = null;
            try
            {
                list = rentDetails.GetAllUnApproved(email);
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
