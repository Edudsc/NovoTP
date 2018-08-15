namespace NugetSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Perfil", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "ProfissionalId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ParticularId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ParticularId");
            DropColumn("dbo.AspNetUsers", "ProfissionalId");
            DropColumn("dbo.AspNetUsers", "Perfil");
        }
    }
}
