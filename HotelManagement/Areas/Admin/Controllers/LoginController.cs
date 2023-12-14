using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        [Route("Login")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Logout")]
        public ActionResult Logout()
        {
            return View("Login");
        }
    }
}