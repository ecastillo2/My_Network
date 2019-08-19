using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNetwork.Models;
using MyNetwork.DAL;
using MyNetwork.Services;
using System.IO;

namespace MyNetwork.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        // GET: Contacts

        Image ig = new Image();
        ImageUpload uploadImageFun = new ImageUpload();
        ContactGroup gp = new ContactGroup();
        public User CurrentUser = new User();
        public Contact addContact = new Contact();
        public Contact updatedContact = new Contact();
        public Contact selectedContactInfo = new Contact();
        DataAccess Items = new DataAccess();
        public ActionResult Contacts()
        {
            
            

            var contactItems = Items.retrieveContacts(CurrentUser.UserID);

            return View("Contacts", "_LoggedIn", contactItems.ToList());
        }

        public ActionResult AddContact()
        {
            return View("AddContact", "_LoggedIn");
        }

        [HttpPost]
        public ActionResult AddContact( string category, string firstName, string lastName, string age, string birthday, string primaryPhone, string secondaryPhone, string workPhone, string relationship, string spouseFirstName, string spouseLastName, string primaryOccupation, string secondaryOccupation, string metLocation, string numberOfYearKnown, string lastSpokeToDate, string websiteURL, string linkedInURL, string faceBookURL, string instagramURL, string twitterURL, string companyName, string companyAddress, string greek, string collegeAttened, string highSchoolAttened, string degreee, string relationshipStatus, string hobbies, string primaryAddress, string secondaryAddress, string inSchool, string hasPets, string hasSiblings, string fatherFirstName, string fatherLastName, string motherFirstName, string motherLastName, string skill, string businessCardFrontImg, string businessCardBackImg, string personality, string notes, string salaryRange, string email, string rating, FormCollection group)
        {
            
            #region add contact to class            
            addContact.Category = category;
            addContact.FirstName = firstName;
            addContact.LastName = lastName;
            addContact.Age = age;
            addContact.Birthday = birthday;
            addContact.PrimaryPhone = primaryPhone;
            addContact.SecondaryPhone = secondaryPhone;
            addContact.WorkPhone = workPhone;           
            addContact.Relationship = relationship;           
            addContact.PrimaryOccupation = primaryOccupation;
            addContact.SecondaryOccupation = secondaryOccupation;
            addContact.MetLocation = metLocation;
            addContact.NumberOfYearKnown = numberOfYearKnown;
            addContact.LastSpokeToDate = lastSpokeToDate;
            addContact.WebsiteURL = websiteURL;
            addContact.LinkedInURL = linkedInURL;
            addContact.FaceBookURL = faceBookURL;
            addContact.InstagramURL = instagramURL;
            addContact.TwitterURL = twitterURL;
            addContact.CompanyName = companyName;
            addContact.CompanyAddress = companyAddress;          
            addContact.CollegeAttended = collegeAttened;
            addContact.HighSchoolAttended = highSchoolAttened;
            addContact.Degree = degreee;
            addContact.RelationshipStatus = relationshipStatus;
            addContact.Hobbies = hobbies;
            addContact.PrimaryAddress = primaryAddress;
            addContact.SecondaryAddress = secondaryAddress;
            addContact.InSchool = inSchool;         
            addContact.Skill = skill;
            addContact.BusinessCardFrontImg = businessCardFrontImg;
            addContact.BusinessCardBackImg = businessCardBackImg;
            addContact.Personality = personality;
            addContact.Notes = notes;
            addContact.SalaryRange = salaryRange;
            addContact.Email = email;
            #endregion

            string[] headerName = null;

            //the form values becomes comma delimited array when it come to server side
            if (headerName == null ) {
               
            }
            else
            {
                headerName = group["group"].Split(char.Parse(","));


                foreach (var x in headerName)
                {
                    //insert Header name and sturcture int dictionary
                    gp.Group.Add(x);
                }
            }

            //process values
            List<string> headerList = new List<string>();
            Dictionary<string, string> HeaderMapping = new Dictionary<string, string>();





            Items.InsertContacts(addContact,CurrentUser.UserID);

            return View("AddContact", "_LoggedIn");
        }

        public ActionResult ViewContact(string ContactId)
        {
            List<string> selecteImage = new List<string>();
            Contact SelectedContact = new Contact();
            ContactGroup SelectedGroup = new ContactGroup();
            SelectedContact = Items.retrieveContactsByContactID(ContactId);

            selecteImage = Items.retrieveImage(ContactId);

            foreach(var x in selecteImage)
            {
                if(x.Contains("profileImage"))
                {
                    ViewBag.profileImage = x;
                }
                if (x.Contains("FrontBCImage"))
                {
                    ViewBag.frontBCImage = x;
                }
                if (x.Contains("BackBCImage"))
                {
                    ViewBag.backBCImage = x;
                }
            }

            ViewBag.ContactID = SelectedContact.ContactID;          
            ViewBag.AddedContactDate = SelectedContact.AddedContactDate;
            ViewBag.Category = SelectedContact.Category;
            ViewBag.FirstName = SelectedContact.FirstName;
            ViewBag.LastName = SelectedContact.LastName;
            ViewBag.Age = SelectedContact.Age;
            ViewBag.Birthday = SelectedContact.Birthday;
            ViewBag.PrimaryPhone = SelectedContact.PrimaryPhone;
            ViewBag.SecondaryPhone = SelectedContact.SecondaryPhone;
            ViewBag.WorkPhone = SelectedContact.WorkPhone;
            ViewBag.Email = SelectedContact.Email;
            ViewBag.Relationship = SelectedContact.Relationship;           
            ViewBag.SalaryRange = SelectedContact.SalaryRange;
            ViewBag.PrimaryOccupation = SelectedContact.PrimaryOccupation;
            ViewBag.SecondaryOccupation = SelectedContact.SecondaryOccupation;
            ViewBag.MetLocation = SelectedContact.MetLocation;
            ViewBag.NumberOfYearKnown = SelectedContact.NumberOfYearKnown;
            ViewBag.LastSpokeToDate = SelectedContact.LastSpokeToDate;
            ViewBag.WebsiteURL = SelectedContact.WebsiteURL;
            ViewBag.LinkedInURL = SelectedContact.LinkedInURL;
            ViewBag.FaceBookURL = SelectedContact.FaceBookURL;
            ViewBag.InstagramURL = SelectedContact.InstagramURL;
            ViewBag.TwitterURL = SelectedContact.TwitterURL;
            ViewBag.CompanyName = SelectedContact.CompanyName;
            ViewBag.CompanyAddress = SelectedContact.CompanyAddress;          
            ViewBag.CollegeAttended = SelectedContact.CollegeAttended;
            ViewBag.HighSchoolAttended = SelectedContact.HighSchoolAttended;
            ViewBag.Degree = SelectedContact.Degree;
            ViewBag.RelationshipStatus = SelectedContact.RelationshipStatus;
            ViewBag.Hobbies = SelectedContact.Hobbies;
            ViewBag.PrimaryAddress = SelectedContact.PrimaryAddress;
            ViewBag.SecondaryAddress = SelectedContact.SecondaryAddress;
            ViewBag.InSchool = SelectedContact.InSchool;         
            ViewBag.Skill = SelectedContact.Skill;
            ViewBag.BusinessCardFrontImg = SelectedContact.BusinessCardFrontImg;
            ViewBag.BusinessCardBackImg = SelectedContact.BusinessCardBackImg;
            ViewBag.Personality = SelectedContact.Personality;
            ViewBag.Notes = SelectedContact.Notes;

            return View("ViewContact", "_LoggedIn", SelectedGroup.Group.ToList());
        }




        [HttpPost]
        public ActionResult updateContact(string ContactID)
        {
            List<string> selecteImage = new List<string>();
            Contact SelectedContact = new Contact();
            ContactGroup SelectedGroup = new ContactGroup();
            SelectedContact = Items.retrieveContactsByContactID(ContactID);

            //selecteImage = Items.retrieveImage(ContactId);

            //foreach (var x in selecteImage)
            //{
            //    if (x.Contains("profileImage"))
            //    {
            //        ViewBag.profileImage = x;
            //    }
            //    if (x.Contains("FrontBCImage"))
            //    {
            //        ViewBag.frontBCImage = x;
            //    }
            //    if (x.Contains("BackBCImage"))
            //    {
            //        ViewBag.backBCImage = x;
            //    }
            //}

            ViewBag.ContactID = SelectedContact.ContactID;
            ViewBag.AddedContactDate = SelectedContact.AddedContactDate;
            ViewBag.Category = SelectedContact.Category;
            ViewBag.FirstName = SelectedContact.FirstName;
            ViewBag.LastName = SelectedContact.LastName;
            ViewBag.Age = SelectedContact.Age;
            ViewBag.Birthday = SelectedContact.Birthday;
            ViewBag.PrimaryPhone = SelectedContact.PrimaryPhone;
            ViewBag.SecondaryPhone = SelectedContact.SecondaryPhone;
            ViewBag.WorkPhone = SelectedContact.WorkPhone;
            ViewBag.Email = SelectedContact.Email;
            ViewBag.Relationship = SelectedContact.Relationship;
            ViewBag.SalaryRange = SelectedContact.SalaryRange;
            ViewBag.PrimaryOccupation = SelectedContact.PrimaryOccupation;
            ViewBag.SecondaryOccupation = SelectedContact.SecondaryOccupation;
            ViewBag.MetLocation = SelectedContact.MetLocation;
            ViewBag.NumberOfYearKnown = SelectedContact.NumberOfYearKnown;
            ViewBag.LastSpokeToDate = SelectedContact.LastSpokeToDate;
            ViewBag.WebsiteURL = SelectedContact.WebsiteURL;
            ViewBag.LinkedInURL = SelectedContact.LinkedInURL;
            ViewBag.FaceBookURL = SelectedContact.FaceBookURL;
            ViewBag.InstagramURL = SelectedContact.InstagramURL;
            ViewBag.TwitterURL = SelectedContact.TwitterURL;
            ViewBag.CompanyName = SelectedContact.CompanyName;
            ViewBag.CompanyAddress = SelectedContact.CompanyAddress;
            ViewBag.CollegeAttended = SelectedContact.CollegeAttended;
            ViewBag.HighSchoolAttended = SelectedContact.HighSchoolAttended;
            ViewBag.Degree = SelectedContact.Degree;
            ViewBag.RelationshipStatus = SelectedContact.RelationshipStatus;
            ViewBag.Hobbies = SelectedContact.Hobbies;
            ViewBag.PrimaryAddress = SelectedContact.PrimaryAddress;
            ViewBag.SecondaryAddress = SelectedContact.SecondaryAddress;
            ViewBag.InSchool = SelectedContact.InSchool;
            ViewBag.Skill = SelectedContact.Skill;
            ViewBag.BusinessCardFrontImg = SelectedContact.BusinessCardFrontImg;
            ViewBag.BusinessCardBackImg = SelectedContact.BusinessCardBackImg;
            ViewBag.Personality = SelectedContact.Personality;
            ViewBag.Notes = SelectedContact.Notes;

            

            return View("UpdateContact", "_LoggedIn");
        }

        
        public ActionResult UpdateContact(string ContactID, string category, string firstName, string lastName, string age, string birthday, string primaryPhone, string secondaryPhone, string workPhone, string relationship, string spouseFirstName, string spouseLastName, string primaryOccupation, string secondaryOccupation, string metLocation, string numberOfYearKnown, string lastSpokeToDate, string websiteURL, string linkedInURL, string faceBookURL, string instagramURL, string twitterURL, string companyName, string companyAddress, string greek, string collegeAttened, string highSchoolAttened, string degreee, string relationshipStatus, string hobbies, string primaryAddress, string secondaryAddress, string inSchool, string hasPets, string hasSiblings, string fatherFirstName, string fatherLastName, string motherFirstName, string motherLastName, string skill, string businessCardFrontImg, string businessCardBackImg, string personality, string notes, string salaryRange, string email, string rating, FormCollection group)
        {

            #region add contact to class     
            //updateContact.ContactID = category;
            updatedContact.Category = category;
            updatedContact.FirstName = firstName;
            updatedContact.LastName = lastName;
            updatedContact.Age = age;
            updatedContact.Birthday = birthday;
            updatedContact.PrimaryPhone = primaryPhone;
            updatedContact.SecondaryPhone = secondaryPhone;
            updatedContact.WorkPhone = workPhone;
            updatedContact.Relationship = relationship;
            updatedContact.PrimaryOccupation = primaryOccupation;
            updatedContact.SecondaryOccupation = secondaryOccupation;
            updatedContact.MetLocation = metLocation;
            updatedContact.NumberOfYearKnown = numberOfYearKnown;
            updatedContact.LastSpokeToDate = lastSpokeToDate;
            updatedContact.WebsiteURL = websiteURL;
            updatedContact.LinkedInURL = linkedInURL;
            updatedContact.FaceBookURL = faceBookURL;
            updatedContact.InstagramURL = instagramURL;
            updatedContact.TwitterURL = twitterURL;
            updatedContact.CompanyName = companyName;
            updatedContact.CompanyAddress = companyAddress;
            updatedContact.CollegeAttended = collegeAttened;
            updatedContact.HighSchoolAttended = highSchoolAttened;
            updatedContact.Degree = degreee;
            updatedContact.RelationshipStatus = relationshipStatus;
            updatedContact.Hobbies = hobbies;
            updatedContact.PrimaryAddress = primaryAddress;
            updatedContact.SecondaryAddress = secondaryAddress;
            updatedContact.InSchool = inSchool;
            updatedContact.Skill = skill;
            updatedContact.BusinessCardFrontImg = businessCardFrontImg;
            updatedContact.BusinessCardBackImg = businessCardBackImg;
            updatedContact.Personality = personality;
            updatedContact.Notes = notes;
            updatedContact.SalaryRange = salaryRange;
            updatedContact.Email = email;
            #endregion

            string[] headerName = null;

            //the form values becomes comma delimited array when it come to server side
            if (headerName == null)
            {

            }
            else
            {
                headerName = group["group"].Split(char.Parse(","));


                foreach (var x in headerName)
                {
                    //insert Header name and sturcture int dictionary
                    gp.Group.Add(x);
                }
            }

            //process values
            List<string> headerList = new List<string>();
            Dictionary<string, string> HeaderMapping = new Dictionary<string, string>();


            selectedContactInfo = Items.UpdateContactInfo(updatedContact, ContactID);


            //ViewBag.ContactID = selectedContactInfo.ContactID;
            //ViewBag.AddedContactDate = selectedContactInfo.AddedContactDate;
            //ViewBag.Category = selectedContactInfo.Category;
            //ViewBag.FirstName = selectedContactInfo.FirstName;
            //ViewBag.LastName = selectedContactInfo.LastName;
            //ViewBag.Age = selectedContactInfo.Age;
            //ViewBag.Birthday = selectedContactInfo.Birthday;
            //ViewBag.PrimaryPhone = selectedContactInfo.PrimaryPhone;
            //ViewBag.SecondaryPhone = selectedContactInfo.SecondaryPhone;
            //ViewBag.WorkPhone = selectedContactInfo.WorkPhone;
            //ViewBag.Email = selectedContactInfo.Email;
            //ViewBag.Relationship = selectedContactInfo.Relationship;
            //ViewBag.SalaryRange = selectedContactInfo.SalaryRange;
            //ViewBag.PrimaryOccupation = selectedContactInfo.PrimaryOccupation;
            //ViewBag.SecondaryOccupation = selectedContactInfo.SecondaryOccupation;
            //ViewBag.MetLocation = selectedContactInfo.MetLocation;
            //ViewBag.NumberOfYearKnown = selectedContactInfo.NumberOfYearKnown;
            //ViewBag.LastSpokeToDate = selectedContactInfo.LastSpokeToDate;
            //ViewBag.WebsiteURL = selectedContactInfo.WebsiteURL;
            //ViewBag.LinkedInURL = selectedContactInfo.LinkedInURL;
            //ViewBag.FaceBookURL = selectedContactInfo.FaceBookURL;
            //ViewBag.InstagramURL = selectedContactInfo.InstagramURL;
            //ViewBag.TwitterURL = selectedContactInfo.TwitterURL;
            //ViewBag.CompanyName = selectedContactInfo.CompanyName;
            //ViewBag.CompanyAddress = selectedContactInfo.CompanyAddress;
            //ViewBag.CollegeAttended = selectedContactInfo.CollegeAttended;
            //ViewBag.HighSchoolAttended = selectedContactInfo.HighSchoolAttended;
            //ViewBag.Degree = selectedContactInfo.Degree;
            //ViewBag.RelationshipStatus = selectedContactInfo.RelationshipStatus;
            //ViewBag.Hobbies = selectedContactInfo.Hobbies;
            //ViewBag.PrimaryAddress = selectedContactInfo.PrimaryAddress;
            //ViewBag.SecondaryAddress = selectedContactInfo.SecondaryAddress;
            //ViewBag.InSchool = selectedContactInfo.InSchool;
            //ViewBag.Skill = selectedContactInfo.Skill;
            //ViewBag.BusinessCardFrontImg = selectedContactInfo.BusinessCardFrontImg;
            //ViewBag.BusinessCardBackImg = selectedContactInfo.BusinessCardBackImg;
            //ViewBag.Personality = selectedContactInfo.Personality;
            //ViewBag.Notes = selectedContactInfo.Notes;



            return View("UpdateContact", "_LoggedIn");
        }


        [HttpPost]
        public ActionResult ViewContact(HttpPostedFileBase profileImage, HttpPostedFileBase frontBCImage, HttpPostedFileBase backBCImage, string ContactID)
        {
            

            string imageType;

            if (profileImage == null)
            {


            }
            else
            {
                imageType = "profileImage";

                ig.ImageType = imageType;
                ig.Title = profileImage.FileName;
                ig.ImagePath = "~/UI/Images/ProfileImages/" + imageType + profileImage.FileName;
                profileImage.SaveAs(Path.Combine(Server.MapPath("~/UI/Images/ProfileImages"),  profileImage.FileName));

                uploadImageFun.SaveImage(ig, ContactID);
            }


            if (frontBCImage == null )
            {
                

            }
            else
            {
                imageType = "frontBCImage";

                ig.ImageType = imageType;
                ig.Title = frontBCImage.FileName;
                ig.ImagePath = Path.Combine(Server.MapPath("~/UI/Images/ProfileImages"), imageType + frontBCImage.FileName);


                uploadImageFun.SaveImage(ig, ContactID);

            }
            if (backBCImage == null)
            {
               

            }
            else
                {
                imageType = "backBCImage";

                ig.ImageType = imageType;
                ig.Title = backBCImage.FileName;
                ig.ImagePath = Path.Combine(Server.MapPath("~/UI/Images/ProfileImages"), imageType + backBCImage.FileName);


                uploadImageFun.SaveImage(ig, ContactID);
            }

            return View("ViewContact", "_LoggedIn");
        }


        public ActionResult UpdateContactInfo(string ContactID, string category, string firstName, string lastName, string age, string birthday, string primaryPhone, string secondaryPhone, string workPhone, string relationship, string spouseFirstName, string spouseLastName, string primaryOccupation, string secondaryOccupation, string metLocation, string numberOfYearKnown, string lastSpokeToDate, string websiteURL, string linkedInURL, string faceBookURL, string instagramURL, string twitterURL, string companyName, string companyAddress, string greek, string collegeAttened, string highSchoolAttened, string degreee, string relationshipStatus, string hobbies, string primaryAddress, string secondaryAddress, string inSchool, string hasPets, string hasSiblings, string fatherFirstName, string fatherLastName, string motherFirstName, string motherLastName, string skill, string businessCardFrontImg, string businessCardBackImg, string personality, string notes, string salaryRange, string email, string rating, FormCollection group)
        {

            #region add contact to class     
            //updateContact.ContactID = category;
            updatedContact.Category = category;
            updatedContact.FirstName = firstName;
            updatedContact.LastName = lastName;
            updatedContact.Age = age;
            updatedContact.Birthday = birthday;
            updatedContact.PrimaryPhone = primaryPhone;
            updatedContact.SecondaryPhone = secondaryPhone;
            updatedContact.WorkPhone = workPhone;
            updatedContact.Relationship = relationship;
            updatedContact.PrimaryOccupation = primaryOccupation;
            updatedContact.SecondaryOccupation = secondaryOccupation;
            updatedContact.MetLocation = metLocation;
            updatedContact.NumberOfYearKnown = numberOfYearKnown;
            updatedContact.LastSpokeToDate = lastSpokeToDate;
            updatedContact.WebsiteURL = websiteURL;
            updatedContact.LinkedInURL = linkedInURL;
            updatedContact.FaceBookURL = faceBookURL;
            updatedContact.InstagramURL = instagramURL;
            updatedContact.TwitterURL = twitterURL;
            updatedContact.CompanyName = companyName;
            updatedContact.CompanyAddress = companyAddress;
            updatedContact.CollegeAttended = collegeAttened;
            updatedContact.HighSchoolAttended = highSchoolAttened;
            updatedContact.Degree = degreee;
            updatedContact.RelationshipStatus = relationshipStatus;
            updatedContact.Hobbies = hobbies;
            updatedContact.PrimaryAddress = primaryAddress;
            updatedContact.SecondaryAddress = secondaryAddress;
            updatedContact.InSchool = inSchool;
            updatedContact.Skill = skill;
            updatedContact.BusinessCardFrontImg = businessCardFrontImg;
            updatedContact.BusinessCardBackImg = businessCardBackImg;
            updatedContact.Personality = personality;
            updatedContact.Notes = notes;
            updatedContact.SalaryRange = salaryRange;
            updatedContact.Email = email;
            #endregion

            string[] headerName = null;

            //the form values becomes comma delimited array when it come to server side
            if (headerName == null)
            {

            }
            else
            {
                headerName = group["group"].Split(char.Parse(","));


                foreach (var x in headerName)
                {
                    //insert Header name and sturcture int dictionary
                    gp.Group.Add(x);
                }
            }

            //process values
            List<string> headerList = new List<string>();
            Dictionary<string, string> HeaderMapping = new Dictionary<string, string>();


            selectedContactInfo = Items.UpdateContactInfo(updatedContact, ContactID);


            //ViewBag.ContactID = selectedContactInfo.ContactID;
            //ViewBag.AddedContactDate = selectedContactInfo.AddedContactDate;
            //ViewBag.Category = selectedContactInfo.Category;
            //ViewBag.FirstName = selectedContactInfo.FirstName;
            //ViewBag.LastName = selectedContactInfo.LastName;
            //ViewBag.Age = selectedContactInfo.Age;
            //ViewBag.Birthday = selectedContactInfo.Birthday;
            //ViewBag.PrimaryPhone = selectedContactInfo.PrimaryPhone;
            //ViewBag.SecondaryPhone = selectedContactInfo.SecondaryPhone;
            //ViewBag.WorkPhone = selectedContactInfo.WorkPhone;
            //ViewBag.Email = selectedContactInfo.Email;
            //ViewBag.Relationship = selectedContactInfo.Relationship;
            //ViewBag.SalaryRange = selectedContactInfo.SalaryRange;
            //ViewBag.PrimaryOccupation = selectedContactInfo.PrimaryOccupation;
            //ViewBag.SecondaryOccupation = selectedContactInfo.SecondaryOccupation;
            //ViewBag.MetLocation = selectedContactInfo.MetLocation;
            //ViewBag.NumberOfYearKnown = selectedContactInfo.NumberOfYearKnown;
            //ViewBag.LastSpokeToDate = selectedContactInfo.LastSpokeToDate;
            //ViewBag.WebsiteURL = selectedContactInfo.WebsiteURL;
            //ViewBag.LinkedInURL = selectedContactInfo.LinkedInURL;
            //ViewBag.FaceBookURL = selectedContactInfo.FaceBookURL;
            //ViewBag.InstagramURL = selectedContactInfo.InstagramURL;
            //ViewBag.TwitterURL = selectedContactInfo.TwitterURL;
            //ViewBag.CompanyName = selectedContactInfo.CompanyName;
            //ViewBag.CompanyAddress = selectedContactInfo.CompanyAddress;
            //ViewBag.CollegeAttended = selectedContactInfo.CollegeAttended;
            //ViewBag.HighSchoolAttended = selectedContactInfo.HighSchoolAttended;
            //ViewBag.Degree = selectedContactInfo.Degree;
            //ViewBag.RelationshipStatus = selectedContactInfo.RelationshipStatus;
            //ViewBag.Hobbies = selectedContactInfo.Hobbies;
            //ViewBag.PrimaryAddress = selectedContactInfo.PrimaryAddress;
            //ViewBag.SecondaryAddress = selectedContactInfo.SecondaryAddress;
            //ViewBag.InSchool = selectedContactInfo.InSchool;
            //ViewBag.Skill = selectedContactInfo.Skill;
            //ViewBag.BusinessCardFrontImg = selectedContactInfo.BusinessCardFrontImg;
            //ViewBag.BusinessCardBackImg = selectedContactInfo.BusinessCardBackImg;
            //ViewBag.Personality = selectedContactInfo.Personality;
            //ViewBag.Notes = selectedContactInfo.Notes;



            return RedirectToAction("Contacts", "Contacts");
        }
    }

   
}