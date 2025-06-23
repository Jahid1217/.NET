namespace WebApplicationAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedData33 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Messages");
            AddColumn("dbo.Messages", "Timestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "UserType", c => c.String());
            AlterColumn("dbo.Messages", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Messages", "Id");
            CreateIndex("dbo.Messages", "SenderId");
            CreateIndex("dbo.Messages", "ReceiverId");
            AddForeignKey("dbo.Messages", "ReceiverId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Messages", "SenderId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Messages", "MessageID");
            
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Role", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Messages", "SentAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Messages", "FilePath", c => c.String());
            AddColumn("dbo.Messages", "MessageID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Messages", "SenderId", "dbo.Users");
            DropForeignKey("dbo.Messages", "ReceiverId", "dbo.Users");
            DropIndex("dbo.Messages", new[] { "ReceiverId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropPrimaryKey("dbo.Messages");
            AlterColumn("dbo.Messages", "Id", c => c.Int(nullable: false));
            
            AddPrimaryKey("dbo.Messages", "MessageID");
        }
    }
}
