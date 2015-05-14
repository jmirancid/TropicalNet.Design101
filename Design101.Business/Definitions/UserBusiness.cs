using Design101.Entities;
using Design101.Interfaces.Repositories;
using Framework.Business.Definitions;

namespace Design101.Business.Definitions
{
    public class UserBusiness : Business<User, IUserRepository>
    {
        public User GetLastLoginUser()
        {
            return base.Repository.Value.GetLastLoginUser();
        }
    }
}
