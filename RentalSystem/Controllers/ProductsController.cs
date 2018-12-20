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
        ProductDetails p = null;

        public ProductsController()
        {
            p = new ProductDetails();
        }

        // GET: api/Products
        [HttpGet]
        [Route("api/products")]
        public IEnumerable<ProductModel> Get()
        {
            return p.GetAll();
        }

        //GET: api/Products/GetAllCategories
        [Route("api/products/GetAllCategories")]
        [HttpGet]
        public IEnumerable<CategoryModel> GetAllCategories()
        {
            IEnumerable<CategoryModel> list = null;
            try
            {
                list = p.GetCategories();
            }
            catch (Exception e)
            {

                throw e;
            }
            return list;
        }

        //// GET: api/Products/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Products
        [HttpPost]
        [Route("api/products")]
        public HttpResponseMessage Post(ProductModel productModel)
        {
            ProductModel prod = null;
            try
            {
                prod = p.Insert(productModel);
            }
            catch (Exception e)
            {
                throw e;
            }
            if (prod != null)
                return Request.CreateResponse(HttpStatusCode.Created);
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
