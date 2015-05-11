using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Design101.Entities;

namespace Design101.WebSite.Areas.Manager.Models
{
    public class DashboardModel
    {
        public User UserProfile { get; set; }

        public int Users { get; set; }

        public User LastRegisteredUser { get; set; }

        public User LastLoginUser { get; set; }

        public int Documents { get; set; }
    }
}