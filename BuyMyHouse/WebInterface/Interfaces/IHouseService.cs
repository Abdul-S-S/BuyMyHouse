using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Datastore.Models;


namespace BuyMyHouse.Interfaces
{
    public  interface IHouseService
    {
        public void GetHouses();
        public void GetHouses(double minimumPrice, double maximumPrice);
        public void GetHouses(Expression<Func<House, bool>> predicate);
    }
}
