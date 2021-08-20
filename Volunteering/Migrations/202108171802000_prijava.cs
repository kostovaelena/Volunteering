namespace Volunteering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prijava : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prijavas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                        Prezime = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Prijavas");
        }
    }
}
