using System;
using System.Web;
using System.Web.Mvc;
using Design101.Business.Definitions;
using Design101.WebSite.Areas.Manager.Models;

namespace Design101.WebSite.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
    public class DashboardController : Controller
    {
        private Lazy<UserBusiness> _bizUser =
            new Lazy<UserBusiness>();

        private Lazy<DocumentBusiness> _bizDocument =
            new Lazy<DocumentBusiness>();

        public ActionResult Index()
        {
            var user =
                this._bizUser.Value.GetBy(x => x.Username == HttpContext.User.Identity.Name);

            var model = new DashboardModel()
            {
                UserProfile = user
            };

            return View(model);
        }
    }
}
