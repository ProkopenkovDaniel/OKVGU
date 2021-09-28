namespace OKVGU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubSemPractice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubjectSemesters", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubjectSemesters", "Discriminator");
        }
    }
}
