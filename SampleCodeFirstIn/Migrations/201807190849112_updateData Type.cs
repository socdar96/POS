namespace SampleCodeFirstIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDataType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction_Details", "trans_No", "dbo.Transactions");
            DropIndex("dbo.Transaction_Details", new[] { "trans_No" });
            DropPrimaryKey("dbo.Transactions");
            AlterColumn("dbo.Transaction_Details", "trans_No", c => c.Int(nullable: false));
            AlterColumn("dbo.Transactions", "trans_No", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Transactions", "trans_No");
            CreateIndex("dbo.Transaction_Details", "trans_No");
            AddForeignKey("dbo.Transaction_Details", "trans_No", "dbo.Transactions", "trans_No", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction_Details", "trans_No", "dbo.Transactions");
            DropIndex("dbo.Transaction_Details", new[] { "trans_No" });
            DropPrimaryKey("dbo.Transactions");
            AlterColumn("dbo.Transactions", "trans_No", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Transaction_Details", "trans_No", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddPrimaryKey("dbo.Transactions", "trans_No");
            CreateIndex("dbo.Transaction_Details", "trans_No");
            AddForeignKey("dbo.Transaction_Details", "trans_No", "dbo.Transactions", "trans_No", cascadeDelete: true);
        }
    }
}
