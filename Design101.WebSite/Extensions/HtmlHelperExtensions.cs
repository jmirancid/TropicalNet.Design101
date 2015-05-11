using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Design101.Entities;

namespace Design101.WebSite.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Profile(this HtmlHelper htmlHelper, User user)
        {
            return htmlHelper.Partial("_Profile", user);
        }

        public static MvcHtmlString Timer(this HtmlHelper htmlHelper)
        {
            return htmlHelper.Partial("_Timer");
        }
    }
}