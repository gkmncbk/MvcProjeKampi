namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contact_ReadStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactReadStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactReadStatus");
        }
    }
}
