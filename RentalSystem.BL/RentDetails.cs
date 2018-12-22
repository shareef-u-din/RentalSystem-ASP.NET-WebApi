using AutoMapper;
using RentalSystem.DAL;
using RentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.BL
{
    public class RentDetails
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
    }
}
