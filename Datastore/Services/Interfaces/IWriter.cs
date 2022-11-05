using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastore.Interfaces
{
    public interface IWriter
    {
        string Read<T>(T obj);
    }
}
