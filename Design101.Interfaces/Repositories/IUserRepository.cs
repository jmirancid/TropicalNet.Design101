using Design101.Entities;
using Framework.Interfaces.Repositories;

namespace Design101.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetLastLoginUser();
    }
}
