namespace GotItBack.Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransportObject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Role", c => c.String());
            AddColumn("dbo.Contacts", "CreatedBy", c => c.Long(nullable: false));
            AddColumn("dbo.Contacts", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contacts", "DateLastModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contacts", "LastModifiedBy", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "LastModifiedBy");
            DropColumn("dbo.Contacts", "DateLastModified");
            DropColumn("dbo.Contacts", "DateCreated");
            DropColumn("dbo.Contacts", "CreatedBy");
            DropColumn("dbo.Contacts", "Role");
        }
    }
}
