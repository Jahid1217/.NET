namespace WebApplicationLoginApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateLogin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctor_Type",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        doctorType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Log_Info",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        Title = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 200),
                        Gander = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 11),
                        BloodGroup = c.String(nullable: false),
                        NID = c.String(nullable: false, maxLength: 20),
                        RegistrationNo = c.String(nullable: false, maxLength: 20),
                        Department = c.String(maxLength: 50),
                        DocType = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(nullable: false, maxLength: 100),
                        Image = c.String(nullable: false, maxLength: 200),
                        Status = c.String(nullable: false),
                        UserType = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        DoctorTypes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctor_Type", t => t.DoctorTypes_Id)
                .Index(t => t.DoctorTypes_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Log_Info", "DoctorTypes_Id", "dbo.Doctor_Type");
            DropIndex("dbo.Log_Info", new[] { "DoctorTypes_Id" });
            DropTable("dbo.Log_Info");
            DropTable("dbo.Doctor_Type");
        }
    }
}
