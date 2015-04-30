using System;
using System.Globalization;

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
    }
}
