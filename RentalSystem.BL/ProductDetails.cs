using RentalSystem.BL.Interfaces;
using RentalSystem.DAL;
using RentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using RentalSystem.BL.Helper;
using AutoMapper;

namespace RentalSystem.BL
{
    public class ProductDetails : IProduct<ProductModel>
    {
        private ProductDetialsDAL db = null;
        public ProductDetails()
        {
            db = new ProductDetialsDAL();
        }

        public IEnumerable<ProductModel> GetAll(int vendorId=0)
        {
            string query = "SELECT * FROM Products WITH (NOLOCK)";
            IEnumerable<ProductModel> products = null;
            DataSet ds = null;
            try
            {
                ds = db.dbContext.GetData(query);
                products = ListHelper.DataSetToProductList(ds);
            }
            catch (Exception e)
            {

                throw e;
            }

            return products;
        }

        public IEnumerable<ProductModel> GetAllAvailable(int vendorId=0)
        {
            string query = "";
            if (vendorId == 0)
            {
                query = "SELECT * FROM Products WITH (NOLOCK) WHERE Availability = 1";
            }
            else
            {
                query = "SELECT * FROM Products WITH (NOLOCK) WHERE Availability = 1 AND VendorId="+vendorId;
            }
            IEnumerable<ProductModel> products = null;
            DataSet ds = null;
            try
            {
                ds = db.dbContext.GetData(query);
                products = ListHelper.DataSetToProductList(ds);
            }
            catch (Exception e)
            {

                throw e;
            }

            return products;
        }

        public IEnumerable<ProductModel> GetAvailable()
        {
            IEnumerable<ProductModel> products = null;
            DataSet ds = null;
            try
            {
                ds = db.GetAvailable();
                products = ListHelper.DataSetToProductList(ds);
            }
            catch (Exception e)
            {

                throw e;
            }

            return products;
        }

        public IEnumerable<ProductModel> GetAllByCategory(int categoryId)
        {
            IEnumerable<ProductModel> products = null;
            DataSet ds = null;
            try
            {
                ds = db.GetByCategory(categoryId);
                products = ListHelper.DataSetToProductList(ds);
            }
            catch (Exception e)
            {

                throw e;
            }

            return products;
        }

        public ProductModel GetById(int id)
        {
            ProductModel prodModel = null;
            DataSet ds = null;

            try
            {
                ds = db.GetById(id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    prodModel = new ProductModel
                    {
                        Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString()),
                        VendorId= int.Parse(ds.Tables[0].Rows[0]["VendorId"].ToString()),
                        Name = ds.Tables[0].Rows[0]["Name"].ToString(),
                        Description= ds.Tables[0].Rows[0]["Description"].ToString(),
                        Image1 = ds.Tables[0].Rows[0]["Image1"].ToString(),
                        Image2 = ds.Tables[0].Rows[0]["Image2"].ToString(),
                        Image3 = ds.Tables[0].Rows[0]["Image3"].ToString(),
                        EndDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndDate"].ToString()),
                        StartDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["StartDate"].ToString()),
                        Availability = Convert.ToBoolean(ds.Tables[0].Rows[0]["Availability"].ToString()),
                        CategoryId = int.Parse(ds.Tables[0].Rows[0]["CategoryId"].ToString()),
                        UnitPrice = Convert.ToInt32(ds.Tables[0].Rows[0]["UnitPrice"].ToString())
                    };
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return prodModel;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            RsDbContext db = RsDbContext.Instance;

            string query = "SELECT * FROM Category WITH(NOLOCK)";
            IEnumerable<CategoryModel> categories = null;
            DataSet ds = null;
            try
            {
                ds = db.GetData(query);
                categories = ListHelper.DataSetToCategoryList(ds);
            }
            catch (Exception e)
            {

                throw e;
            }

            return categories;
        }

        public IEnumerable<ProductModel> GetAllByInRange(int startPrice, int endPrice)
        {
            IEnumerable<ProductModel> products = null;
            DataSet ds = null;
            try
            {
                ds = db.GetInRange(startPrice, endPrice);
                products = ListHelper.DataSetToProductList(ds);
            }
            catch (Exception e)
            {

                throw e;
            }

            return products;
        }

        public IEnumerable<ProductModel> GetAllByVendor(int vendorId)
        {
            IEnumerable<ProductModel> products = null;
            DataSet ds = null;
            try
            {
                ds = db.GetByVendor(vendorId);
                products = ListHelper.DataSetToProductList(ds);
            }
            catch (Exception e)
            {
                throw e;
            }

            return products;
        }

        public ProductModel Insert(ProductModel entity)
        {
            Product product = new Product();
            bool status = false;
            try
            {
                product = Mapper.Map(entity, product);
                status = db.Add(product);
            }
            catch (Exception e)
            {
                throw e;
            }

            if (status)
                return entity;
            else
                return null;
        }


    }
}
