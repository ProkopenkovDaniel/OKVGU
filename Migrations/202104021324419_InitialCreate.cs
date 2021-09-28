namespace OKVGU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Course = c.Int(nullable: false),
                        SpecialtyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.GroupSemesters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                        NumberOfWeeks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.SubjectSemesters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.GroupId)
                .Index(t => t.SemesterId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsPedSpec = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsPractice = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TeacherSubjects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Patronym = c.String(),
                        IsAdm = c.Boolean(nullable: false),
                        IsSocWorker = c.Boolean(nullable: false),
                        HoursPerYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherSubjects", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.SubjectSemesters", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SubjectSemesters", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SubjectSemesters", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.GroupSemesters", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.SubjectSemesters", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.GroupSemesters", "GroupId", "dbo.Groups");
            DropIndex("dbo.TeacherSubjects", new[] { "SubjectId" });
            DropIndex("dbo.TeacherSubjects", new[] { "TeacherId" });
            DropIndex("dbo.SubjectSemesters", new[] { "TeacherId" });
            DropIndex("dbo.SubjectSemesters", new[] { "SemesterId" });
            DropIndex("dbo.SubjectSemesters", new[] { "GroupId" });
            DropIndex("dbo.SubjectSemesters", new[] { "SubjectId" });
            DropIndex("dbo.GroupSemesters", new[] { "SemesterId" });
            DropIndex("dbo.GroupSemesters", new[] { "GroupId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.TeacherSubjects");
            DropTable("dbo.Subjects");
            DropTable("dbo.Specialties");
            DropTable("dbo.Semesters");
            DropTable("dbo.SubjectSemesters");
            DropTable("dbo.GroupSemesters");
            DropTable("dbo.Groups");
        }
    }
}
