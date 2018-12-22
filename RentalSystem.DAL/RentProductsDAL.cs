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
    }
}
