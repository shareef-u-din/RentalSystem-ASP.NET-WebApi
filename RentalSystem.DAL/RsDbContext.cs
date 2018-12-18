using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace RentalSystem.DAL
{
    public sealed class RsDbContext
    {
        private static readonly Lazy<RsDbContext> lazy =
        new Lazy<RsDbContext>(() => new RsDbContext());

        public static RsDbContext Instance { get { return lazy.Value; } }

        private RsDbContext()
        {
        }

        public SqlConnection Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RsDbContext"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
            }
            catch (Exception sqle)
            {

                throw sqle;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return con;

        }
        public DataSet GetData(string query)
        {

            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataAdapter sda = null;
            DataSet ds = new DataSet();
            try
            {
                using (con = Connection())
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
            return ds;
        }

    }
}
