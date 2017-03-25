namespace nVision.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CardId = c.Guid(nullable: false),
                        AvailableFunds = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accounts");
        }
    }
}
