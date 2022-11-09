using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datastore.Operators.Interfaces
{
    public  interface IReader
    {
        void Read<Entity>(Expression<Func<Entity, bool>> predicate) where Entity : class;

        void Read<Entity>() where Entity : class;
    }
}
