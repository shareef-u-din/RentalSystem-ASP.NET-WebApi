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
                throw e;
            }

            if (status)
                return entity;
            else
                return null;
        }
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

                throw e;
            }

            return products;
        }

        public int CheckDate(DateTime date, int productId,int value)
        {
            int res = 0;
            try
            {
                res = db.CheckDate(date, productId,value);
            }
            catch (Exception e)
            {

                throw e;
            }
            return res;
        }

    }
}
