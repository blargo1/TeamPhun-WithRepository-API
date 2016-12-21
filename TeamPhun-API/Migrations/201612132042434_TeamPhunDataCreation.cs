namespace TeamPhun_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamPhunDataCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddOns",
                c => new
                    {
                        AddOnId = c.Int(nullable: false, identity: true),
                        MetallicInks = c.Double(nullable: false),
                        Discharge = c.Double(nullable: false),
                        Foil = c.Double(nullable: false),
                        Flash = c.Double(nullable: false),
                        PMSColorMatching = c.Double(nullable: false),
                        FoldingBagging = c.Double(nullable: false),
                        SalesTax = c.Double(nullable: false),
                        SetUp = c.Double(nullable: false),
                        AddOnUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AddOnId);
            
            CreateTable(
                "dbo.ColorQuantityPrices",
                c => new
                    {
                        ColorTierId = c.Int(nullable: false),
                        QuantityTierId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        PriceUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ColorTierId, t.QuantityTierId })
                .ForeignKey("dbo.ColorTiers", t => t.ColorTierId, cascadeDelete: true)
                .ForeignKey("dbo.QuantityTiers", t => t.QuantityTierId, cascadeDelete: true)
                .Index(t => t.ColorTierId)
                .Index(t => t.QuantityTierId);
            
            CreateTable(
                "dbo.ColorTiers",
                c => new
                    {
                        ColorTierId = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ColorTierId);
            
            CreateTable(
                "dbo.QuantityTiers",
                c => new
                    {
                        QuantityTierId = c.Int(nullable: false, identity: true),
                        MinQuantity = c.Int(nullable: false),
                        MaxQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuantityTierId);
            
            CreateTable(
                "dbo.Configurations",
                c => new
                    {
                        ConfigurationId = c.String(nullable: false, maxLength: 128),
                        AddPrintLocationColorPrice = c.String(),
                    })
                .PrimaryKey(t => t.ConfigurationId);
            
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
                        SetUp = c.Boolean(nullable: false),
                        OrderLineItemCost = c.Single(nullable: false),
                        ProfitMargin = c.Single(nullable: false),
                        OrderLineItemClientEstimate = c.Double(nullable: false),
                        OrderLineItemProfit = c.Double(nullable: false),
                        OrderLineItemCreatedDate = c.DateTime(nullable: false),
                        VendorName = c.String(),
                        CategoryId = c.Int(nullable: false),
                        CategoryName = c.String(),
                        BrandName = c.String(),
                        StyleId = c.Int(nullable: false),
                        CasePrice = c.String(),
                        StyleTitle = c.String(),
                    })
                .PrimaryKey(t => t.OrderLineItemId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderLineItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.ColorQuantityPrices", "QuantityTierId", "dbo.QuantityTiers");
            DropForeignKey("dbo.ColorQuantityPrices", "ColorTierId", "dbo.ColorTiers");
            DropIndex("dbo.OrderLineItems", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.ColorQuantityPrices", new[] { "QuantityTierId" });
            DropIndex("dbo.ColorQuantityPrices", new[] { "ColorTierId" });
            DropTable("dbo.OrderLineItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Configurations");
            DropTable("dbo.QuantityTiers");
            DropTable("dbo.ColorTiers");
            DropTable("dbo.ColorQuantityPrices");
            DropTable("dbo.AddOns");
        }
    }
}
