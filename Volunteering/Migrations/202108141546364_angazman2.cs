namespace Volunteering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class angazman2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VolonterskiAngazmen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mesto = c.String(nullable: false),
                        Datum = c.String(nullable: false),
                        Kategorija_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kategorijas", t => t.Kategorija_Id, cascadeDelete: true)
                .Index(t => t.Kategorija_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VolonterskiAngazmen", "Kategorija_Id", "dbo.Kategorijas");
            DropIndex("dbo.VolonterskiAngazmen", new[] { "Kategorija_Id" });
            DropTable("dbo.VolonterskiAngazmen");
        }
    }
}
