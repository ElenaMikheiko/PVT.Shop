namespace PVT.Shop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationToCategory : DbMigration
    {
        public override void Up()
        {
            this.AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false));
            this.AlterColumn("dbo.Categories", "Icon", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            this.AlterColumn("dbo.Categories", "Icon", c => c.String());
            this.AlterColumn("dbo.Categories", "Description", c => c.String());
        }
    }
}
