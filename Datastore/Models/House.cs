using System;

namespace Datastore.Models
{
    public class House
    {
        public string ID { get; set; }
        public double Price { get; set; }
        public double Name { get; set; }
        public DateTime Created { get; set; }

        public House( double price, double name, DateTime created)
        {
            ID = Guid.NewGuid().ToString();
            Price = price;
            Name = name;
            Created = created;
        }

        public House()
        {
            ID = Guid.NewGuid().ToString();
        }
    }
}
