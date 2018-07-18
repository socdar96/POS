namespace SampleCodeFirstIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "userId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.User", new[] { "userId", "userLevel", "disabled" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "userId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.User", new[] { "userId", "userLevel", "disabled" });
        }
    }
}
