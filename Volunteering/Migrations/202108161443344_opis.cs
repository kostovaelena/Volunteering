namespace Volunteering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class opis : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VolonterskiAngazmen", "Opis");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VolonterskiAngazmen", "Opis", c => c.String(nullable: false));
        }
    }
}
