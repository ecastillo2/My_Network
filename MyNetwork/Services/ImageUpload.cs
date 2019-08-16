using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MyNetwork.Models;

namespace MyNetwork.Services
{
    public class ImageUpload
    {

        public void SaveImage(Image ig, string ContactID)
        {
            string validateEmail = string.Empty;
            List<Contact> listofContacts = new List<Contact>();

            //SqlDataAdapter Adapter;
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("SP_ImageInsert", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Perameters
            cmd.Parameters.AddWithValue("@ContactID", ContactID);
            
            cmd.Parameters.AddWithValue("@Title", ig.Title);
            cmd.Parameters.AddWithValue("@ImagePath", ig.ImagePath);
            cmd.Parameters.AddWithValue("@ImageType", ig.ImageType);


            #endregion

            cmd.ExecuteScalar();


            sqlConn.Close();

            
        }


    }
}