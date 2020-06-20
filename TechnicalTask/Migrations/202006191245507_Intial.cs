namespace TechnicalTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        invoiceID = c.Int(nullable: false),
                        itemID = c.Int(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Quantity = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        Net = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Invoices", t => t.invoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.itemID, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitID, cascadeDelete: true)
                .Index(t => t.invoiceID)
                .Index(t => t.itemID)
                .Index(t => t.UnitID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        invoice_No = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        invoice_Taxes = c.Double(),
                        invoice_Total = c.Double(nullable: false),
                        invoice_Net = c.Double(nullable: false),
                        storeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Stores", t => t.storeId, cascadeDelete: true)
                .Index(t => t.storeId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceDetails", "UnitID", "dbo.Units");
            DropForeignKey("dbo.InvoiceDetails", "itemID", "dbo.Items");
            DropForeignKey("dbo.Invoices", "storeId", "dbo.Stores");
            DropForeignKey("dbo.InvoiceDetails", "invoiceID", "dbo.Invoices");
            DropIndex("dbo.Invoices", new[] { "storeId" });
            DropIndex("dbo.InvoiceDetails", new[] { "UnitID" });
            DropIndex("dbo.InvoiceDetails", new[] { "itemID" });
            DropIndex("dbo.InvoiceDetails", new[] { "invoiceID" });
            DropTable("dbo.Units");
            DropTable("dbo.Items");
            DropTable("dbo.Stores");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceDetails");
        }
    }
}
