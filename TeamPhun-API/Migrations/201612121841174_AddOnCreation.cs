namespace TeamPhun_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOnCreation : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AddOns");
        }
    }
}
