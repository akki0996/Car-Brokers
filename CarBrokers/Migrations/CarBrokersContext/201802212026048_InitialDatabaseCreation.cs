namespace CarBrokers.Migrations.CarBrokersContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarRequest",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        CustomerID = c.String(),
                        BrokerID = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        Miles = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarRequest", "CarID", "dbo.Car");
            DropIndex("dbo.CarRequest", new[] { "CarID" });
            DropTable("dbo.Car");
            DropTable("dbo.CarRequest");
        }
    }
}
