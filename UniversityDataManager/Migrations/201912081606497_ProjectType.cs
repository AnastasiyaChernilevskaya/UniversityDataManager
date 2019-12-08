namespace UniversityDataManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Type");
        }
    }
}
