namespace webapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201510031443175_InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stud",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Grade = c.String(maxLength: 2),
                        DateOfBirth = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Wines");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Wines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Grapes = c.String(),
                        Country = c.String(),
                        Region = c.String(),
                        Description = c.String(),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Stud");
        }
    }
}
