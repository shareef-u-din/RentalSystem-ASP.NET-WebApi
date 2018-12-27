using RentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.BL.Helper
{
    public static class ListHelper
    {
        /// <summary>
        /// Used to convert DataSet to ProductModel List
        /// </summary>
        /// <param name="dataSet">The object of type DataSet</param>
        public static IEnumerable<ProductModel> DataSetToProductList(DataSet ds)
        {
            IEnumerable<ProductModel> list = null;
            try
            {
                list = ds.Tables[0].AsEnumerable().Select(dataRow => new ProductModel
                {
                    Id = int.Parse(dataRow["Id"].ToString()),
                    VendorId = int.Parse(dataRow["VendorId"].ToString()),
                    Name = dataRow["Name"].ToString(),
                    Description = dataRow["Description"].ToString(),
                    Image1 = dataRow["Image1"].ToString(),
                    Image2 = dataRow["Image2"].ToString(),
                    Image3 = dataRow["Image3"].ToString(),
                    Availability = Convert.ToBoolean(dataRow["Availability"].ToString()),
                    StartDate = Convert.ToDateTime(dataRow["StartDate"].ToString()),
                    EndDate = Convert.ToDateTime(dataRow["EndDate"].ToString()),
                    CategoryId = int.Parse(dataRow["CategoryId"].ToString()),
                    UnitPrice = Convert.ToDouble(dataRow["UnitPrice"].ToString())
                });
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in DataSetToProductList inside BL Helper ", e);
            }
            return list;
        }


        /// <summary>
        /// Used to convert DataSet to RentProductsModel List
        /// </summary>
        /// <param name="dataSet">The object of type DataSet</param>
        public static IEnumerable<RentProductsModel> DataSetToRentList(DataSet ds)
        {
            IEnumerable<RentProductsModel> list = null;
            try
            {
                list = ds.Tables[0].AsEnumerable().Select(dataRow => new RentProductsModel
                {
                    Id = int.Parse(dataRow["Id"].ToString()),
                    VendorId = int.Parse(dataRow["VendorId"].ToString()),
                    Email = dataRow["Email"].ToString(),
                    ProductId = Convert.ToInt32(dataRow["ProductId"].ToString()),
                    Payment = Convert.ToBoolean(dataRow["Payment"].ToString()),
                    Status = Convert.ToBoolean(dataRow["Status"].ToString()),
                    TotalCost = Convert.ToDouble(dataRow["TotalCost"].ToString()),
                    StartDate = Convert.ToDateTime(dataRow["StartDate"].ToString()),
                    EndDate = Convert.ToDateTime(dataRow["EndDate"].ToString()),
                    CategoryId = int.Parse(dataRow["CategoryId"].ToString()),
                    UnitCost = Convert.ToDouble(dataRow["UnitCost"].ToString())
                });
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in DataSetToRentList inside BL Helper ", e);
            }
            return list;
        }


        /// <summary>
        /// Used to convert DataSet to UserModel List
        /// </summary>
        /// <param name="dataSet">The object of type DataSet</param>
        public static IEnumerable<UserModel> DataSetToUserList(DataSet ds)
        {
            IEnumerable<UserModel> list = null;
            try
            {
                list = ds.Tables[0].AsEnumerable().Select(dataRow => new UserModel
                {
                    Id = int.Parse(dataRow["Id"].ToString()),
                    Name = Convert.ToString(dataRow["Name"]),
                    Email = dataRow["Email"].ToString(),
                    Contact = Convert.ToString(dataRow["Contact"]),
                    Address = Convert.ToString(dataRow["Address"]),
                    Photo = Convert.ToString(dataRow["Photo"]),
                    Valid = Convert.ToBoolean(dataRow["Valid"]),
                    Age = dataRow["Age"] is DBNull ? 0 : Convert.ToInt32(dataRow["Age"]),
                    PaymentId = dataRow["PaymentId"] is DBNull ? 0 : Convert.ToInt32(dataRow["PaymentId"])
                });
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in DataSetToUserList inside BL Helper ", e);
            }
            return list;
        }

        /// <summary>
        /// Used to convert DataSet to UserLoginModel List
        /// </summary>
        /// <param name="dataSet">The object of type DataSet</param>
        public static IEnumerable<UserLoginModel> DataSetToUserLogins(DataSet ds)
        {
            IEnumerable<UserLoginModel> list = null;
            try
            {
                list = ds.Tables[0].AsEnumerable().Select(dataRow => new UserLoginModel
                {
                    Id = int.Parse(dataRow["Id"].ToString()),
                    Password = dataRow["Password"].ToString(),
                    Email = dataRow["Email"].ToString(),
                    RoleId = int.Parse(dataRow["RoleId"].ToString())
                });
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in DataSetToUserLogins inside BL Helper ", e);
            }
            return list;
        }


        /// <summary>
        /// Used to convert DataSet to Category List
        /// </summary>
        /// <param name="dataSet">The object of type DataSet</param>
        public static IEnumerable<CategoryModel> DataSetToCategoryList(DataSet ds)
        {
            IEnumerable<CategoryModel> list = null;
            try
            {
                list = ds.Tables[0].AsEnumerable().Select(dataRow => new CategoryModel
                {
                    Id = int.Parse(dataRow["Id"].ToString()),
                    Name = dataRow["Name"].ToString()
                });
            }
            catch (Exception e)
            {
                string mes = "************API LOGS**************\n";
                Log.Fatal(mes + " Exception in DataSetToCategoryList inside BL Helper ", e);
            }
            return list;
        }
    }
}
