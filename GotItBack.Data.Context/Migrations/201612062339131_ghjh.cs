namespace GotItBack.Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ghjh : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.FoundItems",
                c => new
                    {
                        FoundItemId = c.Long(nullable: false, identity: true),
                        DateItemFound = c.DateTime(nullable: false),
                        CategoryId = c.Long(nullable: false),
                        SubCategoryId = c.Long(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Color = c.String(),
                        Brand = c.String(),
                        SerialNumber = c.String(),
                        Model = c.String(),
                        ItemImage = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateLastModified = c.DateTime(nullable: false),
                        LastModifiedBy = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.FoundItemId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.SubCategoryId);
            
       
        }
    }
}
