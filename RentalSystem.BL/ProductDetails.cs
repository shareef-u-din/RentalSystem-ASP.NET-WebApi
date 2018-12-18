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

        public IEnumerable<ProductModel> GetAll()
        {
            string query = "SELECT * FROM Products WITH (NOLOCK)";
            IEnumerable<ProductModel> products = null;
            DataSet ds = null;
            try
            {
                ds = db.dbContext.GetData(query);
                products = ListHelper.DataSetToList(ds);
            }
            catch (Exception e)
            {

                throw e;
            }

            return products;
        }

        public IEnumerable<ProductModel> GetAllAvailable()
        {
            string query = "SELECT * FROM Products WITH (NOLOCK) WHERE Availability = 1";
            IEnumerable<ProductModel> products = null;
            DataSet ds = null;
            try
            {
                ds = db.dbContext.GetData(query);
                products = ListHelper.DataSetToList(ds);
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
                products = ListHelper.DataSetToList(ds);
            }
            catch (Exception e)
            {

                throw e;
            }

            return products;
        }

        public IEnumerable<ProductModel> GetAllByInRange(int startPrice, int endPrice)
        {
            IEnumerable<ProductModel> products = null;
            DataSet ds = null;
            try
            {
                ds = db.GetInRange(startPrice, endPrice);
                products = ListHelper.DataSetToList(ds);
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
                products = ListHelper.DataSetToList(ds);
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
