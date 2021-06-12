namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Capability_CapabilityNameLeng : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Capabilities", "CapabilityName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Capabilities", "CapabilityName", c => c.String(maxLength: 50));
        }
    }
}
