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



        // GET: api/Vendor
        [Route("api/vendors")]
        public IEnumerable<UserModel> Get()
        {
            IEnumerable<UserModel> list = null;
            try
            {
                list = account.GetAllVendors();
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in VendorController in Get(api/vendors) Method", e);
            }
            return list;
        }
        // GET: api/Customer
        [Route("api/customers")]
        public IEnumerable<UserModel> GetCustomers()
        {
            IEnumerable<UserModel> list = null;
            try
            {
                list = account.GetAllCustomers();
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in VendorController in GetCustomers(api/customers) Method", e);
            }
            return list;
        }


    }
}
