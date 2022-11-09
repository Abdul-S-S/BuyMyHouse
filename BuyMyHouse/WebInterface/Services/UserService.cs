using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyMyHouse.Interfaces;
using Datastore.Operators.Interfaces;
using Microsoft.Extensions.Logging;
using Datastore.Models;
using System.Linq.Expressions;

namespace BuyMyHouse.Services
{
    internal class UserService : IUserService
    {
        private readonly ILogger _logger;
        private readonly IDBUnitOfWork _dbUnitOfWork;
        public UserService(ILogger<UserService> logger, IDBUnitOfWork dBUnitOfWork)
        {
            _logger = logger;
            _dbUnitOfWork = dBUnitOfWork;
        }

        public void GetUsers(Expression<Func<User, bool>> predicate)
        {
            _dbUnitOfWork.Reader.Read<User>(predicate);
        }

        public void GetUsers()
        {
            _dbUnitOfWork.Reader.Read<User>();
        }

        public void WriteUser(User user)
        {
            _dbUnitOfWork.Writer.Write<User>(user);
        }
    }
}
