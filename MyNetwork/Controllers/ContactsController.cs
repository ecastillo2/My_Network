using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNetwork.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Contacts()
        {
            return View("Contacts", "_LoggedIn");
        }

        public ActionResult AddContact()
        {
            return View("AddContact", "_LoggedIn");
        }

        public ActionResult ViewContact()
        {
            return View("ViewContact", "_LoggedIn");
        }
    }
}