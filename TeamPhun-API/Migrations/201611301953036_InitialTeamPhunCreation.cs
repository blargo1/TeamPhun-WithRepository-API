namespace TeamPhun_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTeamPhunCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Organization = c.String(),
                        WebSite = c.String(),
                        Role = c.String(),
                        BusinessPhone = c.String(),
                        MobilePhone = c.String(),
                        OtherPhone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Country = c.String(),
                        Note = c.String(),
                        CustomerRecordCreated = c.DateTime(nullable: false),
                        UpdateCustomerRecord = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OrderTotal = c.Double(nullable: false),
                        TotalCost = c.Double(nullable: false),
                        TotalProfit = c.Double(nullable: false),
                        OrderStatus = c.Boolean(nullable: false),
                        OrderCreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderLineItems",
                c => new
                    {
                        OrderLineItemId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        VendorId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Description = c.String(),
                        TotalPieces = c.Int(nullable: false),
                        TotalNumberColors = c.Int(nullable: false),
                        NumberPrintLocations = c.Int(nullable: false),
                        MetallicLinks = c.Boolean(nullable: false),
                        Discharge = c.Boolean(nullable: false),
                        Foil = c.Boolean(nullable: false),
                        PMSColorMatching = c.Boolean(nullable: false),
                        Flash = c.Boolean(nullable: false),
                        FoldingAndBagging = c.Boolean(nullable: false),
                        SalesTax = c.Boolean(nullable: false),
                        ProfitMargin = c.Single(nullable: false),
                        OrderLineItemEstimate = c.Double(nullable: false),
                        OrderLineItemProfit = c.Double(nullable: false),
                        OrderLineItemCreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderLineItemId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.VendorId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductCode = c.Int(nullable: false),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        TotalProductCost = c.Double(nullable: false),
                        ProductCreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        VendorName = c.String(),
                        VendorProductCode = c.Int(nullable: false),
                        VendorInfo = c.String(),
                    })
                .PrimaryKey(t => t.VendorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderLineItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderLineItems", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.OrderLineItems", "ProductId", "dbo.Products");
            DropIndex("dbo.OrderLineItems", new[] { "ProductId" });
            DropIndex("dbo.OrderLineItems", new[] { "VendorId" });
            DropIndex("dbo.OrderLineItems", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.Vendors");
            DropTable("dbo.Products");
            DropTable("dbo.OrderLineItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
