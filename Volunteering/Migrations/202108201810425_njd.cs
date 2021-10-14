namespace Volunteering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class njd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donirajs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Suma = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fora",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(nullable: false),
                        Comment = c.String(nullable: false),
                        WhenCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Kategorijas", "Slika", c => c.String());
            AddColumn("dbo.Organizacijas", "doniraj_Id", c => c.Int());
            CreateIndex("dbo.Organizacijas", "doniraj_Id");
            AddForeignKey("dbo.Organizacijas", "doniraj_Id", "dbo.Donirajs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizacijas", "doniraj_Id", "dbo.Donirajs");
            DropIndex("dbo.Organizacijas", new[] { "doniraj_Id" });
            DropColumn("dbo.Organizacijas", "doniraj_Id");
            DropColumn("dbo.Kategorijas", "Slika");
            DropTable("dbo.Fora");
            DropTable("dbo.Donirajs");
        }
    }
}
