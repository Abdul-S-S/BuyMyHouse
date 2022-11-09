using Datastore.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Datastore.Context
{
    public class CosmosDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<MortgageOffer> MortgageOffers { get; set; }

        public CosmosDbContext(DbContextOptions<CosmosDbContext> contextOptions)
            : base(contextOptions)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                connectionString : Environment.GetEnvironmentVariable("connectionString"),
                databaseName: "BuyMyHouse");
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToContainer(nameof(Users))
                .HasPartitionKey(c => c.ID)
                .OwnsOne(c => c.MortgageOffer)
                .WithOwner(m => m.User);

            modelBuilder.Entity<House>()
                .ToContainer(nameof(Houses))
                .HasPartitionKey(h => h.ID);

            //modelBuilder.Entity<MortgageOffer>()
            //    .ToContainer("MortgageOffers")
            //    .HasPartitionKey(m => m.ID);

                

            base.OnModelCreating(modelBuilder);
        }

    }
}
