using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datastore.Operators.Interfaces;
using Datastore;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;

namespace Datastore.Operators
{
    public class DBUnitOfWork : IDBUnitOfWork
    {
        private readonly ILogger _logger;
        public IReader Reader { get; set; }
        public IWriter Writer { get; set; }
        public DBUnitOfWork(ILogger<DBUnitOfWork> logger, IReader reader, IWriter writer)
        {
            Reader = reader;
            Writer = writer;
            _logger = logger;
        }
    }
}
