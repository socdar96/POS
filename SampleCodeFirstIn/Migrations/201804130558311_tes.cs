namespace SampleCodeFirstIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategID = c.Int(nullable: false, identity: true),
                        CategName = c.String(),
                    })
                .PrimaryKey(t => t.CategID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProdName = c.String(),
                        CategID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategID, cascadeDelete: true)
                .Index(t => t.CategID);
            
            CreateTable(
                "dbo.Transaction_Details",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        trans_No = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Transactions", t => t.trans_No, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.ProductID)
                .Index(t => t.trans_No);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        trans_No = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.trans_No);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        userId = c.Int(nullable: false),
                        userLevel = c.Int(nullable: false),
                        disabled = c.Boolean(nullable: false),
                        emailAdd = c.String(),
                        FirstName = c.String(),
                        SurName = c.String(),
                        mobileNo = c.String(),
                        Pwd = c.String(),
                        userName = c.String(),
                    })
                .PrimaryKey(t => new { t.userId, t.userLevel, t.disabled });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction_Details", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Transaction_Details", "trans_No", "dbo.Transactions");
            DropForeignKey("dbo.Products", "CategID", "dbo.Categories");
            DropIndex("dbo.Transaction_Details", new[] { "trans_No" });
            DropIndex("dbo.Transaction_Details", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "CategID" });
            DropTable("dbo.User");
            DropTable("dbo.Transactions");
            DropTable("dbo.Transaction_Details");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
