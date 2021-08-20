namespace Volunteering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aman : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrganizacijaDonirajs", "Organizacija_Id", "dbo.Organizacijas");
            DropForeignKey("dbo.OrganizacijaDonirajs", "Doniraj_Id", "dbo.Donirajs");
            DropIndex("dbo.OrganizacijaDonirajs", new[] { "Organizacija_Id" });
            DropIndex("dbo.OrganizacijaDonirajs", new[] { "Doniraj_Id" });
            DropTable("dbo.Donirajs");
            DropTable("dbo.OrganizacijaDonirajs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrganizacijaDonirajs",
                c => new
                    {
                        Organizacija_Id = c.Int(nullable: false),
                        Doniraj_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Organizacija_Id, t.Doniraj_Id });
            
            CreateTable(
                "dbo.Donirajs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Suma = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.OrganizacijaDonirajs", "Doniraj_Id");
            CreateIndex("dbo.OrganizacijaDonirajs", "Organizacija_Id");
            AddForeignKey("dbo.OrganizacijaDonirajs", "Doniraj_Id", "dbo.Donirajs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrganizacijaDonirajs", "Organizacija_Id", "dbo.Organizacijas", "Id", cascadeDelete: true);
        }
    }
}
