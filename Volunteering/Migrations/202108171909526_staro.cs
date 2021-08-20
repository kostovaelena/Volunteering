namespace Volunteering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class staro : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PrijavaOrganizacijas", "Prijava_Id", "dbo.Prijavas");
            DropForeignKey("dbo.PrijavaOrganizacijas", "Organizacija_Id", "dbo.Organizacijas");
            DropIndex("dbo.PrijavaOrganizacijas", new[] { "Prijava_Id" });
            DropIndex("dbo.PrijavaOrganizacijas", new[] { "Organizacija_Id" });
            DropTable("dbo.PrijavaOrganizacijas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PrijavaOrganizacijas",
                c => new
                    {
                        Prijava_Id = c.Int(nullable: false),
                        Organizacija_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Prijava_Id, t.Organizacija_Id });
            
            CreateIndex("dbo.PrijavaOrganizacijas", "Organizacija_Id");
            CreateIndex("dbo.PrijavaOrganizacijas", "Prijava_Id");
            AddForeignKey("dbo.PrijavaOrganizacijas", "Organizacija_Id", "dbo.Organizacijas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PrijavaOrganizacijas", "Prijava_Id", "dbo.Prijavas", "Id", cascadeDelete: true);
        }
    }
}
