namespace WebApplicationApiPor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Products (Name, Description, Price, PriceTotal) VALUES ('Product1', 'Description1', 10.00, 10.00)");
            Sql("INSERT INTO Products (Name, Description, Price, PriceTotal) VALUES ('Product2', 'Description2', 20.00, 20.00)");
            Sql("INSERT INTO Products (Name, Description, Price, PriceTotal) VALUES ('Product3', 'Description3', 30.00, 30.00)");
            Sql("INSERT INTO Products (Name, Description, Price, PriceTotal) VALUES ('Product4', 'Description4', 40.00, 40.00)");
            Sql("INSERT INTO Products (Name, Description, Price, PriceTotal) VALUES ('Product5', 'Description5', 50.00, 50.00)");
        }
        
        public override void Down()
        {
        }
    }
}
