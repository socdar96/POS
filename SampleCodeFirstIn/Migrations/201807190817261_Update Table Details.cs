namespace SampleCodeFirstIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction_Details", "ProductID", "dbo.Products");
            DropPrimaryKey("dbo.Transaction_Details");
            AddColumn("dbo.Transaction_Details", "transDetId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Transaction_Details", "qty", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction_Details", "isVoid", c => c.Boolean(nullable: false));
            AddColumn("dbo.Transactions", "user", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "paymentType", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "disPercent", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "disAmount", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "shiftid", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "grossAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddPrimaryKey("dbo.Transaction_Details", "transDetId");
            AddForeignKey("dbo.Transaction_Details", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction_Details", "ProductID", "dbo.Products");
            DropPrimaryKey("dbo.Transaction_Details");
            DropColumn("dbo.Transactions", "grossAmount");
            DropColumn("dbo.Transactions", "shiftid");
            DropColumn("dbo.Transactions", "disAmount");
            DropColumn("dbo.Transactions", "disPercent");
            DropColumn("dbo.Transactions", "paymentType");
            DropColumn("dbo.Transactions", "user");
            DropColumn("dbo.Transaction_Details", "isVoid");
            DropColumn("dbo.Transaction_Details", "qty");
            DropColumn("dbo.Transaction_Details", "transDetId");
            AddPrimaryKey("dbo.Transaction_Details", "ProductID");
            AddForeignKey("dbo.Transaction_Details", "ProductID", "dbo.Products", "ProductID");
        }
    }
}
