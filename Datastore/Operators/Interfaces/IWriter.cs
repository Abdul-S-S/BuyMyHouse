using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastore.Operators.Interfaces
{
    public interface IWriter
    {
        void Write<T>(T obj) where T : class;
        void Write<Entity>(IList<Entity> objList) where Entity : class;
    }
}
