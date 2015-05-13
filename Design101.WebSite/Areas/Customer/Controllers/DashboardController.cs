using System.Web.Mvc;

namespace Design101.WebSite.Areas.Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
