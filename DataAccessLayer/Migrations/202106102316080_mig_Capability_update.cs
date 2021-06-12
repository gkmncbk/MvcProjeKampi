namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Capability_update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Capabilities", "CapabilityName", c => c.String(maxLength: 50));
            AddColumn("dbo.Capabilities", "CapabilityLevel", c => c.Int(nullable: false));
            AddColumn("dbo.Capabilities", "CapabilityStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Capabilities", "UserNameSurname");
            DropColumn("dbo.Capabilities", "GitHubName");
            DropColumn("dbo.Capabilities", "Capability1");
            DropColumn("dbo.Capabilities", "Capability2");
            DropColumn("dbo.Capabilities", "Capability3");
            DropColumn("dbo.Capabilities", "Capability4");
            DropColumn("dbo.Capabilities", "Capability5");
            DropColumn("dbo.Capabilities", "Capability6");
            DropColumn("dbo.Capabilities", "Capability7");
            DropColumn("dbo.Capabilities", "Capability8");
            DropColumn("dbo.Capabilities", "Capability9");
            DropColumn("dbo.Capabilities", "Capability10");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Capabilities", "Capability10", c => c.Int(nullable: false));
            AddColumn("dbo.Capabilities", "Capability9", c => c.Int(nullable: false));
            AddColumn("dbo.Capabilities", "Capability8", c => c.Int(nullable: false));
            AddColumn("dbo.Capabilities", "Capability7", c => c.Int(nullable: false));
            AddColumn("dbo.Capabilities", "Capability6", c => c.Int(nullable: false));
            AddColumn("dbo.Capabilities", "Capability5", c => c.Int(nullable: false));
            AddColumn("dbo.Capabilities", "Capability4", c => c.Int(nullable: false));
            AddColumn("dbo.Capabilities", "Capability3", c => c.Int(nullable: false));
            AddColumn("dbo.Capabilities", "Capability2", c => c.Int(nullable: false));
            AddColumn("dbo.Capabilities", "Capability1", c => c.Int(nullable: false));
            AddColumn("dbo.Capabilities", "GitHubName", c => c.String(maxLength: 50));
            AddColumn("dbo.Capabilities", "UserNameSurname", c => c.String(maxLength: 50));
            DropColumn("dbo.Capabilities", "CapabilityStatus");
            DropColumn("dbo.Capabilities", "CapabilityLevel");
            DropColumn("dbo.Capabilities", "CapabilityName");
        }
    }
}
