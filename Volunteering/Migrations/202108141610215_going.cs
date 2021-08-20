namespace Volunteering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class going : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VolonterskiAngazmen", "Kategorija_Id", "dbo.Kategorijas");
            DropIndex("dbo.VolonterskiAngazmen", new[] { "Kategorija_Id" });
            AddColumn("dbo.VolonterskiAngazmen", "Naslov", c => c.String(nullable: false));
            AddColumn("dbo.VolonterskiAngazmen", "Slika", c => c.String(nullable: false));
            AddColumn("dbo.VolonterskiAngazmen", "Opis", c => c.String(nullable: false));
            AddColumn("dbo.VolonterskiAngazmen", "Vreme", c => c.String(nullable: false));
            AlterColumn("dbo.VolonterskiAngazmen", "Kategorija_Id", c => c.Int());
            CreateIndex("dbo.VolonterskiAngazmen", "Kategorija_Id");
            AddForeignKey("dbo.VolonterskiAngazmen", "Kategorija_Id", "dbo.Kategorijas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VolonterskiAngazmen", "Kategorija_Id", "dbo.Kategorijas");
            DropIndex("dbo.VolonterskiAngazmen", new[] { "Kategorija_Id" });
            AlterColumn("dbo.VolonterskiAngazmen", "Kategorija_Id", c => c.Int(nullable: false));
            DropColumn("dbo.VolonterskiAngazmen", "Vreme");
            DropColumn("dbo.VolonterskiAngazmen", "Opis");
            DropColumn("dbo.VolonterskiAngazmen", "Slika");
            DropColumn("dbo.VolonterskiAngazmen", "Naslov");
            CreateIndex("dbo.VolonterskiAngazmen", "Kategorija_Id");
            AddForeignKey("dbo.VolonterskiAngazmen", "Kategorija_Id", "dbo.Kategorijas", "Id", cascadeDelete: true);
        }
    }
}
