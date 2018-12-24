using AutoMapper;
using RentalSystem.BL.Helper;
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
    public class AccountDetails
    {
        private UserLoginsDAL db = null;

        public AccountDetails()
        {
            db = new UserLoginsDAL();
        }
        public UserLoginModel Registration(UserLoginModel userLoginModel)
        {
            UserLogin userLogin = new UserLogin();
            Mapper.Map(userLoginModel, userLogin);
            bool status = false;
            try
            {
                status = db.Register(userLogin);
            }
            catch (Exception e)
            {

                throw e;
            }
            if (status)
                return userLoginModel;
            else
                return null;
        }

        public IEnumerable<UserModel> GetAllVendors()
        {
           IEnumerable<UserModel> list = null;
            DataSet ds = null;

            try
            {
                ds = db.GetAllVendors();
                list = ListHelper.DataSetToUserList(ds);


            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }

        public IEnumerable<UserModel> GetAllCustomers()
        {
            IEnumerable<UserModel> list = null;
            DataSet ds = null;

            try
            {
                ds = db.GetAllCustomers();
                list = ListHelper.DataSetToUserList(ds);


            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }

        public UserLoginModel Login(UserLoginModel userLoginModel)
        {
            UserLogin userLogin = new UserLogin();
            Mapper.Map(userLoginModel, userLogin);
            try
            {
                userLogin = db.Login(userLogin);
            }
            catch (Exception e)
            {

                throw e;
            }
            Mapper.Map(userLogin,userLoginModel);


            return userLoginModel;
        }


        public UserModel GetUser(string email)
        {
            UserModel userModel = null;
            DataSet ds = null;
            try
            {
                ds = db.GetUser(email);

                DataRow dataRow = ds.Tables[0].Select().First();

                userModel = new UserModel
                {
                    Id = int.Parse(dataRow["Id"].ToString()),
                    Name = dataRow["Name"].ToString(),
                    Email = dataRow["Email"].ToString(),
                    Contact = dataRow["Contact"].ToString(),
                    Address = dataRow["Address"].ToString(),
                    Photo = dataRow["Photo"].ToString(),
                    Valid = Convert.ToBoolean(dataRow["Valid"].ToString()),
                    Age = int.Parse(dataRow["Age"].ToString()),
                    PaymentId = Convert.ToInt32(dataRow["PaymentId"].ToString())
                };

            }
            catch (Exception e)
            {
                throw e;
            }
            return userModel;
        }


        public UserModel GetUser(int id)
        {
            UserModel userModel = null;
            DataSet ds = null;

            try
            {
                ds = db.GetUser(id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    userModel = new UserModel
                    {
                        Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString()),
                        Name = ds.Tables[0].Rows[0]["Name"].ToString(),
                        Email = ds.Tables[0].Rows[0]["Email"].ToString(),
                        Contact = ds.Tables[0].Rows[0]["Contact"].ToString(),
                        Address = ds.Tables[0].Rows[0]["Address"].ToString(),
                        Photo = ds.Tables[0].Rows[0]["Photo"].ToString(),
                        Valid = Convert.ToBoolean(ds.Tables[0].Rows[0]["Valid"].ToString()),
                        Age = int.Parse(ds.Tables[0].Rows[0]["Age"].ToString()),
                        PaymentId = Convert.ToInt32(ds.Tables[0].Rows[0]["PaymentId"].ToString())
                    };
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return userModel;
        }
        public UserModel UpdateUser(UserModel userModel)
        {
            int res = 0;
            try
            {
                User user = new User();
                Mapper.Map(userModel, user);
                res = db.UpdateUser(user);

            }
            catch (Exception e)
            {
                throw e;
            }
            if (res == 0)
            {
                return null;
            }
            else
            {
                return userModel;
            }

        }

        public IEnumerable<UserLoginModel> GetUserLogins()
        {
            IEnumerable<UserLoginModel> users = null;
            DataSet ds = null;
            try
            {
                ds = db.GetUserLogins();
                users = ListHelper.DataSetToUserLogins(ds);
            }
            catch (Exception e)
            {

                throw e;
            }

            return users;
        }


    }
}
