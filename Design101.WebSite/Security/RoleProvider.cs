using System;
using Design101.Business.Definitions;

namespace Design101.WebSite.Security
{
    public class RoleProvider : System.Web.Security.RoleProvider
    {
        private RoleBusiness _bizRole =
            new RoleBusiness();

        private UserBusiness _bizUser =
            new UserBusiness();

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var u =
                this._bizUser.GetBy(x => x.Username == username);

            if (u == null)
                throw new NullReferenceException();

            return new string[] { u.Role.Name };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var u =
                this._bizUser.GetBy(x => x.Username == username);

            if (u == null)
                throw new NullReferenceException();

            return u.RoleId == Enum.Parse(typeof(Design101.Entities.Role_Enum), roleName) as Nullable<int>;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}