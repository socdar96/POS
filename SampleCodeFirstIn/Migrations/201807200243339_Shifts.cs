namespace SampleCodeFirstIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shifts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        shiftid = c.Int(nullable: false, identity: true),
                        ShiftTime = c.String(),
                    })
                .PrimaryKey(t => t.shiftid);
            
            CreateIndex("dbo.Transactions", "shiftid");
            AddForeignKey("dbo.Transactions", "shiftid", "dbo.Shifts", "shiftid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "shiftid", "dbo.Shifts");
            DropIndex("dbo.Transactions", new[] { "shiftid" });
            DropTable("dbo.Shifts");
        }
    }
}
