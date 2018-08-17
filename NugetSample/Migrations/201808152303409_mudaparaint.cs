namespace NugetSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mudaparaint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Particulares", "CartadeConducao", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Particulares", "CartadeConducao", c => c.Int(nullable: false));
        }
    }
}
