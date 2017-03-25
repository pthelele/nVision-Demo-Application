namespace nVision.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberOfFailedLogging : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "NumberOfFailedLogging", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cards", "NumberOfFailedLogging");
        }
    }
}
