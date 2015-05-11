using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Design101.Business.Definitions;
using Design101.Entities;
using Design101.WebSite.Scripts.Filemanager.Connectors.Mvc;

namespace Design101.WebSite.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
    public class DocumentController : FilemanagerController
    {
        private NameValueCollection _fmConfig =
            ConfigurationManager.GetSection("filemanager") as NameValueCollection;

        private Lazy<UserBusiness> _bizUser =
            new Lazy<UserBusiness>();

        private Lazy<DocumentBusiness> _bizDocument =
            new Lazy<DocumentBusiness>();

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
            var expandedFolder =
                Request.QueryString["expandedFolder"];

            if (!string.IsNullOrWhiteSpace(expandedFolder))
            {
                ResolveUserFolder(expandedFolder);
            }

            return View();
        }

        public ActionResult Execute(string mode, string path = null)
        {
            return base.Index(mode, path);
        }

        public override string AddFile(string path)
        {
            try
            {
                var c = base.AddFile(path);
                var f = new DirectoryInfo(path);

                var t = Regex.Replace(c, "<.*?>", string.Empty);

                var data = base.json.Deserialize<dynamic>(t);
                var user = _bizUser.Value.GetBy(x => x.Username == f.Name);

                var doc = new Document()
                {
                    UserId = user.Id,
                    Name = Path.GetFileNameWithoutExtension(data["Name"]),
                    Path = data["Name"],
                    Enabled = true,
                    Assigned = Context.Current.GetNowUTC
                };

                _bizDocument.Value.Create(doc);
                return c;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string Rename(string path, string newName)
        {
            try
            {
                var c = base.Rename(path, newName);
                var f = Path.GetFileName(path);

                var d = this._bizDocument.Value.GetBy(x => x.Path == f);
                d.Name = Path.GetFileNameWithoutExtension(newName);
                d.Path = newName;

                this._bizDocument.Value.Update(d);
                return c;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string Delete(string path)
        {
            try
            {
                var c = base.Delete(path);

                var f = Path.GetFileName(path);
                var d = this._bizDocument.Value.GetBy(x => x.Path == f);

                this._bizDocument.Value.Delete(d);
                return c;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ResolveUserFolder(string folder)
        {
            var v = this._fmConfig["RootPath"];
            var r = Server.MapPath(v);

            var f = Path.Combine(r, folder);

            if (!IsUserFolderExist(f))
            {
                Directory.CreateDirectory(f);
            }
        }

        private bool IsUserFolderExist(string f)
        {
            return Directory.Exists(f);
        }
    }
}
