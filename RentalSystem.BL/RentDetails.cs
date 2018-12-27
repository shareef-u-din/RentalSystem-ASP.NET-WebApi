using AutoMapper;
using RentalSystem.BL.Helper;
using RentalSystem.BL.Interfaces;
using RentalSystem.DAL;
using RentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.BL
{
    public class RentDetails : IRent<RentProductsModel>
    {
        private RentProductsDAL db = null;

        public RentDetails()
        {
            db = new RentProductsDAL();
        }

        /// <summary>
        /// Used to set the product on rent for customer
        /// </summary>
        /// <param name="entity">The RentProducts class object</param>
        public RentProductsModel Insert(RentProductsModel entity)
        {
            RentProducts product = new RentProducts();
            bool status = false;
            try
            {
                product = Mapper.Map(entity, product);
                status = db.Add(product);
            }
            catch (Exception e)
            {
                Log.Fatal("BL : Exception in Insert Method inside RentDetails class", e);
            }

            if (status)
                return entity;
            else
                return null;
        }

        /// <summary>
        /// Used to get all the products of vendor currently on rent
        /// </summary>
        /// <param name="vendorId">The Id of the vendor</param>
        public IEnumerable<RentProductsModel> GetAllOnRent(int vendorId)
        {

            IEnumerable<RentProductsModel> products = null;
            DataSet ds = null;
            try
            {
                ds = db.GetAllOnRent(vendorId);
                products = ListHelper.DataSetToRentList(ds);
            }
            catch (Exception e)
            {
                Log.Fatal("BL : Exception in GetAllOnRent(vendorId) Method inside RentDetails class", e);
            }

            return products;
        }

        /// <summary>
        /// Used to get all the products  currently on rent for customer
        /// </summary>
        /// <param name="email">The Id of the vendor</param>
        public IEnumerable<RentProductsModel> GetAllOnRent(string email)
        {

            IEnumerable<RentProductsModel> products = null;
            DataSet ds = null;
            try
            {
                ds = db.GetAllOnRent(email);
                products = ListHelper.DataSetToRentList(ds);
            }
            catch (Exception e)
            {

                Log.Fatal("BL : Exception in GetAllOnRent(customerEmail) Method inside RentDetails class", e);
            }

            return products;
        }

        /// <summary>
        /// Used to check the start  and end date for productId.
        /// </summary>
        /// <param name="productId">The product Id</param>
        public int CheckDate(DateTime date, int productId,int value)
        {
            int res = 0;
            try
            {
                res = db.CheckDate(date, productId,value);
            }
            catch (Exception e)
            {
                Log.Fatal("BL : Exception in CheckDate Method inside RentDetails class", e);
            }
            return res;
        }

        /// <summary>
        /// Used to get all the new rent requests for given vendor
        /// </summary>
        /// <param name="productId">The Vendor Id, if not provided returns all Unapproved requests.</param>
        public IEnumerable<RentProductsModel> GetAllOnRentUnApproved(int vendorId)
        {
            IEnumerable<RentProductsModel> products = null;
            DataSet ds = null;
            try
            {
                ds = db.GetAllOnRentUnApproved(vendorId);
                products = ListHelper.DataSetToRentList(ds);
            }
            catch (Exception e)
            {
                Log.Fatal("BL : Exception in GetAllonRentUnApproved Method inside RentDetails class", e);
            }

            return products;
        }

        /// <summary>
        /// Used to approve the product on rent.
        /// </summary>
        /// <param name="productId">The product rent Id</param>
        public int Approve(int productId)
        {
            int res = 0;
            try
            {
                res = db.Approve(productId);
            }
            catch (Exception e)
            {
                Log.Fatal("BL : Exception in Approve Method inside RentDetails class", e);
            }
            return res;
        }

        /// <summary>
        /// Used to unapproved the products for customer.
        /// </summary>
        /// <param name="email">The unique email of customer</param>
        public IEnumerable<RentProductsModel> GetAllUnApproved(string email)
        {
            IEnumerable<RentProductsModel> products = null;
            DataSet ds = null;
            try
            {
                ds = db.GetAllOnRentUnApproved(email);
                products = ListHelper.DataSetToRentList(ds);
            }
            catch (Exception e)
            {
                Log.Fatal("BL : Exception in GetAllUnApproved Method inside RentDetails class", e);
            }

            return products;
        }
    }
}
