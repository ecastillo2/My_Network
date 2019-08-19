using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNetwork.Models;

namespace MyNetwork.DAL
{
    [Authorize]
    public class DataAccess
    {
        public User CurrentUser = new User();
        public Contact addContact = new Contact();

        //Get Contact
        public List<Contact> retrieveContacts(string UserId)
        {

            string validateEmail = string.Empty;
            List<Contact> listofContacts = new List<Contact>();
            
            //SqlDataAdapter Adapter;
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("SP_GerUserContacts", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", UserId);


            DataTable table = new DataTable();


            using (SqlDataAdapter Adapter = new SqlDataAdapter(cmd))
            {
                Adapter.Fill(table);

                foreach (DataRow dt in table.Rows)
                {
                    Contact tt = new Contact();

                    tt.ContactID = Convert.ToString(dt["ContactID"].ToString());
                    tt.FaceBookURL = Convert.ToString(dt["ContactID"].ToString());
                    //ChildrenID = Convert.ToString(dt["ChildrenID"].ToString()),
                    //SiblingID = Convert.ToString(dt["SiblingID"].ToString()),
                    tt.AddedContactDate = Convert.ToString(dt["AddedContactDate"].ToString());
                    tt.Category = Convert.ToString(dt["Category"]);
                    tt.FirstName = Convert.ToString(dt["FirstName"]);
                    tt.LastName = Convert.ToString(dt["LastName"]);
                    tt.Age = Convert.ToString(dt["Age"]);
                    tt.Birthday = Convert.ToString(dt["Birthday"]);
                    tt.PrimaryPhone = Convert.ToString(dt["PrimaryPhone"]);
                    tt.SecondaryPhone = Convert.ToString(dt["SecondaryPhone"]);
                    tt.WorkPhone = Convert.ToString(dt["WorkPhone"]);
                    tt.Email = Convert.ToString(dt["Email"]);
                    tt.Relationship = Convert.ToString(dt["Relationship"]);
                    //SpouseFirstName = Convert.ToString(dt["SpouseFirstName"]),
                    //SpouseLastName = Convert.ToString(dt["SpouseLastName"]),
                    tt.SalaryRange = Convert.ToString(dt["SalaryRange"]);
                    tt.PrimaryOccupation = Convert.ToString(dt["PrimaryOccupation"]);
                    tt.SecondaryOccupation = Convert.ToString(dt["SecondaryOccupation"]);
                    tt.MetLocation = Convert.ToString(dt["MetLocation"]);
                    tt.NumberOfYearKnown = Convert.ToString(dt["NumberOfYearKnown"]);
                    tt.LastSpokeToDate = Convert.ToString(dt["LastSpokeToDate"]);
                    tt.WebsiteURL = Convert.ToString(dt["WebsiteURL"]);
                    tt.LinkedInURL = Convert.ToString(dt["LinkedInURL"]);
                    tt.FaceBookURL = Convert.ToString(dt["FaceBookURL"]);
                    tt.InstagramURL = Convert.ToString(dt["InstagramURL"]);
                    tt.TwitterURL = Convert.ToString(dt["TwitterURL"]);
                    tt.CompanyName = Convert.ToString(dt["CompanyName"]);
                    tt.CompanyAddress = Convert.ToString(dt["CompanyAddress"]);

                    tt.CollegeAttended = Convert.ToString(dt["CollegeAttended"]);
                    tt.HighSchoolAttended = Convert.ToString(dt["HighSchoolAttended"]);
                    tt.Degree = Convert.ToString(dt["Degree"]);
                    tt.RelationshipStatus = Convert.ToString(dt["RelationshipStatus"]);
                    tt.Hobbies = Convert.ToString(dt["Hobbies"]);
                    tt.PrimaryAddress = Convert.ToString(dt["PrimaryAddress"]);
                    tt.SecondaryAddress = Convert.ToString(dt["SecondaryAddress"]);
                    tt.InSchool = Convert.ToString(dt["InSchool"]);
                    //HasPets = Convert.ToString(dt["HasPets"]),
                    //HasSiblings = Convert.ToString(dt["HasSiblings"]),
                    //FatherFirstName = Convert.ToString(dt["FatherFirstName"]),
                    //FatherLastName = Convert.ToString(dt["FatherLastName"]),
                    //MotherFirstName = Convert.ToString(dt["MotherFirstName"]),
                    //MotherLastName = Convert.ToString(dt["MotherLastName"]),
                    tt.Skill = Convert.ToString(dt["Skill"]);
                    //BusinessCardFrontImg = Convert.ToString(dt["BusinessCardFrontImg"]),
                    //BusinessCardBackImg = Convert.ToString(dt["BusinessCardBackImg"]),
                    tt.Personality = Convert.ToString(dt["Personality"]);
                    tt.Notes = Convert.ToString(dt["Notes"]);



                    listofContacts.Add(tt);




                }

                sqlConn.Close();

                return listofContacts;
            }
        }

        //Add Contact
  


            public string InsertContacts(Contact contactInput, string UserId)
        {

            string validateEmail = string.Empty;
            List<Contact> listofContacts = new List<Contact>();

            //SqlDataAdapter Adapter;
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("SP_ContactInsert", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

            #region Perameters
            cmd.Parameters.AddWithValue("@UserID", UserId);
            //cmd.Parameters.AddWithValue("@ContactID", contactInput.ContactID);
            cmd.Parameters.AddWithValue("@AddedContactDate",DateTime.Now);
            cmd.Parameters.AddWithValue("@Category", contactInput.Category);
            cmd.Parameters.AddWithValue("@FirstName", contactInput.FirstName);
            cmd.Parameters.AddWithValue("@LastName", contactInput.LastName);
            cmd.Parameters.AddWithValue("@Age", contactInput.Age);
            cmd.Parameters.AddWithValue("@Birthday", contactInput.Birthday);
            cmd.Parameters.AddWithValue("@PrimaryPhone", contactInput.PrimaryPhone);
            cmd.Parameters.AddWithValue("@SecondaryPhone", contactInput.SecondaryPhone);
            cmd.Parameters.AddWithValue("@WorkPhone", contactInput.WorkPhone);
            cmd.Parameters.AddWithValue("@Email", contactInput.Email);
            cmd.Parameters.AddWithValue("@Relationship", contactInput.Relationship);
            //cmd.Parameters.AddWithValue("@SpouseFirstName", contactInput.SpouseFirstName);
            //cmd.Parameters.AddWithValue("@SpouseLastName", contactInput.SpouseLastName);
            cmd.Parameters.AddWithValue("@SalaryRange", contactInput.SalaryRange);
            cmd.Parameters.AddWithValue("@PrimaryOccupation", contactInput.PrimaryOccupation);
            cmd.Parameters.AddWithValue("@SecondaryOccupation", contactInput.SecondaryOccupation);
            cmd.Parameters.AddWithValue("@MetLocation", contactInput.MetLocation);
            cmd.Parameters.AddWithValue("@NumberOfYearKnown", contactInput.NumberOfYearKnown);
            cmd.Parameters.AddWithValue("@LastSpokeToDate", contactInput.LastSpokeToDate);
            cmd.Parameters.AddWithValue("@WebsiteURL", contactInput.WebsiteURL);
            cmd.Parameters.AddWithValue("@LinkedInURL", contactInput.LinkedInURL);
            cmd.Parameters.AddWithValue("@FaceBookURL", contactInput.FaceBookURL);
            cmd.Parameters.AddWithValue("@InstagramURL", contactInput.InstagramURL);
            cmd.Parameters.AddWithValue("@TwitterURL", contactInput.TwitterURL);
            cmd.Parameters.AddWithValue("@CompanyName", contactInput.CompanyName);
            cmd.Parameters.AddWithValue("@CompanyAddress", contactInput.CompanyAddress);
            //cmd.Parameters.AddWithValue("@Greek", contactInput.Group);
            cmd.Parameters.AddWithValue("@CollegeAttended", contactInput.CollegeAttended);
            cmd.Parameters.AddWithValue("@HighSchoolAttended", contactInput.HighSchoolAttended);
            cmd.Parameters.AddWithValue("@Degree", contactInput.Degree);
            cmd.Parameters.AddWithValue("@RelationshipStatus", contactInput.RelationshipStatus);
            cmd.Parameters.AddWithValue("@Hobbies", contactInput.Hobbies);
            cmd.Parameters.AddWithValue("@PrimaryAddress", contactInput.PrimaryAddress);
            cmd.Parameters.AddWithValue("@SecondaryAddress", contactInput.SecondaryAddress);
            cmd.Parameters.AddWithValue("@InSchool", contactInput.InSchool);
            //cmd.Parameters.AddWithValue("@HasPets", contactInput.HasPets);
            //cmd.Parameters.AddWithValue("@HasSiblings", contactInput.HasSiblings);
            //cmd.Parameters.AddWithValue("@FatherFirstName", contactInput.FatherFirstName);
            //cmd.Parameters.AddWithValue("@FatherLastName", contactInput.FatherLastName);
            //cmd.Parameters.AddWithValue("@MotherFirstName", contactInput.MotherFirstName);
            //cmd.Parameters.AddWithValue("@MotherLastName", contactInput.MotherLastName);
            cmd.Parameters.AddWithValue("@Skill", contactInput.Skill);
            //cmd.Parameters.AddWithValue("@BusinessCardFrontImg", contactInput.BusinessCardFrontImg);
            //cmd.Parameters.AddWithValue("@BusinessCardBackImg", contactInput.BusinessCardBackImg);
            cmd.Parameters.AddWithValue("@Personality", contactInput.Personality);
            cmd.Parameters.AddWithValue("@Notes", contactInput.Notes);

            #endregion

            cmd.ExecuteScalar();


            sqlConn.Close();

            return null;
        }

        //Delete Contact
        public string DeleteContacts(string ContactID)
        {
            string validateEmail = string.Empty;
            Contact ContactInfo = new Contact();

            //SqlDataAdapter Adapter;
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("SP_DeleteContact", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@ContactID", ContactID);

          
            cmd.ExecuteScalar();


            sqlConn.Close();

            return null;
        }

        //Update Contact

        public Contact UpdateContactInfo(Contact contactInput ,string ContactID)
        {
            string validateEmail = string.Empty;
            Contact ContactInfo = new Contact();

            //SqlDataAdapter Adapter;
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("SP_ContactUpdate", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

           
            cmd.Parameters.AddWithValue("@ContactID", ContactID);

            #region Perameters
            //cmd.Parameters.AddWithValue("@UserID", UserId);
            //cmd.Parameters.AddWithValue("@ContactID", contactInput.ContactID);
            cmd.Parameters.AddWithValue("@AddedContactDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@Category", contactInput.Category);
            cmd.Parameters.AddWithValue("@FirstName", contactInput.FirstName);
            cmd.Parameters.AddWithValue("@LastName", contactInput.LastName);
            cmd.Parameters.AddWithValue("@Age", contactInput.Age);
            cmd.Parameters.AddWithValue("@Birthday", contactInput.Birthday);
            cmd.Parameters.AddWithValue("@PrimaryPhone", contactInput.PrimaryPhone);
            cmd.Parameters.AddWithValue("@SecondaryPhone", contactInput.SecondaryPhone);
            cmd.Parameters.AddWithValue("@WorkPhone", contactInput.WorkPhone);
            cmd.Parameters.AddWithValue("@Email", contactInput.Email);
            cmd.Parameters.AddWithValue("@Relationship", contactInput.Relationship);
            //cmd.Parameters.AddWithValue("@SpouseFirstName", contactInput.SpouseFirstName);
            //cmd.Parameters.AddWithValue("@SpouseLastName", contactInput.SpouseLastName);
            cmd.Parameters.AddWithValue("@SalaryRange", contactInput.SalaryRange);
            cmd.Parameters.AddWithValue("@PrimaryOccupation", contactInput.PrimaryOccupation);
            cmd.Parameters.AddWithValue("@SecondaryOccupation", contactInput.SecondaryOccupation);
            cmd.Parameters.AddWithValue("@MetLocation", contactInput.MetLocation);
            cmd.Parameters.AddWithValue("@NumberOfYearKnown", contactInput.NumberOfYearKnown);
            cmd.Parameters.AddWithValue("@LastSpokeToDate", contactInput.LastSpokeToDate);
            cmd.Parameters.AddWithValue("@WebsiteURL", contactInput.WebsiteURL);
            cmd.Parameters.AddWithValue("@LinkedInURL", contactInput.LinkedInURL);
            cmd.Parameters.AddWithValue("@FaceBookURL", contactInput.FaceBookURL);
            cmd.Parameters.AddWithValue("@InstagramURL", contactInput.InstagramURL);
            cmd.Parameters.AddWithValue("@TwitterURL", contactInput.TwitterURL);
            cmd.Parameters.AddWithValue("@CompanyName", contactInput.CompanyName);
            cmd.Parameters.AddWithValue("@CompanyAddress", contactInput.CompanyAddress);
            //cmd.Parameters.AddWithValue("@Greek", contactInput.Group);
            cmd.Parameters.AddWithValue("@CollegeAttended", contactInput.CollegeAttended);
            cmd.Parameters.AddWithValue("@HighSchoolAttended", contactInput.HighSchoolAttended);
            cmd.Parameters.AddWithValue("@Degree", contactInput.Degree);
            cmd.Parameters.AddWithValue("@RelationshipStatus", contactInput.RelationshipStatus);
            cmd.Parameters.AddWithValue("@Hobbies", contactInput.Hobbies);
            cmd.Parameters.AddWithValue("@PrimaryAddress", contactInput.PrimaryAddress);
            cmd.Parameters.AddWithValue("@SecondaryAddress", contactInput.SecondaryAddress);
            cmd.Parameters.AddWithValue("@InSchool", contactInput.InSchool);
            //cmd.Parameters.AddWithValue("@HasPets", contactInput.HasPets);
            //cmd.Parameters.AddWithValue("@HasSiblings", contactInput.HasSiblings);
            //cmd.Parameters.AddWithValue("@FatherFirstName", contactInput.FatherFirstName);
            //cmd.Parameters.AddWithValue("@FatherLastName", contactInput.FatherLastName);
            //cmd.Parameters.AddWithValue("@MotherFirstName", contactInput.MotherFirstName);
            //cmd.Parameters.AddWithValue("@MotherLastName", contactInput.MotherLastName);
            cmd.Parameters.AddWithValue("@Skill", contactInput.Skill);
            //cmd.Parameters.AddWithValue("@BusinessCardFrontImg", contactInput.BusinessCardFrontImg);
            //cmd.Parameters.AddWithValue("@BusinessCardBackImg", contactInput.BusinessCardBackImg);
            cmd.Parameters.AddWithValue("@Personality", contactInput.Personality);
            cmd.Parameters.AddWithValue("@Notes", contactInput.Notes);

            #endregion

            cmd.ExecuteScalar();


            sqlConn.Close();

            return null;
        }

        //Get Contact
        public Contact retrieveContactsByContactID(string ContactID)
        {

            string validateEmail = string.Empty;
            Contact SelectedContacts = new Contact();

            //SqlDataAdapter Adapter;
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("SP_ContactsByContactID", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ContactID", ContactID);


            DataTable table = new DataTable();


            using (SqlDataAdapter Adapter = new SqlDataAdapter(cmd))
            {
                Adapter.Fill(table);

                foreach (DataRow dt in table.Rows)
                {



                    SelectedContacts.ContactID = Convert.ToString(dt["ContactId"].ToString());
                    //SelectedContacts.ChildrenID = Convert.ToString(dt["ChildrenID"].ToString());
                    //SelectedContacts.SiblingID = Convert.ToString(dt["SiblingID"].ToString());
                    SelectedContacts.AddedContactDate = Convert.ToString(dt["AddedContactDate"].ToString());
                    SelectedContacts.Category = Convert.ToString(dt["Category"]);
                    SelectedContacts.FirstName = Convert.ToString(dt["FirstName"]);
                    SelectedContacts.LastName = Convert.ToString(dt["LastName"]);
                    SelectedContacts.Age = Convert.ToString(dt["Age"]);
                    SelectedContacts.Birthday = Convert.ToString(dt["Birthday"]);
                    SelectedContacts.PrimaryPhone = Convert.ToString(dt["PrimaryPhone"]);
                    SelectedContacts.SecondaryPhone = Convert.ToString(dt["SecondaryPhone"]);
                    SelectedContacts.WorkPhone = Convert.ToString(dt["WorkPhone"]);
                    SelectedContacts.Email = Convert.ToString(dt["Email"]);
                    SelectedContacts.Relationship = Convert.ToString(dt["Relationship"]);
                    //SelectedContacts.SpouseFirstName = Convert.ToString(dt["SpouseFirstName"]);
                    //SelectedContacts.SpouseLastName = Convert.ToString(dt["SpouseLastName"]);
                    SelectedContacts.SalaryRange = Convert.ToString(dt["SalaryRange"]);
                    SelectedContacts.PrimaryOccupation = Convert.ToString(dt["PrimaryOccupation"]);
                    SelectedContacts.SecondaryOccupation = Convert.ToString(dt["SecondaryOccupation"]);
                    SelectedContacts.MetLocation = Convert.ToString(dt["MetLocation"]);
                    SelectedContacts.NumberOfYearKnown = Convert.ToString(dt["NumberOfYearKnown"]);
                    SelectedContacts.LastSpokeToDate = Convert.ToString(dt["LastSpokeToDate"]);
                    SelectedContacts.WebsiteURL = Convert.ToString(dt["WebsiteURL"]);
                    SelectedContacts.LinkedInURL = Convert.ToString(dt["LinkedInURL"]);
                    SelectedContacts.FaceBookURL = Convert.ToString(dt["FaceBookURL"]);
                    SelectedContacts.InstagramURL = Convert.ToString(dt["InstagramURL"]);
                    SelectedContacts.TwitterURL = Convert.ToString(dt["TwitterURL"]);
                    SelectedContacts.CompanyName = Convert.ToString(dt["CompanyName"]);
                    SelectedContacts.CompanyAddress = Convert.ToString(dt["CompanyAddress"]);
                   // SelectedContacts.Group = Convert.ToString(dt["Group"]);
                    SelectedContacts.CollegeAttended = Convert.ToString(dt["CollegeAttended"]);
                    SelectedContacts.HighSchoolAttended = Convert.ToString(dt["HighSchoolAttended"]);
                    SelectedContacts.Degree = Convert.ToString(dt["Degree"]);
                    SelectedContacts.RelationshipStatus = Convert.ToString(dt["RelationshipStatus"]);
                    SelectedContacts.Hobbies = Convert.ToString(dt["Hobbies"]);
                    SelectedContacts.PrimaryAddress = Convert.ToString(dt["PrimaryAddress"]);
                    SelectedContacts.SecondaryAddress = Convert.ToString(dt["SecondaryAddress"]);
                    SelectedContacts.InSchool = Convert.ToString(dt["InSchool"]);
                    //SelectedContacts.HasPets = Convert.ToString(dt["HasPets"]);
                    //SelectedContacts.HasSiblings = Convert.ToString(dt["HasSiblings"]);
                    //SelectedContacts.FatherFirstName = Convert.ToString(dt["FatherFirstName"]);
                    //SelectedContacts.FatherLastName = Convert.ToString(dt["FatherLastName"]);
                    //SelectedContacts.MotherFirstName = Convert.ToString(dt["MotherFirstName"]);
                    //SelectedContacts.MotherLastName = Convert.ToString(dt["MotherLastName"]);
                    SelectedContacts.Skill = Convert.ToString(dt["Skill"]);
                    //SelectedContacts.BusinessCardFrontImg = Convert.ToString(dt["BusinessCardFrontImg"]);
                    //SelectedContacts.BusinessCardBackImg = Convert.ToString(dt["BusinessCardBackImg"]);
                    SelectedContacts.Personality = Convert.ToString(dt["Personality"]);
                    SelectedContacts.Notes = Convert.ToString(dt["Notes"]);
                    

                }



            }

            sqlConn.Close();

            return SelectedContacts;
        }

        public List<string> retrieveImage(string ContactID)
        {
            string validateEmail = string.Empty;
            List<string> ig = new List<string>();

            //SqlDataAdapter Adapter;
            SqlConnection sqlConn;
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand("SP_GerContactProfileImage", sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;

           
            cmd.Parameters.AddWithValue("@ContactID", ContactID);
            

            DataTable table = new DataTable();


            using (SqlDataAdapter Adapter = new SqlDataAdapter(cmd))
            {
                Adapter.Fill(table);

                foreach (DataRow dt in table.Rows)
                {



                    ig.Add(Convert.ToString(dt["ImagePath"].ToString()));                  
                   
                   

                }



            }

            sqlConn.Close();

            return ig;
        }

    }
}
