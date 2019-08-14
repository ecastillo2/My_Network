using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNetwork.Models;
using MyNetwork.DAL;


namespace MyNetwork.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        // GET: Contacts

        public User CurrentUser = new User();
        public Contact addContact = new Contact();
        DataAccess Items = new DataAccess();
        public ActionResult Contacts()
        {
            
            

            var contactItems = Items.retrieveContacts(CurrentUser.UserID);

            return View("Contacts", "_LoggedIn", contactItems.ToList());
        }

        public ActionResult AddContact( string category, string firstName, string lastName, string age, string birthday, string primaryPhone, string secondaryPhone, string workPhone, string image, string relationship, string spouseFirstName, string spouseLastName, string primaryOccupation, string secondaryOccupation, string metLocation, string numberOfYearKnown, string lastSpokeToDate, string websiteURL, string linkedInURL, string faceBookURL, string instagramURL, string twitterURL, string companyName, string companyAddress, string greek, string collegeAttened, string highSchoolAttened, string degreee, string relationshipStatus, string hobbies, string primaryAddress, string secondaryAddress, string inSchool, string hasPets, string hasSiblings, string fatherFirstName, string fatherLastName, string motherFirstName, string motherLastName, string skill, string businessCardFrontImg, string businessCardBackImg, string personality, string notes, string salaryRange, string email, string rating)
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
            addContact.Image = image;
            addContact.Relationship = relationship;
            addContact.SpouseFirstName = spouseFirstName;
            addContact.SpouseLastName = spouseLastName;
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
            addContact.Greek = greek;
            addContact.CollegeAttended = collegeAttened;
            addContact.HighSchoolAttended = highSchoolAttened;
            addContact.Degree = degreee;
            addContact.RelationshipStatus = relationshipStatus;
            addContact.Hobbies = hobbies;
            addContact.PrimaryAddress = primaryAddress;
            addContact.SecondaryAddress = secondaryAddress;
            addContact.InSchool = inSchool;
            addContact.HasPets = hasPets;
            addContact.HasSiblings = hasSiblings;
            addContact.FatherFirstName = fatherFirstName;
            addContact.FatherLastName = fatherLastName;
            addContact.MotherFirstName = motherFirstName;
            addContact.MotherLastName = motherLastName;
            addContact.Skill = skill;
            addContact.BusinessCardFrontImg = businessCardFrontImg;
            addContact.BusinessCardBackImg = businessCardBackImg;
            addContact.Personality = personality;
            addContact.Notes = notes;
            addContact.SalaryRange = salaryRange;
            addContact.Email = email;
            #endregion



            Items.InsertContacts(addContact,CurrentUser.UserID);

            return View("AddContact", "_LoggedIn");
        }

        public ActionResult ViewContact(string ContactId)
        {
            return View("ViewContact", "_LoggedIn");
        }
    }
}