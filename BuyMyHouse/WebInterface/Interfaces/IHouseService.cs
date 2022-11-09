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
        public List<House> GetHouses();
        public List<House> GetHouses(double minimumPrice, double maximumPrice);
        public List<House> GetHouses(Func<House, bool> predicate);
        public void SaveHouses(IList<House> houses);
    }
}
