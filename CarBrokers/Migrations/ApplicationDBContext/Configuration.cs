namespace CarBrokers.Migrations.ApplicationDbContext
{
    using CarBrokers.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarBrokers.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationDbContext";
            ContextKey = "CarBrokers.Models.ApplicationDbContext";
        }

        protected override void Seed(CarBrokers.Models.ApplicationDbContext context)
        {
            var Roles = new List<ApplicationRole>
            {
                new ApplicationRole{Id = "1", Name = "Admin" },
                new ApplicationRole{Id = "2", Name = "Customer"},
                new ApplicationRole{Id = "3", Name = "Broker"}

            };
            Roles.ForEach(r => context.ApplicationRoles.AddOrUpdate(r));
            context.SaveChanges();
        }
    }
}
