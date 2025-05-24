namespace WebApplicationCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistrationUpdate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 200),
                        Type = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Registrations");
        }
    }
}
