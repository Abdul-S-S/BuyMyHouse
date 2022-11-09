using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Datastore.Operators.Interfaces;
using Datastore.Context;
using Microsoft.Extensions.Logging;
using Datastore.Models;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Entity>? Read<Entity>() where Entity : class
        {
            if (typeof(Entity) == typeof(User))
            {
                return _context.Users as DbSet<Entity>;
            }
            else if(typeof(Entity) == typeof(House))
            {
                return _context.Houses as DbSet<Entity>;
            }
            return null;

        }
        public Entity? Read<Entity>(string id) where Entity : class
        {
            if (typeof(Entity) == typeof(User))
            {
                return (Entity)_context.Users.Where(u => u.ID == id).ToList().Select(u => u);
            }
            else if (typeof(Entity) == typeof(House))
            {
                return (Entity)_context.Users.Where(u => u.ID == id).ToList().Select(u => u);
            }
            return null;

        }
        public DbSet<Entity>? Read<Entity>(Func<Entity, bool> predicate) where Entity : class
        {
            if (typeof(Entity) == typeof(User))
            {
                return _context.Users.ToList().Where((Func<User, bool>)predicate) as DbSet<Entity>;
            }
            else if (typeof(Entity) == typeof(House))
            {
                return _context.Houses.ToList().Where((Func<House, bool>)predicate) as DbSet<Entity>;
            }
            return null;

        }
    }
}
