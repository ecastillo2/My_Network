using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MyNetwork.Models;

namespace MyNetwork.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public User CurrentUser = new User();

        public static string id = "";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autherize(string Email, string Password)
        {

            //Check if email is in the databasee

            SqlDataAdapter AdapterEC;
            SqlConnection sqlConnEC;
            sqlConnEC = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            sqlConnEC.Open();
            SqlCommand cmdEC = new SqlCommand("sp_CheckEmail", sqlConnEC);
            cmdEC.CommandType = CommandType.StoredProcedure;
            cmdEC.Parameters.AddWithValue("@Email", Email);

            //SqlDataReader reader = cmd.ExecuteReader();
            AdapterEC = new SqlDataAdapter(cmdEC);
            DataSet dsEC = new DataSet();
            AdapterEC.Fill(dsEC);

            object check = cmdEC.ExecuteScalar();
            int checkEmail = Convert.ToInt32(check);
            if (checkEmail == 1)
            {



                //if (ClientId == null)
                //{

                //    Client.password = Password;
                //    Client.clientId = ClientId;
                //}


                List<string> list = new List<string>();
                SqlDataAdapter Adapter;
                SqlConnection sqlConn;
                sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("sp_UserLogin ", sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);


                //SqlDataReader reader = cmd.ExecuteReader();
                Adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                Adapter.Fill(ds);

                // use formasauthentication class to set the cookie
                //FormsAuthentication.SetAuthCookie(CurrentUser._user_id, true);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        CurrentUser.UserID = dr["UserID"].ToString();
                        
                        
                        


                        ViewBag.id = CurrentUser.UserID;
                        //ViewBag.id = dr["first_name"].ToString(); ;

                        FormsAuthentication.SetAuthCookie(CurrentUser.UserID, true);
                    }
                }
                //User.user_id = id.ToString();
                //string u = id.To.String();

                //user.user_id = u;

                if (ViewBag.id != null)
                {

                    FormsAuthentication.SetAuthCookie(CurrentUser.UserID, true);
                    return RedirectToAction("Contacts", "Contacts", ViewBag.id);
                }
                else
                {
                    TempData["Message"] = string.Format("Email or Password is incorrect");

                    return RedirectToAction("Index", "Home");

                }

            }
            else
            {

                TempData["Message"] = string.Format("Email is not in the database");


                return RedirectToAction("Index", "Home");

            }
        }

    }
}