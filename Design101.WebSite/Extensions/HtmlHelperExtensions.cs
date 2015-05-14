using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Design101.Business.Definitions;

namespace Design101.WebSite.Extensions
{
    public static class HtmlHelperExtensions
    {
        private static NameValueCollection _fmConfig =
            ConfigurationManager.GetSection("filemanager") as NameValueCollection;

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

        public static MvcHtmlString Summary(this HtmlHelper htmlHelper)
        {
            var u =
                _bizUser.Value.Count();

            var v = _fmConfig["RootPath"];
            var r = HttpContext.Current.Server.MapPath(v);
            var d = new DirectoryInfo(r);
            var l = d.EnumerateFiles("*", SearchOption.AllDirectories);

            var f = l.Count();
            var s = l.Sum(x => x.Length);

            var o = l.Count(x => x.CreationTime.Date == DateTime.Now.Date);

            var m = new Tuple<int, int, double, int>(u, f, Math.Round((double)s / (1024 * 1024), 2), o);

            return htmlHelper.Partial("_Summary", m);
        }

        public static MvcHtmlString Timer(this HtmlHelper htmlHelper)
        {
            return htmlHelper.Partial("_Timer");
        }

        public static MvcHtmlString LastLoginUser(this HtmlHelper htmlHelper)
        {
            var m =
                _bizUser.Value.GetLastLoginUser();

            return htmlHelper.Partial("_LastLoginUser", m);
        }
    }
}
