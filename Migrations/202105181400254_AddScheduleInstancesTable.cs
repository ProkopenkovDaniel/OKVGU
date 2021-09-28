namespace OKVGU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddScheduleInstancesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScheduleInstances",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        public override void Down()
        {
            DropTable("dbo.ScheduleInstances");
        }
    }
}
