using Design101.Entities;
using Design101.Interfaces.Repositories;

namespace Design101.Repositories.Definitions
{
    public class UserRepository : Repository<User>, IUserRepository
    {
    }
}
