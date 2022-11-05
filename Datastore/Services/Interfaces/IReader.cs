using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastore.Interfaces
{
    public  interface IReader
    {
        string Write<T>(T obj);
    }
}
