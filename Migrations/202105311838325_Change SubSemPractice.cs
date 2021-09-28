namespace OKVGU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSubSemPractice : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SubjectSemesters", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubjectSemesters", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
