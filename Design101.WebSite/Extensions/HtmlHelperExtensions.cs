using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Design101.Business.Definitions;
using Design101.Entities;

namespace Design101.WebSite.Extensions
{
    public static class HtmlHelperExtensions
    {
        private static Lazy<UserBusiness> _bizUser =
            new Lazy<UserBusiness>();

        public static MvcHtmlString LogOut(this HtmlHelper htmlHelper)
        {
            var u =
                _bizUser.Value.GetBy(x => x.Username == Design101.Context.Current.Identity.Name);

            return htmlHelper.Partial("_LogOut", u);
        }

        public static MvcHtmlString Profile(this HtmlHelper htmlHelper)
        {
            var u =
                _bizUser.Value.GetBy(x => x.Username == Design101.Context.Current.Identity.Name);

            return htmlHelper.Partial("_Profile", u);
        }

        public static MvcHtmlString Timer(this HtmlHelper htmlHelper)
        {
            return htmlHelper.Partial("_Timer");
        }
    }
}