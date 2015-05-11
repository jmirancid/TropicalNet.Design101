using System;
using System.Linq;
using System.Web.Mvc;
using Design101.Business.Definitions;
using Design101.Entities;
using Framework.MVC.Controllers;

namespace Design101.WebSite.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
    public class UserController :
        PersistanceController<User, UserBusiness>
    {
        public override void CreateGetPrerender(User entity = null)
        {
            ViewBag.RoleId =
                Enum.GetValues(typeof(Role_Enum)).Cast<int>()
                .Select(e => new SelectListItem()
                {
                    Text = Enum.GetName(typeof(Role_Enum), e),
                    Value = e.ToString()
                });

            base.CreateGetPrerender(entity);
        }

        public override void EditGetPrerender(User entity)
        {
            CreateGetPrerender(entity);
            base.EditGetPrerender(entity);
        }
    }
}
