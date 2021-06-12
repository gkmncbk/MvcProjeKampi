namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_MessageDraftStatusAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageDraftsStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageDraftsStatus");
        }
    }
}
