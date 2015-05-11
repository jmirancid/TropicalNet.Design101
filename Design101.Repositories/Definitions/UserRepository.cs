using System.Data.Entity;
using System.Linq;
using Design101.Entities;
using Design101.Interfaces.Repositories;

namespace Design101.Repositories.Definitions
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public override User GetBy(System.Linq.Expressions.Expression<System.Func<User, bool>> predicate)
        {
            return base.Context.User
                        .Include(x => x.Role)
                        .FirstOrDefault(predicate);
        }
    }
}
