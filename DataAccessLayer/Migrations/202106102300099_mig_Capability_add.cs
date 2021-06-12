namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Capability_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Capabilities",
                c => new
                    {
                        CapabilityID = c.Int(nullable: false, identity: true),
                        UserNameSurname = c.String(maxLength: 50),
                        GitHubName = c.String(maxLength: 50),
                        Capability1 = c.Int(nullable: false),
                        Capability2 = c.Int(nullable: false),
                        Capability3 = c.Int(nullable: false),
                        Capability4 = c.Int(nullable: false),
                        Capability5 = c.Int(nullable: false),
                        Capability6 = c.Int(nullable: false),
                        Capability7 = c.Int(nullable: false),
                        Capability8 = c.Int(nullable: false),
                        Capability9 = c.Int(nullable: false),
                        Capability10 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CapabilityID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Capabilities");
        }
    }
}
