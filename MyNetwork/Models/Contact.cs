using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyNetwork.Models
{
    public class Contact
    {

        private  string _ContactID;
        public string ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }

        //private static string _ChildrenID;
        //public string ChildrenID
        //{
        //    get { return _ChildrenID; }
        //    set { _ChildrenID = value; }
        //}

        //private static string _SiblingID;
        //public string SiblingID
        //{
        //    get { return _SiblingID; }
        //    set { _SiblingID = value; }
        //}

        private string _AddedContactDate;
        public string AddedContactDate
        {
            get { return _AddedContactDate; }
            set { _AddedContactDate = value; }
        }

        private string _Category;
        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        private string _Age;
        public string Age
        {
            get { return _Age; }
            set { _Age = value; }
        }

        private string _Birthday;
        public string Birthday
        {
            get { return _Birthday; }
            set { _Birthday = value; }
        }

        private string _PrimaryPhone;
        public string PrimaryPhone
        {
            get { return _PrimaryPhone; }
            set { _PrimaryPhone = value; }
        }

        private string _SecondaryPhone;
        public string SecondaryPhone
        {
            get { return _SecondaryPhone; }
            set { _SecondaryPhone = value; }
        }

        private string _WorkPhone;
        public string WorkPhone
        {
            get { return _WorkPhone; }
            set { _WorkPhone = value; }
        }

        private string _Image;
        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Relationship;
        public string Relationship
        {
            get { return _Relationship; }
            set { _Relationship = value; }
        }

        //private string _SpouseFirstName;
        //public string SpouseFirstName
        //{
        //    get { return _SpouseFirstName; }
        //    set { _SpouseFirstName = value; }
        //}

        //private string _SpouseLastName;
        //public string SpouseLastName
        //{
        //    get { return _SpouseLastName; }
        //    set { _SpouseLastName = value; }
        //}

        private string _SalaryRange;
        public string SalaryRange
        {
            get { return _SalaryRange; }
            set { _SalaryRange = value; }
        }

        private string _Group;
        public string Group
        {
            get { return _Group; }
            set { _Group = value; }
        }

        private string _PrimaryOccupation;
        public string PrimaryOccupation
        {
            get { return _PrimaryOccupation; }
            set { _PrimaryOccupation = value; }
        }

        private string _SecondaryOccupation;
        public string SecondaryOccupation
        {
            get { return _SecondaryOccupation; }
            set { _SecondaryOccupation = value; }
        }

        private string _MetLocation;
        public string MetLocation
        {
            get { return _MetLocation; }
            set { _MetLocation = value; }
        }

        private string _NumberOfYearKnown;
        public string NumberOfYearKnown
        {
            get { return _NumberOfYearKnown; }
            set { _NumberOfYearKnown = value; }
        }

        private string _LastSpokeToDate;
        public string LastSpokeToDate
        {
            get { return _LastSpokeToDate; }
            set { _LastSpokeToDate = value; }
        }

        private string _WebsiteURL;
        public string WebsiteURL
        {
            get { return _WebsiteURL; }
            set { _WebsiteURL = value; }
        }

        private string _LinkedInURL;
        public string LinkedInURL
        {
            get { return _LinkedInURL; }
            set { _LinkedInURL = value; }
        }

        private string _FaceBookURL;
        public string FaceBookURL
        {
            get { return _FaceBookURL; }
            set { _FaceBookURL = value; }
        }

        private string _InstagramURL;
        public string InstagramURL
        {
            get { return _InstagramURL; }
            set { _InstagramURL = value; }
        }

        private string _TwitterURL;
        public string TwitterURL
        {
            get { return _TwitterURL; }
            set { _TwitterURL = value; }
        }

        private string _CompanyName;
        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        private string _CompanyAddress;
        public string CompanyAddress
        {
            get { return _CompanyAddress; }
            set { _CompanyAddress = value; }
        }

     
        //private List<string> _Group = new List<string>();
        //public List<string> Group
        //{
        //    get { return _Group; }
        //    set { _Group = value; }
        //}

        private string _CollegeAttended;
        public string CollegeAttended
        {
            get { return _CollegeAttended; }
            set { _CollegeAttended = value; }
        }

        private string _HighSchoolAttended;
        public string HighSchoolAttended
        {
            get { return _HighSchoolAttended; }
            set { _HighSchoolAttended = value; }
        }

        private string _Degree;
        public string Degree
        {
            get { return _Degree; }
            set { _Degree = value; }
        }

        private string _RelationshipStatus;
        public string RelationshipStatus
        {
            get { return _RelationshipStatus; }
            set { _RelationshipStatus = value; }
        }

        private string _Hobbies;
        public string Hobbies
        {
            get { return _Hobbies; }
            set { _Hobbies = value; }
        }

        private string _PrimaryAddress;
        public string PrimaryAddress
        {
            get { return _PrimaryAddress; }
            set { _PrimaryAddress = value; }
        }

        private string _SecondaryAddress;
        public string SecondaryAddress
        {
            get { return _SecondaryAddress; }
            set { _SecondaryAddress = value; }
        }

        private string _InSchool;
        public string InSchool
        {
            get { return _InSchool; }
            set { _InSchool = value; }
        }

        //private string _HasPets;
        //public string HasPets
        //{
        //    get { return _HasPets; }
        //    set { _HasPets = value; }
        //}

        //private string _HasSiblings;
        //public string HasSiblings
        //{
        //    get { return _HasSiblings; }
        //    set { _HasSiblings = value; }
        //}

        //private string _FatherFirstName;
        //public string FatherFirstName
        //{
        //    get { return _FatherFirstName; }
        //    set { _FatherFirstName = value; }
        //}

        //private string _FatherLastName;
        //public string FatherLastName
        //{
        //    get { return _FatherLastName; }
        //    set { _FatherLastName = value; }
        //}

        //private string _MotherFirstName;
        //public string MotherFirstName
        //{
        //    get { return _MotherFirstName; }
        //    set { _MotherFirstName = value; }
        //}

        //private string _MotherLastName;
        //public string MotherLastName
        //{
        //    get { return _MotherLastName; }
        //    set { _MotherLastName = value; }
        //}

        private string _Skill;
        public string Skill
        {
            get { return _Skill; }
            set { _Skill = value; }
        }

        private string _BusinessCardFrontImg;
        public string BusinessCardFrontImg
        {
            get { return _BusinessCardFrontImg; }
            set { _BusinessCardFrontImg = value; }
        }

        private string _BusinessCardBackImg;
        public string BusinessCardBackImg
        {
            get { return _BusinessCardBackImg; }
            set { _BusinessCardBackImg = value; }
        }

        private string _Personality;
        public string Personality
        {
            get { return _Personality; }
            set { _Personality = value; }
        }

        private string _Notes;
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
    }
}