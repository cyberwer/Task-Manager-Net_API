namespace DentalDDS_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "UserName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Tasks", "TaskName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tasks", "TaskDetail", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "TaskDetail", c => c.Long(nullable: false));
            AlterColumn("dbo.Tasks", "TaskName", c => c.Long(nullable: false));
            DropColumn("dbo.Tasks", "UserName");
        }
    }
}
