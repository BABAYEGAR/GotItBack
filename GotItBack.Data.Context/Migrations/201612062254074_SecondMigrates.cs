namespace GotItBack.Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigrates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Password", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Password", c => c.String(nullable: false));
        }
    }
}
