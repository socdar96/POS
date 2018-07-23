namespace SampleCodeFirstIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Power : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transaction_Details", "trans_No", "dbo.Transactions");
            DropIndex("dbo.Transaction_Details", new[] { "trans_No" });
            DropPrimaryKey("dbo.Transactions");
            AlterColumn("dbo.Transaction_Details", "trans_No", c => c.String(maxLength: 128));
            AlterColumn("dbo.Transactions", "trans_No", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Transactions", "trans_No");
            CreateIndex("dbo.Transaction_Details", "trans_No");
            AddForeignKey("dbo.Transaction_Details", "trans_No", "dbo.Transactions", "trans_No");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction_Details", "trans_No", "dbo.Transactions");
            DropIndex("dbo.Transaction_Details", new[] { "trans_No" });
            DropPrimaryKey("dbo.Transactions");
            AlterColumn("dbo.Transactions", "trans_No", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Transaction_Details", "trans_No", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Transactions", "trans_No");
            CreateIndex("dbo.Transaction_Details", "trans_No");
            AddForeignKey("dbo.Transaction_Details", "trans_No", "dbo.Transactions", "trans_No", cascadeDelete: true);
        }
    }
}
