namespace Volunteering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fora", "WhenCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Fora", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fora", "DateCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Fora", "WhenCreated");
        }
    }
}
