namespace WebApplicationCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrateTableGameUpdateforce : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "GameTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Games", "GameTypeId");
            AddForeignKey("dbo.Games", "GameTypeId", "dbo.GameTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "GameTypeId", "dbo.GameTypes");
            DropIndex("dbo.Games", new[] { "GameTypeId" });
            DropColumn("dbo.Games", "GameTypeId");
            DropTable("dbo.GameTypes");
        }
    }
}
