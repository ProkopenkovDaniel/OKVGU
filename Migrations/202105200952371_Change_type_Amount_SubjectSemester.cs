namespace OKVGU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_type_Amount_SubjectSemester : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SubjectSemesters", "Amount", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubjectSemesters", "Amount", c => c.Int(nullable: false));
        }
    }
}
