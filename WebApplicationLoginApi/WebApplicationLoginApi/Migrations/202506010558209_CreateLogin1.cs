namespace WebApplicationLoginApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateLogin1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Log_Info", "Title", c => c.String());
            AlterColumn("dbo.Log_Info", "NID", c => c.String(maxLength: 20));
            AlterColumn("dbo.Log_Info", "RegistrationNo", c => c.String(maxLength: 20));
            AlterColumn("dbo.Log_Info", "DocType", c => c.String());
            AlterColumn("dbo.Log_Info", "Image", c => c.String(maxLength: 200));
            AlterColumn("dbo.Log_Info", "Status", c => c.String());
            AlterColumn("dbo.Log_Info", "UserType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Log_Info", "UserType", c => c.String(nullable: false));
            AlterColumn("dbo.Log_Info", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.Log_Info", "Image", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Log_Info", "DocType", c => c.String(nullable: false));
            AlterColumn("dbo.Log_Info", "RegistrationNo", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Log_Info", "NID", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Log_Info", "Title", c => c.String(nullable: false));
        }
    }
}
