namespace OKVGU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Day = c.Int(nullable: false),
                        Week = c.Int(nullable: false),
                        SubjectSemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Schedules");
        }
    }
}
