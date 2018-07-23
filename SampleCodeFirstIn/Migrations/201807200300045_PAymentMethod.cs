namespace SampleCodeFirstIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PAymentMethod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        paymentid = c.Int(nullable: false, identity: true),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.paymentid);
            
            AddColumn("dbo.User", "shiftid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "shiftid");
            DropTable("dbo.PaymentTypes");
        }
    }
}
