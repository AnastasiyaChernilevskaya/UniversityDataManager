namespace UniversityDataManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ChangedDate = c.DateTime(nullable: false),
                        Professor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professors", t => t.Professor_Id)
                .Index(t => t.Professor_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Name = c.String(),
                        Hours = c.Double(nullable: false),
                        MaxRating = c.Double(nullable: false),
                        Description = c.String(),
                        Comments = c.String(),
                        DisciplineId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ChangedDate = c.DateTime(nullable: false),
                        Professor_Id = c.Int(),
                        Creator_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professors", t => t.Professor_Id)
                .ForeignKey("dbo.Professors", t => t.Creator_Id)
                .ForeignKey("dbo.Disciplines", t => t.DisciplineId, cascadeDelete: true)
                .Index(t => t.DisciplineId)
                .Index(t => t.Professor_Id)
                .Index(t => t.Creator_Id);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ChangedDate = c.DateTime(nullable: false),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        StudentId = c.Int(),
                        ProfessorId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ChangedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ChangedDate = c.DateTime(nullable: false),
                        Group_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.GroupId)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ChangedDate = c.DateTime(nullable: false),
                        Praepostor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Praepostor_Id)
                .Index(t => t.Praepostor_Id);
            
            CreateTable(
                "dbo.StudentProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Double(nullable: false),
                        ProjectState = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        ProfessorId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ChangedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Professors", t => t.ProfessorId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.StudentId)
                .Index(t => t.ProfessorId);
            
            CreateTable(
                "dbo.ProjectLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OldProjectState = c.Int(nullable: false),
                        NewProjectState = c.Int(nullable: false),
                        StudentProjectId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ChangedDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentProjects", t => t.StudentProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.StudentProjectId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.GroupProjects",
                c => new
                    {
                        Group_Id = c.Int(nullable: false),
                        Project_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_Id, t.Project_Id })
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .Index(t => t.Group_Id)
                .Index(t => t.Project_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Professors", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Projects", "DisciplineId", "dbo.Disciplines");
            DropForeignKey("dbo.Projects", "Creator_Id", "dbo.Professors");
            DropForeignKey("dbo.Students", "Id", "dbo.Users");
            DropForeignKey("dbo.StudentProjects", "StudentId", "dbo.Students");
            DropForeignKey("dbo.ProjectLogs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.ProjectLogs", "StudentProjectId", "dbo.StudentProjects");
            DropForeignKey("dbo.StudentProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.StudentProjects", "ProfessorId", "dbo.Professors");
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Students", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.GroupProjects", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.GroupProjects", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Groups", "Praepostor_Id", "dbo.Students");
            DropForeignKey("dbo.Professors", "Id", "dbo.Users");
            DropForeignKey("dbo.Disciplines", "Professor_Id", "dbo.Professors");
            DropForeignKey("dbo.Projects", "Professor_Id", "dbo.Professors");
            DropIndex("dbo.GroupProjects", new[] { "Project_Id" });
            DropIndex("dbo.GroupProjects", new[] { "Group_Id" });
            DropIndex("dbo.ProjectLogs", new[] { "User_Id" });
            DropIndex("dbo.ProjectLogs", new[] { "StudentProjectId" });
            DropIndex("dbo.StudentProjects", new[] { "ProfessorId" });
            DropIndex("dbo.StudentProjects", new[] { "StudentId" });
            DropIndex("dbo.StudentProjects", new[] { "ProjectId" });
            DropIndex("dbo.Groups", new[] { "Praepostor_Id" });
            DropIndex("dbo.Students", new[] { "Group_Id" });
            DropIndex("dbo.Students", new[] { "GroupId" });
            DropIndex("dbo.Students", new[] { "Id" });
            DropIndex("dbo.Professors", new[] { "Project_Id" });
            DropIndex("dbo.Professors", new[] { "Id" });
            DropIndex("dbo.Projects", new[] { "Creator_Id" });
            DropIndex("dbo.Projects", new[] { "Professor_Id" });
            DropIndex("dbo.Projects", new[] { "DisciplineId" });
            DropIndex("dbo.Disciplines", new[] { "Professor_Id" });
            DropTable("dbo.GroupProjects");
            DropTable("dbo.ProjectLogs");
            DropTable("dbo.StudentProjects");
            DropTable("dbo.Groups");
            DropTable("dbo.Students");
            DropTable("dbo.Users");
            DropTable("dbo.Professors");
            DropTable("dbo.Projects");
            DropTable("dbo.Disciplines");
        }
    }
}
