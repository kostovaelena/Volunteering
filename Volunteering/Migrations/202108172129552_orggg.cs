namespace Volunteering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orggg : DbMigration
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
            
            AddColumn("dbo.Organizacijas", "doniraj_Id", c => c.Int());
            CreateIndex("dbo.Organizacijas", "doniraj_Id");
            AddForeignKey("dbo.Organizacijas", "doniraj_Id", "dbo.Donirajs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizacijas", "doniraj_Id", "dbo.Donirajs");
            DropIndex("dbo.Organizacijas", new[] { "doniraj_Id" });
            DropColumn("dbo.Organizacijas", "doniraj_Id");
            DropTable("dbo.Donirajs");
        }
    }
}
