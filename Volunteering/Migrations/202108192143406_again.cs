namespace Volunteering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class again : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fora", "Ime", c => c.String(nullable: false));
            AlterColumn("dbo.Fora", "Comment", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fora", "Comment", c => c.String());
            AlterColumn("dbo.Fora", "Ime", c => c.String());
        }
    }
}
