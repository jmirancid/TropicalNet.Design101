using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Web.Mvc;
using Design101.WebSite.Scripts.Filemanager.Connectors.Mvc;

namespace Design101.WebSite.Areas.Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    public class DocumentController : FilemanagerController
    {
        private NameValueCollection _fmConfig =
            ConfigurationManager.GetSection("filemanager") as NameValueCollection;

        public override string RootPath
        {
            get
            {
                return this._fmConfig["RootPath"];
            }
        }

        public override string IconDirectory
        {
            get { return this._fmConfig["IconDirectory"]; }
        }

        public override ActionResult Index(string mode, string path = null)
        {
            var exclusiveFolder =
                Request.QueryString["exclusiveFolder"];

            if (!string.IsNullOrWhiteSpace(exclusiveFolder))
            {
                var v = RootPath;
                var r = Server.MapPath(v);

                var f = Path.Combine(r, exclusiveFolder);

                if (!Directory.Exists(f))
                {
                    Directory.CreateDirectory(f);
                }
            }

            return View();
        }

        public ActionResult Execute(string mode, string path = null)
        {
            return base.Index(mode, path);
        }
    }
}
