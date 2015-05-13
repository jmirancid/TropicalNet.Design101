﻿using System.Web.Mvc;

namespace Design101.WebSite.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
