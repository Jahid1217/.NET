namespace WebApplicationCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrateTableGameupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "Tital", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "Tital", c => c.String());
        }
    }
}
