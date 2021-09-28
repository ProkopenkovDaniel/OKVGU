namespace OKVGU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_FK_ScheduleInstanceId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "ScheduleInstanceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schedules", "ScheduleInstanceId");
        }
    }
}
