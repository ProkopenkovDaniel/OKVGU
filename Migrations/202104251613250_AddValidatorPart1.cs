namespace OKVGU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidatorPart1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groups", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Semesters", "Year", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Semesters", "Year", c => c.String());
            AlterColumn("dbo.Groups", "Title", c => c.String());
        }
    }
}
