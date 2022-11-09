using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Datastore.Operators.Interfaces
{
    public interface IReader
    {
        DbSet<Entity>? Read<Entity>(Func<Entity, bool> predicate) where Entity : class;
        Entity? Read<Entity>(string id) where Entity : class;

        DbSet<Entity> Read<Entity>() where Entity : class;
    }
}
