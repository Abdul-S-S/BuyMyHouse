using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastore.Operators.Interfaces
{
    public interface IWriter
    {
        Task Write<T>(T obj) where T : class;
        Task Write<Entity>(IList<Entity> objList) where Entity : class;
        public Task Update<Entity>(Entity obj) where Entity : class;
        public Task Update<Entity>(IList<Entity> objList) where Entity : class;


    }
}
