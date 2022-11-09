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
        public async Task Write<Entity>(Entity obj) where Entity : class
        {
            await _context.AddAsync<Entity>(obj);
            await _context.SaveChangesAsync();
        }
        public async Task Write<Entity>(IList<Entity> objList) where Entity : class
        {
            await _context.AddRangeAsync(objList);
            await _context.SaveChangesAsync();
        }

        public async Task Update<Entity>(Entity obj) where Entity : class
        {
             _context.Update<Entity>(obj);
            await _context.SaveChangesAsync();

        }
        public async Task Update<Entity>(IList<Entity> objList) where Entity : class
        {
            _context.UpdateRange(objList);
            await _context.SaveChangesAsync();

        }
    }
}
