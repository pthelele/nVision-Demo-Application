namespace nVision.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "Name");
        }
    }
}
