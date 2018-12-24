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
    public class ProductsController : ApiController
    {
        ProductDetails productDetails = null;

        public ProductsController()
        {
            productDetails = new ProductDetails();
        }

        // GET: api/Products/
        [HttpGet]
        [Route("api/products")]
        public IEnumerable<ProductModel> GetAll()
        {
            IEnumerable<ProductModel> list = null;
            try
            {
                list = productDetails.GetAll();
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in ProductsController in GetAll Method", e);
            }
            return list;
        }

        // GET: api/Products/
        [HttpGet]
        [Route("api/products/available")]
        public IEnumerable<ProductModel> GetAaivalbe()
        {
            IEnumerable<ProductModel> list = null;
            try
            {
                list = productDetails.GetAvailable();
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in ProductsController in GetAaivalbe Method", e);
            }
            return list;
        }

        // GET: api/Products/all/vendorId
        [HttpGet]
        [Route("api/products/all/{vendorId:int}")]
        public IEnumerable<ProductModel> GetAll(int vendorId)
        {
            IEnumerable<ProductModel> list = null;
            try
            {
                list = productDetails.GetAllByVendor(vendorId);
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in ProductsController in GetAllByVendor Method", e);
            }
            return list;
        }



        //GET: api/Products/GetAllCategories
        [Route("api/products/GetAllCategories")]
        [HttpGet]
        public IEnumerable<CategoryModel> GetAllCategories()
        {
            IEnumerable<CategoryModel> list = null;
            try
            {
                list = productDetails.GetCategories();
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in ProductsController in GetAllCategories Method", e);
            }
            return list;
        }


        // POST: api/Products
        [HttpPost]
        [Route("api/products")]
        public HttpResponseMessage Post(ProductModel productModel)
        {
            ProductModel prod = null;
            try
            {
                prod = productDetails.Insert(productModel);
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in ProductsController in POST:api/products Method", e);
            }
            if (prod != null)
                return Request.CreateResponse(HttpStatusCode.Created,prod);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);

        }
        //GET:api/products/productId
        [Route("api/products/{id:int}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            ProductModel prod = null;
            try
            {
                prod = productDetails.GetById(id);
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in ProductsController in POST:api/products/id Method", e);
            }
            if (prod != null)
                return Request.CreateResponse(HttpStatusCode.OK,prod);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);

        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
