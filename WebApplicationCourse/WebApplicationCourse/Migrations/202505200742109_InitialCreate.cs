namespace WebApplicationCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        type = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 80),
                        Launch = c.String(nullable: false, maxLength: 200),
                        Category = c.String(nullable: false, maxLength: 200),
                        Duration = c.String(nullable: false),
                        type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.type_Id)
                .Index(t => t.type_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "type_Id", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "type_Id" });
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
