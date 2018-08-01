namespace SampleCodeFirstIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "cardNo", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "expiryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "CVcode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "CVcode");
            DropColumn("dbo.Transactions", "expiryDate");
            DropColumn("dbo.Transactions", "cardNo");
        }
    }
}
