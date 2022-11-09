using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Datastore.Operators.Interfaces;
using Datastore.Context;
using Microsoft.Extensions.Logging;

namespace Datastore.Operators
{
    public class Reader : IReader
    {
        private readonly ILogger _logger;
        private readonly CosmosDbContext _context;
        public Reader(ILogger<Reader> logger, CosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public void Read<Entity>() where Entity : class
        {
            _context.FindAsync<Entity>();

        }
        public void Read<Entity>(Expression<Func<Entity, bool>> predicate) where Entity : class
        {
            _context.FindAsync<Entity>(predicate);
        }

       
    }
}
