using System;
using System.Globalization;
using System.Security.Principal;
using System.Web;

namespace Design101.Context
{
    public class Current
    {
        public static DateTime GetNowUTC
        {
            get
            {
                return Framework.Context.Current.GetNowUTC;
            }
        }

        public static CultureInfo Culture
        {
            get
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture;
            }

            set
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = value;
            }
        }

        public static IIdentity Identity
        {
            get
            {
                if (HttpContext.Current == null)
                    return new GenericIdentity("Unknown");

                return HttpContext.Current.User.Identity;
            }
        }
    }
}
