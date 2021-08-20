namespace Volunteering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VolonterskiAngazmen", "Kategorija_Id", "dbo.Kategorijas");
            DropIndex("dbo.VolonterskiAngazmen", new[] { "Kategorija_Id" });
            AddColumn("dbo.VolonterskiAngazmen", "Organizacija", c => c.String());
            DropColumn("dbo.VolonterskiAngazmen", "Kategorija_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VolonterskiAngazmen", "Kategorija_Id", c => c.Int());
            DropColumn("dbo.VolonterskiAngazmen", "Organizacija");
            CreateIndex("dbo.VolonterskiAngazmen", "Kategorija_Id");
            AddForeignKey("dbo.VolonterskiAngazmen", "Kategorija_Id", "dbo.Kategorijas", "Id");
        }
    }
}
