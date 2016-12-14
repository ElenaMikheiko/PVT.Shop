namespace PVT.Shop.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOrderDataAdd : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "Created", newName: "DateAdded");
            AlterColumn("dbo.Orders", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "DateAdded", c => c.DateTime(precision: 7, storeType: "datetime2"));
            RenameColumn(table: "dbo.Orders", name: "DateAdded", newName: "Created");
        }
    }
}
