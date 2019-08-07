using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNetwork.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Notification()
        {
            return View("Notification", "_LoggedIn");
        }
    }
}