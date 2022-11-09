using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastore.Operators.Interfaces
{
    public interface IDBUnitOfWork
    {
        IReader Reader { get; set; }
        IWriter Writer { get; set; }
    }
}
