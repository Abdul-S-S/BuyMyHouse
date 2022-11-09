using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Datastore.Models;

namespace BuyMyHouse.Interfaces
{
    public  interface IUserService
    {
        public void WriteUser(User user);
        public void GetUsers(Expression<Func<User, bool>> predicate);
        public void GetUsers();

    }
}
