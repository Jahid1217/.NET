namespace WebApplicationLoginApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateLogin2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Log_Info", "Gender", c => c.Int(nullable: false));
            AlterColumn("dbo.Log_Info", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Log_Info", "BloodGroup", c => c.Int(nullable: false));
            AlterColumn("dbo.Log_Info", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Log_Info", "UserType", c => c.Int(nullable: false));
            DropColumn("dbo.Log_Info", "Gander");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Log_Info", "Gander", c => c.String(nullable: false));
            AlterColumn("dbo.Log_Info", "UserType", c => c.String());
            AlterColumn("dbo.Log_Info", "Status", c => c.String());
            AlterColumn("dbo.Log_Info", "BloodGroup", c => c.String(nullable: false));
            AlterColumn("dbo.Log_Info", "Phone", c => c.String(nullable: false, maxLength: 11));
            DropColumn("dbo.Log_Info", "Gender");
        }
    }
}
