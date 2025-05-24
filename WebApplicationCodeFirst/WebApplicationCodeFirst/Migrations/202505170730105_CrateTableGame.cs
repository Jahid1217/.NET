namespace WebApplicationCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrateTableGame : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tital = c.String(),
                        Price = c.String(),
                        Quanrity = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Games");
        }
    }
}
