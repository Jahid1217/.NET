namespace WebApplicationAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedData2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        Content = c.String(),
                        FilePath = c.String(),
                        SentAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
        }
    }
}
