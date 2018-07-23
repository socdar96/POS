namespace SampleCodeFirstIn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shifts_Starts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shifts", "ShiftStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Shifts", "ShiftEnd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Shifts", "ShiftTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shifts", "ShiftTime", c => c.String());
            DropColumn("dbo.Shifts", "ShiftEnd");
            DropColumn("dbo.Shifts", "ShiftStart");
        }
    }
}
