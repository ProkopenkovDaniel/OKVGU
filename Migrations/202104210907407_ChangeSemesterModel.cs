namespace OKVGU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSemesterModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Semesters", "Year", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Semesters", "Year", c => c.Int(nullable: false));
        }
    }
}
