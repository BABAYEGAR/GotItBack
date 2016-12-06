namespace GotItBack.Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigrates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "DisplayNumber", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Contacts", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Email", c => c.String());
            DropColumn("dbo.Contacts", "DisplayNumber");
        }
    }
}
