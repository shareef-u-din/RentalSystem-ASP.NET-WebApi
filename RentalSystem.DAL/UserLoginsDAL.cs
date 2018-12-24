using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.DAL
{
    public class UserLoginsDAL
    {
        public RsDbContext dbContext
        {
            get { return RsDbContext.Instance; }
        }

        public bool Register(UserLogin userLogin)
        {

            int result = 1;
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                using (con = dbContext.Connection())
                using (cmd = new SqlCommand("spRegistration", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", userLogin.Email);
                    cmd.Parameters.AddWithValue("@Password", userLogin.Password);
                    cmd.Parameters.AddWithValue("@RoleId", userLogin.RoleId);

                    //Add the output parameter to the command object
                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@Result";
                    outPutParameter.SqlDbType = SqlDbType.Int;
                    outPutParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outPutParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    result = (int)outPutParameter.Value;
                }
            }
            catch (Exception e)
            {

                throw e;
            }

            if (result == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public UserLogin Login(UserLogin userLogin)
        {
            int? res = 0;
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                using (con = dbContext.Connection())
                using (cmd = new SqlCommand("spLogin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", userLogin.Email);
                    cmd.Parameters.AddWithValue("@Password", userLogin.Password);
                    cmd.Parameters.AddWithValue("@RoleId", userLogin.RoleId);

                    //Add the output parameter to the command object
                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@Result";
                    outPutParameter.SqlDbType = SqlDbType.Int;
                    outPutParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outPutParameter);

                    //output parameter
                    cmd.Parameters.Add("@Image", SqlDbType.VarChar, 150);
                    cmd.Parameters["@Image"].Direction = ParameterDirection.Output;
                    con.Open();
                    res = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    int result = (int)outPutParameter.Value;
                    string image = Convert.ToString(cmd.Parameters["@Image"].Value);
                    userLogin.RoleId = result;
                    if (image == null)
                    {
                        userLogin.Password = "";
                    }
                    else
                    {
                        userLogin.Password = image;
                    }
                    if (result == -1)
                    {
                        userLogin.Id = 0;
                    }
                    else
                    {
                        userLogin.Id = res??0;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return userLogin;
        }

        public DataSet GetUser(string email)
        {
            string query = "SELECT * FROM Users WITH(NOLOCK) WHERE Email=@Email";
            SqlConnection con = null;
            SqlCommand cmd = null;
            DataSet ds = null;
            SqlDataAdapter sda = null;
            try
            {
                using (con = dbContext.Connection())
                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    ds = new DataSet();
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);

                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (sda != null)
                    sda = null;
            }
            return ds;
        }
        public DataSet GetUser(int Id)
        {
            string query = "SELECT * FROM Users WITH(NOLOCK) WHERE Id=@Id";
            SqlConnection con = null;
            SqlCommand cmd = null;
            DataSet ds = null;
            SqlDataAdapter sda = null;
            try
            {
                using (con = dbContext.Connection())
                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    ds = new DataSet();
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);

                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (sda != null)
                    sda = null;
            }
            return ds;
        }


        public int UpdateUser(User user)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            int result = 0;
            try
            {


                using (con = dbContext.Connection())
                using (cmd = new SqlCommand("spUpdateUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Contact", user.Contact);
                    cmd.Parameters.AddWithValue("@Age", user.Age);
                    cmd.Parameters.AddWithValue("@Address", user.Address);
                    cmd.Parameters.AddWithValue("@Payment", user.PaymentId);
                    cmd.Parameters.AddWithValue("@Photo", user.Photo);

                    //output parameter
                    cmd.Parameters.Add("@Result", SqlDbType.Int);
                    cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = (int)cmd.Parameters["@Result"].Value;
                    con.Close();

                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                //
            }
            return result;
        }

        public DataSet GetUserLogins()
        {
            string query = "SELECT * FROM UserLogins WITH(NOLOCK)";

            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataAdapter sda = null;
            DataSet ds = new DataSet();
            try
            {
                using (con = dbContext.Connection())
                using (cmd = new SqlCommand(query, con))
                using (sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (sda == null)
                    sda = null;
            }
            return ds;
        }
    }
}
