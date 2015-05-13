using System.Web.Mvc;
using Design101.Business.Definitions;
using Design101.Entities;
using Framework.MVC.Controllers;

namespace Design101.WebSite.Areas.Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    public class UserController :
        PersistanceController<User, UserBusiness>
    {
        public override ActionResult Edit(User entity)
        {
            base.Edit(entity);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
