namespace Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCC : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.InvoiceDetails", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoiceDetails", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
