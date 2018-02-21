using CarBrokers.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CarBrokers.DAL {
    public class CarBrokersContext : DbContext {

        public CarBrokersContext() : base("CarBrokersContext") {

        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarRequest> CarRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}