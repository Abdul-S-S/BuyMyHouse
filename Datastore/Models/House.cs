using System;

namespace Datastore.Models
{
    public class House
    {
        public string ID { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }

        public House(string name, double price)
        {
            ID = Guid.NewGuid().ToString();
            Price = price;
            Name = name;
            Created = System.DateTime.Now;
        }

        public House()
        {
            ID = Guid.NewGuid().ToString();
        }
    }
}
