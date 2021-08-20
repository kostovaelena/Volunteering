namespace Volunteering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrganizacijaKategorijas", "Organizacija_Id", "dbo.Organizacijas");
            DropForeignKey("dbo.OrganizacijaKategorijas", "Kategorija_Id", "dbo.Kategorijas");
            DropIndex("dbo.OrganizacijaKategorijas", new[] { "Organizacija_Id" });
            DropIndex("dbo.OrganizacijaKategorijas", new[] { "Kategorija_Id" });
            DropTable("dbo.Organizacijas");
            DropTable("dbo.OrganizacijaKategorijas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrganizacijaKategorijas",
                c => new
                    {
                        Organizacija_Id = c.Int(nullable: false),
                        Kategorija_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Organizacija_Id, t.Kategorija_Id });
            
            CreateTable(
                "dbo.Organizacijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.OrganizacijaKategorijas", "Kategorija_Id");
            CreateIndex("dbo.OrganizacijaKategorijas", "Organizacija_Id");
            AddForeignKey("dbo.OrganizacijaKategorijas", "Kategorija_Id", "dbo.Kategorijas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrganizacijaKategorijas", "Organizacija_Id", "dbo.Organizacijas", "Id", cascadeDelete: true);
        }
    }
}
