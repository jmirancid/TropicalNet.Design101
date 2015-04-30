using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Design101.Repositories.Definitions
{
    public class Repository<TEntity> : Framework.Repositories.Definitions.Repository<Design101Entities, TEntity>
		where TEntity : class, new()
	{
	}
}
