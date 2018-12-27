using RentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.BL.Interfaces
{
    public interface IAccount
    {
        /// <summary>
        /// Used to register a new user
        /// </summary>
        /// <param name="userLoginModel">The UserLoginModel object</param>
        UserLoginModel Registration(UserLoginModel userLoginModel);

        /// <summary>
        /// Used to get all the vendors
        /// </summary>
        IEnumerable<UserModel> GetAllVendors();

        /// <summary>
        /// Used to get all the customers
        /// </summary>
        IEnumerable<UserModel> GetAllCustomers();

        /// <summary>
        /// Used to login an already registered user
        /// </summary>
        /// <param name="userLoginModel">The UserLoginModel object</param>
        UserLoginModel Login(UserLoginModel userLoginModel);

        /// <summary>
        /// Used to retrieve user by email
        /// </summary>
        /// <param name="email">The email of user</param>
        UserModel GetUser(string email);

        /// <summary>
        /// Used to retrieve user by Id
        /// </summary>
        /// <param name="Id">The Id of user</param>
        UserModel GetUser(int id);

        /// <summary>
        /// Used to update user details
        /// </summary>
        /// <param name="userModel">The Id of user</param>
        UserModel UpdateUser(UserModel userModel);

        /// <summary>
        /// Used to retrieve all the registered users
        /// </summary>
        IEnumerable<UserLoginModel> GetUserLogins();
    }
}
