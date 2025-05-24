namespace WebApplicationCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertDatatype : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.GameTypes (Type, Description) VALUES ('Action', 'Action games are characterized by physical challenges, including hand-eye coordination and reaction-time. They often involve a lot of fast-paced gameplay and require quick reflexes from the player.')");
        }
        
        public override void Down()
        {
        }
    }
}
