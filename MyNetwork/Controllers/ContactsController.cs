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
        DataAccess Items = new DataAccess();
        public ActionResult Contacts()
        {
            
            

            var contactItems = Items.retrieveContacts(CurrentUser.UserID);

            return View("Contacts", "_LoggedIn", contactItems.ToList());
        }

        public ActionResult AddContact( string category, string firstName, string lastName, string age, string birthday, string primaryPhone, string secondaryPhone, string workPhone, string relationship, string spouseFirstName, string spouseLastName, string primaryOccupation, string secondaryOccupation, string metLocation, string numberOfYearKnown, string lastSpokeToDate, string websiteURL, string linkedInURL, string faceBookURL, string instagramURL, string twitterURL, string companyName, string companyAddress, string greek, string collegeAttened, string highSchoolAttened, string degreee, string relationshipStatus, string hobbies, string primaryAddress, string secondaryAddress, string inSchool, string hasPets, string hasSiblings, string fatherFirstName, string fatherLastName, string motherFirstName, string motherLastName, string skill, string businessCardFrontImg, string businessCardBackImg, string personality, string notes, string salaryRange, string email, string rating, FormCollection group)
        {
            


            #region add contact to class
            //addContact.UserID = CurrentUser.UserID;
            addContact.Category = category;
            addContact.FirstName = firstName;
            addContact.LastName = lastName;
            addContact.Age = age;
            addContact.Birthday = birthday;
            addContact.PrimaryPhone = primaryPhone;
            addContact.SecondaryPhone = secondaryPhone;
            addContact.WorkPhone = workPhone;
            //addContact.Image = image;
            addContact.Relationship = relationship;
            //addContact.SpouseFirstName = spouseFirstName;
            //addContact.SpouseLastName = spouseLastName;
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
            //addContact.Group = null;
            // addContact.Greek = greek;
            addContact.CollegeAttended = collegeAttened;
            addContact.HighSchoolAttended = highSchoolAttened;
            addContact.Degree = degreee;
            addContact.RelationshipStatus = relationshipStatus;
            addContact.Hobbies = hobbies;
            addContact.PrimaryAddress = primaryAddress;
            addContact.SecondaryAddress = secondaryAddress;
            addContact.InSchool = inSchool;
            //addContact.HasPets = hasPets;
            //addContact.HasSiblings = hasSiblings;
            //addContact.FatherFirstName = fatherFirstName;
            //addContact.FatherLastName = fatherLastName;
            //addContact.MotherFirstName = motherFirstName;
            //addContact.MotherLastName = motherLastName;
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
            Contact SelectedContact = new Contact();
            ContactGroup SelectedGroup = new ContactGroup();
            SelectedContact = Items.retrieveContactsByContactID(ContactId);

           
            ViewBag.ContactID = SelectedContact.ContactID;
            //ViewBag.ChildrenID = SelectedContact.ChildrenID;
            //ViewBag.SiblingID = SelectedContact.SiblingID;
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
            //ViewBag.SpouseFirstName = SelectedContact.SpouseFirstName;
            //ViewBag.SpouseLastName = SelectedContact.SpouseLastName;
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
            //ViewBag.Greek = SelectedContact.Greek;
            ViewBag.CollegeAttended = SelectedContact.CollegeAttended;
            ViewBag.HighSchoolAttended = SelectedContact.HighSchoolAttended;
            ViewBag.Degree = SelectedContact.Degree;
            ViewBag.RelationshipStatus = SelectedContact.RelationshipStatus;
            ViewBag.Hobbies = SelectedContact.Hobbies;
            ViewBag.PrimaryAddress = SelectedContact.PrimaryAddress;
            ViewBag.SecondaryAddress = SelectedContact.SecondaryAddress;
            ViewBag.InSchool = SelectedContact.InSchool;
            //ViewBag.HasPets = SelectedContact.HasPets;
            //ViewBag.HasSiblings = SelectedContact.HasSiblings;
            //ViewBag.FatherFirstName = SelectedContact.FatherFirstName;
            //ViewBag.FatherLastName = SelectedContact.FatherLastName;
            //ViewBag.MotherFirstName = SelectedContact.MotherFirstName;
            //ViewBag.MotherLastName = SelectedContact.MotherLastName;
            ViewBag.Skill = SelectedContact.Skill;
            ViewBag.BusinessCardFrontImg = SelectedContact.BusinessCardFrontImg;
            ViewBag.BusinessCardBackImg = SelectedContact.BusinessCardBackImg;
            ViewBag.Personality = SelectedContact.Personality;
            ViewBag.Notes = SelectedContact.Notes;

            //SelectedGroup.Group.Add("Test");
            //gp = SelectedGroup.Group.ToList();
            return View("ViewContact", "_LoggedIn", SelectedGroup.Group.ToList());
        }


        public ActionResult UpdateContact(string ContactId)
        {

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
                ig.ImagePath = "~/UI/Images/ProfileImages/" + profileImage.FileName;
                profileImage.SaveAs(Path.Combine(Server.MapPath("~/UI/Images/ProfileImages"), profileImage.FileName));

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
                ig.ImagePath = Path.Combine(Server.MapPath("~/UI/Images/ProfileImages"), frontBCImage.FileName);


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
                ig.ImagePath = Path.Combine(Server.MapPath("~/UI/Images/ProfileImages"), backBCImage.FileName);


                uploadImageFun.SaveImage(ig, ContactID);
            }

            return View("ViewContact", "_LoggedIn");
        }
    }
}