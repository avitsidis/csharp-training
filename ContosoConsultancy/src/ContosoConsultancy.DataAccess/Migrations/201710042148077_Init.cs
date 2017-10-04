namespace ContosoConsultancy.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultants",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        DisengagedDate = c.DateTime(),
                        Team_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Missions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Customer_Id = c.Long(),
                        Consultant_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Consultants", t => t.Consultant_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Consultant_Id);
            
            CreateTable(
                "dbo.Competencies",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Address_Street = c.String(),
                        Address_Number = c.String(),
                        Address_PostCode = c.String(),
                        Address_City = c.String(),
                        Address_Box = c.String(),
                        Address_Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Manager_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consultants", t => t.Manager_Id)
                .Index(t => t.Manager_Id);
            
            CreateTable(
                "dbo.MissionCompetencies",
                c => new
                    {
                        Mission_Id = c.Long(nullable: false),
                        Competency_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Mission_Id, t.Competency_Id })
                .ForeignKey("dbo.Missions", t => t.Mission_Id, cascadeDelete: true)
                .ForeignKey("dbo.Competencies", t => t.Competency_Id, cascadeDelete: true)
                .Index(t => t.Mission_Id)
                .Index(t => t.Competency_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultants", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Manager_Id", "dbo.Consultants");
            DropForeignKey("dbo.Missions", "Consultant_Id", "dbo.Consultants");
            DropForeignKey("dbo.Missions", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.MissionCompetencies", "Competency_Id", "dbo.Competencies");
            DropForeignKey("dbo.MissionCompetencies", "Mission_Id", "dbo.Missions");
            DropIndex("dbo.MissionCompetencies", new[] { "Competency_Id" });
            DropIndex("dbo.MissionCompetencies", new[] { "Mission_Id" });
            DropIndex("dbo.Teams", new[] { "Manager_Id" });
            DropIndex("dbo.Missions", new[] { "Consultant_Id" });
            DropIndex("dbo.Missions", new[] { "Customer_Id" });
            DropIndex("dbo.Consultants", new[] { "Team_Id" });
            DropTable("dbo.MissionCompetencies");
            DropTable("dbo.Teams");
            DropTable("dbo.Customers");
            DropTable("dbo.Competencies");
            DropTable("dbo.Missions");
            DropTable("dbo.Consultants");
        }
    }
}
