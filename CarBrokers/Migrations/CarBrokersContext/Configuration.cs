using System.Collections.Generic;
using CarBrokers.Models;

namespace CarBrokers.Migrations.CarBrokersContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarBrokers.DAL.CarBrokersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\CarBrokersContext";
        }

        protected override void Seed(CarBrokers.DAL.CarBrokersContext context)
        {
            var cars = new List<Car>
            {
                new Car {Make = "Honda", Model = "Civic EX", Miles = 10, Year = 2018, Price = 25000},
                new Car {Make = "Nissan", Model = "Altima", Miles = 20, Year = 2018, Price = 25000},
                new Car {Make = "Hyundai", Model = "Sonata", Miles = 3000, Year = 2018, Price = 35000}
            };

            cars.ForEach(s => context.Cars.AddOrUpdate(p => p.Model, s));
            context.SaveChanges();


            var carRequests = new List<CarRequest>
            {
                new CarRequest{
                    CarID = cars.First(s => s.Model == "Civic EX").ID,
                    Price = 23000, CustomerID = "da4c67f8-0f80-465e-939a-49b6ef55f1ba", BrokerID = "95ff0e0a-3a83-4c03-a344-f43a9a860e04" },
                new CarRequest{
                    CarID = cars.First(s => s.Model == "Sonata").ID,
                    Price = 25000, CustomerID = "da4c67f8-0f80-465e-939a-49b6ef55f1ba", BrokerID = "95ff0e0a-3a83-4c03-a344-f43a9a860e04" }
            };

            carRequests.ForEach(s => context.CarRequests.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
    
}
