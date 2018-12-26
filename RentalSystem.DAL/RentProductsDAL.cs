using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.DAL
{
    public class RentProductsDAL
    {
        public RsDbContext dbContext
        {
            get { return RsDbContext.Instance; }
        }
        public bool Add(RentProducts product)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            int rowsUpdated = 0;
            try
            {
                using (con = dbContext.Connection())
                using (cmd = new SqlCommand("spRentProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VendorId", product.VendorId);
                    cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                    cmd.Parameters.AddWithValue("@Email", product.Email);
                    cmd.Parameters.AddWithValue("@UnitCost", product.UnitCost);
                    cmd.Parameters.AddWithValue("@TotalCost", product.TotalCost);
                    cmd.Parameters.AddWithValue("@Payment", product.Payment);
                    cmd.Parameters.AddWithValue("@Status", product.Status);
                    cmd.Parameters.AddWithValue("@StartDate", product.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", product.EndDate);
                    cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    con.Open();
                    rowsUpdated = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            if (rowsUpdated == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int CheckDate(DateTime date, int productId, int value)
        {
            int res = -1;
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                using (con = dbContext.Connection())
                using (cmd = new SqlCommand("spCheckDate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.Parameters.AddWithValue("@value", value);
                    con.Open();
                    res = (int)cmd.ExecuteScalar();
                    con.Close();
                }
            }
            catch (Exception e)
            {

                throw e;
            }

            return res;
        }

        public DataSet GetAllOnRent(int vendorId)
        {
            string query = "";
            if (vendorId == 0)
            {
                query = "SELECT * FROM RentProducts WITH (NOLOCK)";
            }
            else
            {
                query = "SELECT * FROM RentProducts WITH (NOLOCK) WHERE Status = 'True' AND VendorId=@Id";
            }
            SqlConnection con = null;
            SqlCommand cmd = null;
            DataSet ds = null;
            SqlDataAdapter sda = null;
            try
            {
                using (con = dbContext.Connection())
                using (cmd = new SqlCommand(query, con))
                {
                    if (vendorId != 0)
                    {
                        cmd.Parameters.AddWithValue("@Id", vendorId);
                    }
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
    }
}
