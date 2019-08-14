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


                    listofContacts.Add(new Contact
                    {
                        ContactID = Convert.ToString(dt["ContactId"].ToString()),                       
                        ChildrenID = Convert.ToString(dt["ChildrenID"].ToString()),
                        SiblingID = Convert.ToString(dt["SiblingID"].ToString()),
                        AddedContactDate = Convert.ToString(dt["AddedContactDate"].ToString()),
                        Category = Convert.ToString(dt["Category"]),
                        FirstName = Convert.ToString(dt["FirstName"]),
                        LastName = Convert.ToString(dt["LastName"]),
                        Age = Convert.ToString(dt["Age"]),
                        Birthday = Convert.ToString(dt["Birthday"]),
                        PrimaryPhone = Convert.ToString(dt["PrimaryPhone"]),
                        SecondaryPhone = Convert.ToString(dt["SecondaryPhone"]),
                        WorkPhone = Convert.ToString(dt["WorkPhone"]),
                        Email = Convert.ToString(dt["Email"]),
                        Relationship = Convert.ToString(dt["Relationship"]),
                        SpouseFirstName = Convert.ToString(dt["SpouseFirstName"]),
                        SpouseLastName = Convert.ToString(dt["SpouseLastName"]),
                        SalaryRange = Convert.ToString(dt["SalaryRange"]),
                        PrimaryOccupation = Convert.ToString(dt["PrimaryOccupation"]),
                        SecondaryOccupation = Convert.ToString(dt["SecondaryOccupation"]),
                        MetLocation = Convert.ToString(dt["MetLocation"]),
                        NumberOfYearKnown = Convert.ToString(dt["NumberOfYearKnown"]),
                        LastSpokeToDate = Convert.ToString(dt["LastSpokeToDate"]),
                        WebsiteURL = Convert.ToString(dt["WebsiteURL"]),
                        LinkedInURL = Convert.ToString(dt["LinkedInURL"]),
                        FaceBookURL = Convert.ToString(dt["FaceBookURL"]),
                        InstagramURL = Convert.ToString(dt["InstagramURL"]),
                        TwitterURL = Convert.ToString(dt["TwitterURL"]),
                        CompanyName = Convert.ToString(dt["CompanyName"]),
                        CompanyAddress = Convert.ToString(dt["CompanyAddress"]),
                        Greek = Convert.ToString(dt["Greek"]),
                        CollegeAttended = Convert.ToString(dt["CollegeAttended"]),
                        HighSchoolAttended = Convert.ToString(dt["HighSchoolAttended"]),
                        Degree = Convert.ToString(dt["Degree"]),
                        RelationshipStatus = Convert.ToString(dt["RelationshipStatus"]),
                        Hobbies = Convert.ToString(dt["Hobbies"]),
                        PrimaryAddress = Convert.ToString(dt["PrimaryAddress"]),
                        SecondaryAddress = Convert.ToString(dt["SecondaryAddress"]),
                        InSchool = Convert.ToString(dt["InSchool"]),
                        HasPets = Convert.ToString(dt["HasPets"]),
                        HasSiblings = Convert.ToString(dt["HasSiblings"]),
                        FatherFirstName = Convert.ToString(dt["FatherFirstName"]),
                        FatherLastName = Convert.ToString(dt["FatherLastName"]),
                        MotherFirstName = Convert.ToString(dt["MotherFirstName"]),
                        MotherLastName = Convert.ToString(dt["MotherLastName"]),
                        Skill = Convert.ToString(dt["Skill"]),
                        BusinessCardFrontImg = Convert.ToString(dt["BusinessCardFrontImg"]),
                        BusinessCardBackImg = Convert.ToString(dt["BusinessCardBackImg"]),
                        Personality = Convert.ToString(dt["Personality"]),
                        Notes = Convert.ToString(dt["Notes"]),                       
                    });

                }



            }

            sqlConn.Close();

            return listofContacts;
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
            cmd.Parameters.AddWithValue("@SpouseFirstName", contactInput.SpouseFirstName);
            cmd.Parameters.AddWithValue("@SpouseLastName", contactInput.SpouseLastName);
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
            cmd.Parameters.AddWithValue("@Greek", contactInput.Greek);
            cmd.Parameters.AddWithValue("@CollegeAttended", contactInput.CollegeAttended);
            cmd.Parameters.AddWithValue("@HighSchoolAttended", contactInput.HighSchoolAttended);
            cmd.Parameters.AddWithValue("@Degree", contactInput.Degree);
            cmd.Parameters.AddWithValue("@RelationshipStatus", contactInput.RelationshipStatus);
            cmd.Parameters.AddWithValue("@Hobbies", contactInput.Hobbies);
            cmd.Parameters.AddWithValue("@PrimaryAddress", contactInput.PrimaryAddress);
            cmd.Parameters.AddWithValue("@SecondaryAddress", contactInput.SecondaryAddress);
            cmd.Parameters.AddWithValue("@InSchool", contactInput.InSchool);
            cmd.Parameters.AddWithValue("@HasPets", contactInput.HasPets);
            cmd.Parameters.AddWithValue("@HasSiblings", contactInput.HasSiblings);
            cmd.Parameters.AddWithValue("@FatherFirstName", contactInput.FatherFirstName);
            cmd.Parameters.AddWithValue("@FatherLastName", contactInput.FatherLastName);
            cmd.Parameters.AddWithValue("@MotherFirstName", contactInput.MotherFirstName);
            cmd.Parameters.AddWithValue("@MotherLastName", contactInput.MotherLastName);
            cmd.Parameters.AddWithValue("@Skill", contactInput.Skill);
            cmd.Parameters.AddWithValue("@BusinessCardFrontImg", contactInput.BusinessCardFrontImg);
            cmd.Parameters.AddWithValue("@BusinessCardBackImg", contactInput.BusinessCardBackImg);
            cmd.Parameters.AddWithValue("@Personality", contactInput.Personality);
            cmd.Parameters.AddWithValue("@Notes", contactInput.Notes);

            #endregion




            sqlConn.Close();

            return null;
        }

        //Delete Contact
        public string DeleteContacts(string ContactID, string UserId)
        {
            return null;
        }

        //Update Contact
        public string UpdateContacts(string ContactID)
        {
            return null;
        }
    }
}