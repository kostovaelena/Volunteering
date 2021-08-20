namespace Volunteering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eko : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organizacijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                        Opis = c.String(nullable: false),
                        Slika = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Organizacijas");
        }
    }
}
