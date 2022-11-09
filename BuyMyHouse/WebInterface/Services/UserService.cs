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
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace BuyMyHouse.Services
{
    internal class UserService : IUserService
    {
        private readonly ILogger _logger;
        private readonly IDBUnitOfWork _dbUnitOfWork;
        static bool AddedDummyData;

        public UserService(ILogger<UserService> logger, IDBUnitOfWork dBUnitOfWork)
        {
            _logger = logger;
            _dbUnitOfWork = dBUnitOfWork;
            if (!AddedDummyData)
            {
                AddDummyData();
            }
        }
        private void AddDummyData()
        {
            string path = Environment.GetEnvironmentVariable("DummyDataPath");
            JObject dummyData = JObject.Parse(File.ReadAllText(path));
            JArray dummyhouses = JArray.Parse(dummyData["Users"].ToString());
            IList<User> users = dummyhouses.Select(x => JsonConvert.DeserializeObject<User>(x.ToString())).ToList();
            SaveUsers(users);
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
        public void SaveUsers(IList<User> users)
        {
            _dbUnitOfWork.Writer.Write(users);
        }
    }
}
