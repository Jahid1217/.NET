namespace WebApplicationAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Games (Title, Price, Quantity) VALUES ('Game1', 29.99, 100)");
            Sql("INSERT INTO Games (Title, Price, Quantity) VALUES ('Game2', 49.99, 50)");
            Sql("INSERT INTO Games (Title, Price, Quantity) VALUES ('Game3', 19.99, 200)");
            Sql("INSERT INTO Games (Title, Price, Quantity) VALUES ('Game4', 39.99, 75)");
            Sql("INSERT INTO Games (Title, Price, Quantity) VALUES ('Game5', 59.99, 30)");
            Sql("INSERT INTO Games (Title, Price, Quantity) VALUES ('Game6', 15.99, 150)");
            Sql("INSERT INTO Games (Title, Price, Quantity) VALUES ('Game7', 25.99, 120)");
            Sql("INSERT INTO Games (Title, Price, Quantity) VALUES ('Game8', 45.99, 80)");
            Sql("INSERT INTO Games (Title, Price, Quantity) VALUES ('Game9', 35.99, 60)");
        }
        
        public override void Down()
        {
        }
    }
}
