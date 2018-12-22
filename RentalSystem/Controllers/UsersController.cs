﻿using RentalSystem.BL;
using RentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RentalSystem.Controllers
{
    public class UsersController : ApiController
    {
        AccountDetails account = null;

        public UsersController()
        {
            account = new AccountDetails();
        }

        // GET: api/Users
        [HttpGet]
        [Route("api/users")]
        public IEnumerable<UserLoginModel> Get()
        {
            return account.GetUserLogins();
        }

        //// GET: api/Users/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/AddUser
        [HttpPost]
        [Route("api/adduser")]
        public HttpResponseMessage Post(UserLoginModel userLoginModel)
        {
            UserLoginModel user = null;
            try
            {
                user = account.Registration(userLoginModel);
            }
            catch (Exception e)
            {

                throw e;
            }

            if (user != null)
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);

        }

        // POST: api/UpdateUser
        [HttpPost]
        [Route("api/Update")]
        public HttpResponseMessage Post(UserModel userModel)
        {
            UserModel user = null;
            try
            {
                user = account.UpdateUser(userModel);
            }
            catch (Exception e)
            {

                throw e;
            }

            if (user != null)
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);

        }

        // POST: api/user
        [HttpPost]
        [Route("api/user")]
        public HttpResponseMessage Login(UserLoginModel userLoginModel)
        {
            UserLoginModel user = null;
            try
            {
                user = account.Login(userLoginModel);
            }
            catch (Exception e)
            {

                throw e;
            }

            if (user != null)
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest);

        }

        // GET: api/Users/5
        public HttpResponseMessage Get(int id)
        {
            UserModel user = null;
            try
            {
                user = account.GetUser(id);
            }
            catch (Exception e)
            {

                throw e;
            }
            if (user != null)
                return Request.CreateResponse(HttpStatusCode.OK,user);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,"User with Id="+id+" was not found");
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
