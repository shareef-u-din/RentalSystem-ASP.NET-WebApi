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

        public int Login(UserLogin userLogin)
        {

            int roleId = 0;
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

                    //Add the output parameter to the command object
                    SqlParameter outPutParameter = new SqlParameter();
                    outPutParameter.ParameterName = "@Result";
                    outPutParameter.SqlDbType = SqlDbType.Int;
                    outPutParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outPutParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    roleId = (int)outPutParameter.Value;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return roleId;
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
                using (cmd = new SqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    ds= new DataSet();
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
                using (cmd= new SqlCommand(query, con))
                using (sda= new SqlDataAdapter(cmd))
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
