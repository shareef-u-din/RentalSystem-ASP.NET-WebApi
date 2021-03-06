﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystem.DAL
{
    public class ProductDetialsDAL
    {
        public RsDbContext dbContext
        {
            get { return RsDbContext.Instance; }
        }
        public DataSet GetByCategory(int categoryId)
        {
            DataSet ds = null;
            string query = "SELECT * FROM Products WITH(nolock) WHERE CategoryId=@a1";
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataAdapter sda = null;
            try
            {
                using (con = dbContext.Connection())
                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@a1", categoryId);
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                }
            }
            catch (Exception sqle)
            {
                throw sqle;
            }
            finally
            {
                if (sda != null)
                    sda = null;
            }
            return ds;
        }


        public DataSet GetByVendor(int vendorId)
        {

            string query = "SELECT * FROM Products WITH(nolock) WHERE VendorId=@a1";
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataAdapter sda = null;
            DataSet ds = new DataSet();
            try
            {
                using (con = dbContext.Connection())
                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@a1", vendorId);
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                }
            }
            catch (Exception sqle)
            {
                throw sqle;
            }
            finally
            {
                if (sda != null)
                    sda = null;
            }
            return ds;
        }

        public DataSet GetAvailable()
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataAdapter sda = null;
            DataSet ds = new DataSet();
            try
            {
                using (con = dbContext.Connection())
                using (cmd = new SqlCommand("spGetAllAvailableProducts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                }
            }
            catch (Exception sqle)
            {
                throw sqle;
            }
            finally
            {
                if (sda != null)
                    sda = null;
            }
            return ds;
        }

        public bool Add(Product product)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            int rowsUpdated = 0;
            try
            {
                using (con = dbContext.Connection())
                using (cmd = new SqlCommand("spAddProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VendorId", product.VendorId);
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@Image1", product.Image1);
                    cmd.Parameters.AddWithValue("@Image2", product.Image2 == null ? "" : product.Image2);
                    cmd.Parameters.AddWithValue("@Image3", product.Image3 == null ? "" : product.Image3);
                    cmd.Parameters.AddWithValue("@Availability", product.Availability);
                    cmd.Parameters.AddWithValue("@StartDate", product.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", product.EndDate);
                    cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
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

        public bool Update(Product product)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            int rowsUpdated = 0;
            try
            {
                using (con = dbContext.Connection())
                using (cmd = new SqlCommand("spUpdateProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", product.Id);
                    cmd.Parameters.AddWithValue("@VendorId", product.VendorId);
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@Image1", product.Image1);
                    cmd.Parameters.AddWithValue("@Image2", product.Image2 == null ? "" : product.Image2);
                    cmd.Parameters.AddWithValue("@Image3", product.Image3 == null ? "" : product.Image3);
                    cmd.Parameters.AddWithValue("@Availability", product.Availability);
                    cmd.Parameters.AddWithValue("@StartDate", product.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", product.EndDate);
                    cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
                    cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
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

        public DataSet GetById(int id)
        {
            string query = "SELECT * FROM Products WITH(NOLOCK) WHERE Id=@Id";
            SqlConnection con = null;
            SqlCommand cmd = null;
            DataSet ds = null;
            SqlDataAdapter sda = null;
            try
            {
                using (con = dbContext.Connection())
                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
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

        public DataSet GetInRange(int startPrice, int endPrice)
        {
            DataSet ds = null;
            string query = "SELECT * FROM Products WITH(nolock) WHERE UnitPrice BETWEEN @start AND @end";
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataAdapter sda = null;
            try
            {
                using (con = dbContext.Connection())
                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@start", startPrice);
                    cmd.Parameters.AddWithValue("@end", endPrice);
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                }
            }
            catch (Exception sqle)
            {
                throw sqle;
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
