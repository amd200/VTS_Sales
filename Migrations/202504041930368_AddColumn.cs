namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceDetails", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.InvoiceDetails", "ProductId");
            AddForeignKey("dbo.InvoiceDetails", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            DropColumn("dbo.InvoiceDetails", "ProductName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceDetails", "ProductName", c => c.String());
            DropForeignKey("dbo.InvoiceDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.InvoiceDetails", new[] { "ProductId" });
            DropColumn("dbo.InvoiceDetails", "ProductId");
        }
    }
}
