using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datastore.Operators.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datastore.Models;
using Datastore.Context;

namespace Datastore.Operators
{
    public class Writer : IWriter
    {

        private readonly ILogger _logger;
        private readonly CosmosDbContext _context;
        public Writer(ILogger<Writer> logger, CosmosDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public void Write<Entity>(Entity obj) where Entity : class
        {
            _context.AddAsync<Entity>(obj);
        }

        public void Update<Entity>(Entity obj) where Entity : class
        {
            _context.Update<Entity>(obj);
        }
    }
}
