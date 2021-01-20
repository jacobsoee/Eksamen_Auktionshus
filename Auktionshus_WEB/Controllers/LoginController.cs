using Auktionshus_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stark_WEB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account account)
        {
            if (ModelState.IsValid)
            {
                using (AuktionDatabaseEntities db = new AuktionDatabaseEntities())
                {
                    var obj = db.Accounts.Where(a => a.Username.Equals(account.Username) && a.Password.Equals(account.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.Username.ToString();
                        return Redirect(Url.Action("Index", "Home"));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Forkert brugernavn eller kodeord! - Prøv igen";
                        return View("Index");
                    }
                }
            }
            return Redirect(Url.Action("Index", "Login"));
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return Redirect(Url.Action("Index", "Home"));
        }
    }
}
