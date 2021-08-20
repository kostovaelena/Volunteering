namespace Volunteering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategorijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organizacijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrganizacijaKategorijas",
                c => new
                    {
                        Organizacija_Id = c.Int(nullable: false),
                        Kategorija_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Organizacija_Id, t.Kategorija_Id })
                .ForeignKey("dbo.Organizacijas", t => t.Organizacija_Id, cascadeDelete: true)
                .ForeignKey("dbo.Kategorijas", t => t.Kategorija_Id, cascadeDelete: true)
                .Index(t => t.Organizacija_Id)
                .Index(t => t.Kategorija_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrganizacijaKategorijas", "Kategorija_Id", "dbo.Kategorijas");
            DropForeignKey("dbo.OrganizacijaKategorijas", "Organizacija_Id", "dbo.Organizacijas");
            DropIndex("dbo.OrganizacijaKategorijas", new[] { "Kategorija_Id" });
            DropIndex("dbo.OrganizacijaKategorijas", new[] { "Organizacija_Id" });
            DropTable("dbo.OrganizacijaKategorijas");
            DropTable("dbo.Organizacijas");
            DropTable("dbo.Kategorijas");
        }
    }
}
