using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BuyMyHouse.Interfaces;
using Datastore.Context;
using Datastore.Models;
using Datastore.Operators;
using Datastore.Operators.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;

namespace BuyMyHouse.Services
{
    internal class HouseService : IHouseService
    {
        private readonly ILogger _logger;
        private readonly IDBUnitOfWork _dbUnitOfWork;
        static bool AddedDummyData;
        public HouseService(ILogger<HouseService> logger, IDBUnitOfWork dBUnitOfWork )
        {
            _logger = logger;
            _dbUnitOfWork = dBUnitOfWork;
            if (!AddedDummyData)
            {
                AddDummyData();
                AddedDummyData =true;
            }
        }

        private void AddDummyData()
        
        {
            string path = Environment.GetEnvironmentVariable("DummyDataPath");
            JObject dummyData = JObject.Parse(File.ReadAllText(path));
            JArray dummyhouses = JArray.Parse(dummyData["Houses"].ToString());
            IList<House> houses = dummyhouses.Select(x => JsonConvert.DeserializeObject<House>(x.ToString())).ToList();
            SaveHouses(houses);
        }

        public List<House> GetHouses()
        {
            return _dbUnitOfWork.Reader.Read<House>().ToList();
        }

        public List<House> GetHouses(double minimumPrice, double maximumPrice)
        {
            return _dbUnitOfWork.Reader.Read<House>(h => h.Price > minimumPrice && h.Price < maximumPrice).ToList();
        }

        public List<House> GetHouses(Func<House, bool> predicate)
        {
            return _dbUnitOfWork.Reader.Read<House>(predicate).ToList();
        }
        public void SaveHouses(IList<House> houses)
        {
            _dbUnitOfWork.Writer.Write(houses);
        }

    }
}
