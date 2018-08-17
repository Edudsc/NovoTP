namespace NugetSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Majorupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carros", "Modelo", c => c.String());
            AlterColumn("dbo.Carros", "Marca", c => c.String());
            AlterColumn("dbo.Carros", "Matricula", c => c.String());
            AlterColumn("dbo.CondicoesdeAluguer", "Seguro", c => c.String());
            AlterColumn("dbo.Zonas", "ZonadeAluger", c => c.String());
            AlterColumn("dbo.Fotos", "Url", c => c.String());
            AlterColumn("dbo.Particulares", "Nome", c => c.String());
            AlterColumn("dbo.Particulares", "Morada", c => c.String());
            AlterColumn("dbo.Particulares", "CartadeConducao", c => c.String());
            AlterColumn("dbo.Particulares", "Email", c => c.String());
            AlterColumn("dbo.Mensagens", "Mensagem", c => c.String());
            AlterColumn("dbo.Profissionais", "Nome", c => c.String());
            AlterColumn("dbo.Profissionais", "DenominacaoSocial", c => c.String());
            AlterColumn("dbo.Profissionais", "Morada", c => c.String());
            AlterColumn("dbo.Profissionais", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profissionais", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Profissionais", "Morada", c => c.String(nullable: false));
            AlterColumn("dbo.Profissionais", "DenominacaoSocial", c => c.String(nullable: false));
            AlterColumn("dbo.Profissionais", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Mensagens", "Mensagem", c => c.String(nullable: false));
            AlterColumn("dbo.Particulares", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Particulares", "CartadeConducao", c => c.String(nullable: false));
            AlterColumn("dbo.Particulares", "Morada", c => c.String(nullable: false));
            AlterColumn("dbo.Particulares", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Fotos", "Url", c => c.String(nullable: false));
            AlterColumn("dbo.Zonas", "ZonadeAluger", c => c.String(nullable: false));
            AlterColumn("dbo.CondicoesdeAluguer", "Seguro", c => c.String(nullable: false));
            AlterColumn("dbo.Carros", "Matricula", c => c.String(nullable: false));
            AlterColumn("dbo.Carros", "Marca", c => c.String(nullable: false));
            AlterColumn("dbo.Carros", "Modelo", c => c.String(nullable: false));
        }
    }
}
