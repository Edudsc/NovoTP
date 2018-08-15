namespace NugetSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvaliaCarro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Consumo = c.Int(nullable: false),
                        Espaco = c.Int(nullable: false),
                        Avarias = c.Boolean(nullable: false),
                        Limpeza = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Carros",
                c => new
                    {
                        CarroId = c.Int(nullable: false, identity: true),
                        AvalcarroId = c.Int(nullable: false),
                        CondAlugarId = c.Int(nullable: false),
                        Modelo = c.String(nullable: false),
                        Marca = c.String(nullable: false),
                        Matricula = c.String(nullable: false),
                        Combustivél = c.Int(nullable: false),
                        Ano = c.Int(nullable: false),
                        PreçoDia = c.Int(name: "Preço/Dia", nullable: false),
                        PreçoMes = c.Int(name: "Preço/Mes", nullable: false),
                        Particular_ParticularId = c.Int(),
                        Particular_ParticularId1 = c.Int(),
                        Profissional_ProfissionalId = c.Int(),
                    })
                .PrimaryKey(t => t.CarroId)
                .ForeignKey("dbo.AvaliaCarro", t => t.AvalcarroId, cascadeDelete: true)
                .ForeignKey("dbo.CondicoesdeAluguer", t => t.CondAlugarId, cascadeDelete: true)
                .ForeignKey("dbo.Particulares", t => t.Particular_ParticularId)
                .ForeignKey("dbo.Particulares", t => t.Particular_ParticularId1)
                .ForeignKey("dbo.Profissionais", t => t.Profissional_ProfissionalId)
                .Index(t => t.AvalcarroId)
                .Index(t => t.CondAlugarId)
                .Index(t => t.Particular_ParticularId)
                .Index(t => t.Particular_ParticularId1)
                .Index(t => t.Profissional_ProfissionalId);
            
            CreateTable(
                "dbo.CondicoesdeAluguer",
                c => new
                    {
                        CondAlugaId = c.Int(nullable: false, identity: true),
                        ZonaId = c.Int(nullable: false),
                        DataInicial = c.DateTime(nullable: false),
                        DataFinal = c.DateTime(nullable: false),
                        Seguro = c.String(nullable: false),
                        PrePagamento = c.Boolean(nullable: false),
                        IdadeMinima = c.Int(nullable: false),
                        TempodeCartaMeses = c.Int(name: "TempodeCarta (Meses)", nullable: false),
                        ClassificacaoMinimaRequerida = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CondAlugaId)
                .ForeignKey("dbo.Zonas", t => t.ZonaId, cascadeDelete: true)
                .Index(t => t.ZonaId);
            
            CreateTable(
                "dbo.Zonas",
                c => new
                    {
                        ZonasId = c.Int(nullable: false, identity: true),
                        ZonadeAluger = c.String(nullable: false),
                        Particular_ParticularId = c.Int(),
                        Profissional_ProfissionalId = c.Int(),
                    })
                .PrimaryKey(t => t.ZonasId)
                .ForeignKey("dbo.Particulares", t => t.Particular_ParticularId)
                .ForeignKey("dbo.Profissionais", t => t.Profissional_ProfissionalId)
                .Index(t => t.Particular_ParticularId)
                .Index(t => t.Profissional_ProfissionalId);
            
            CreateTable(
                "dbo.Fotos",
                c => new
                    {
                        FotosdoCarroId = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false),
                        Carro_CarroId = c.Int(),
                    })
                .PrimaryKey(t => t.FotosdoCarroId)
                .ForeignKey("dbo.Carros", t => t.Carro_CarroId)
                .Index(t => t.Carro_CarroId);
            
            CreateTable(
                "dbo.Servicos",
                c => new
                    {
                        ServicosId = c.Int(nullable: false, identity: true),
                        CarroId = c.Int(nullable: false),
                        ProfissionalId = c.Int(),
                        DataInicial = c.DateTime(nullable: false),
                        DataFinal = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ServicosId)
                .ForeignKey("dbo.Carros", t => t.CarroId, cascadeDelete: true)
                .ForeignKey("dbo.Profissionais", t => t.ProfissionalId)
                .Index(t => t.CarroId)
                .Index(t => t.ProfissionalId);
            
            CreateTable(
                "dbo.Particulares",
                c => new
                    {
                        ParticularId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Identificacao = c.Int(nullable: false),
                        Morada = c.String(nullable: false),
                        DatadeNascimento = c.DateTime(nullable: false),
                        CartadeConducao = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Telefone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParticularId);
            
            CreateTable(
                "dbo.CriteriosCliente",
                c => new
                    {
                        CritclienteId = c.Int(nullable: false, identity: true),
                        Simpatia = c.Int(nullable: false),
                        EstadoVeiculo = c.Int(nullable: false),
                        DataEntrega = c.Boolean(nullable: false),
                        Particular_ParticularId = c.Int(),
                    })
                .PrimaryKey(t => t.CritclienteId)
                .ForeignKey("dbo.Particulares", t => t.Particular_ParticularId)
                .Index(t => t.Particular_ParticularId);
            
            CreateTable(
                "dbo.CriteriosFornecedor",
                c => new
                    {
                        CritFornecedorId = c.Int(nullable: false, identity: true),
                        Simpatia = c.Int(nullable: false),
                        EstadodoVeículo = c.Int(name: "Estado do Veículo", nullable: false),
                        DatadeEntrega = c.Boolean(name: "Data de Entrega", nullable: false),
                        Responsividade = c.Int(nullable: false),
                        Particular_ParticularId = c.Int(),
                        Profissional_ProfissionalId = c.Int(),
                    })
                .PrimaryKey(t => t.CritFornecedorId)
                .ForeignKey("dbo.Particulares", t => t.Particular_ParticularId)
                .ForeignKey("dbo.Profissionais", t => t.Profissional_ProfissionalId)
                .Index(t => t.Particular_ParticularId)
                .Index(t => t.Profissional_ProfissionalId);
            
            CreateTable(
                "dbo.Mensagens",
                c => new
                    {
                        MensagemId = c.Int(nullable: false, identity: true),
                        Mensagem = c.String(nullable: false),
                        Vista = c.Boolean(nullable: false),
                        Particular_ParticularId = c.Int(),
                        Profissional_ProfissionalId = c.Int(),
                    })
                .PrimaryKey(t => t.MensagemId)
                .ForeignKey("dbo.Particulares", t => t.Particular_ParticularId)
                .ForeignKey("dbo.Profissionais", t => t.Profissional_ProfissionalId)
                .Index(t => t.Particular_ParticularId)
                .Index(t => t.Profissional_ProfissionalId);
            
            CreateTable(
                "dbo.Profissionais",
                c => new
                    {
                        ProfissionalId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        DenominacaoSocial = c.String(nullable: false),
                        Morada = c.String(nullable: false),
                        DatadeFundacao = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Telefone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfissionalId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ParticularServicos",
                c => new
                    {
                        Particular_ParticularId = c.Int(nullable: false),
                        Servicos_ServicosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Particular_ParticularId, t.Servicos_ServicosId })
                .ForeignKey("dbo.Particulares", t => t.Particular_ParticularId, cascadeDelete: true)
                .ForeignKey("dbo.Servicos", t => t.Servicos_ServicosId, cascadeDelete: true)
                .Index(t => t.Particular_ParticularId)
                .Index(t => t.Servicos_ServicosId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Servicos", "ProfissionalId", "dbo.Profissionais");
            DropForeignKey("dbo.Zonas", "Profissional_ProfissionalId", "dbo.Profissionais");
            DropForeignKey("dbo.Mensagens", "Profissional_ProfissionalId", "dbo.Profissionais");
            DropForeignKey("dbo.CriteriosFornecedor", "Profissional_ProfissionalId", "dbo.Profissionais");
            DropForeignKey("dbo.Carros", "Profissional_ProfissionalId", "dbo.Profissionais");
            DropForeignKey("dbo.Zonas", "Particular_ParticularId", "dbo.Particulares");
            DropForeignKey("dbo.ParticularServicos", "Servicos_ServicosId", "dbo.Servicos");
            DropForeignKey("dbo.ParticularServicos", "Particular_ParticularId", "dbo.Particulares");
            DropForeignKey("dbo.Mensagens", "Particular_ParticularId", "dbo.Particulares");
            DropForeignKey("dbo.CriteriosFornecedor", "Particular_ParticularId", "dbo.Particulares");
            DropForeignKey("dbo.CriteriosCliente", "Particular_ParticularId", "dbo.Particulares");
            DropForeignKey("dbo.Carros", "Particular_ParticularId1", "dbo.Particulares");
            DropForeignKey("dbo.Carros", "Particular_ParticularId", "dbo.Particulares");
            DropForeignKey("dbo.Servicos", "CarroId", "dbo.Carros");
            DropForeignKey("dbo.Fotos", "Carro_CarroId", "dbo.Carros");
            DropForeignKey("dbo.Carros", "CondAlugarId", "dbo.CondicoesdeAluguer");
            DropForeignKey("dbo.CondicoesdeAluguer", "ZonaId", "dbo.Zonas");
            DropForeignKey("dbo.Carros", "AvalcarroId", "dbo.AvaliaCarro");
            DropIndex("dbo.ParticularServicos", new[] { "Servicos_ServicosId" });
            DropIndex("dbo.ParticularServicos", new[] { "Particular_ParticularId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Mensagens", new[] { "Profissional_ProfissionalId" });
            DropIndex("dbo.Mensagens", new[] { "Particular_ParticularId" });
            DropIndex("dbo.CriteriosFornecedor", new[] { "Profissional_ProfissionalId" });
            DropIndex("dbo.CriteriosFornecedor", new[] { "Particular_ParticularId" });
            DropIndex("dbo.CriteriosCliente", new[] { "Particular_ParticularId" });
            DropIndex("dbo.Servicos", new[] { "ProfissionalId" });
            DropIndex("dbo.Servicos", new[] { "CarroId" });
            DropIndex("dbo.Fotos", new[] { "Carro_CarroId" });
            DropIndex("dbo.Zonas", new[] { "Profissional_ProfissionalId" });
            DropIndex("dbo.Zonas", new[] { "Particular_ParticularId" });
            DropIndex("dbo.CondicoesdeAluguer", new[] { "ZonaId" });
            DropIndex("dbo.Carros", new[] { "Profissional_ProfissionalId" });
            DropIndex("dbo.Carros", new[] { "Particular_ParticularId1" });
            DropIndex("dbo.Carros", new[] { "Particular_ParticularId" });
            DropIndex("dbo.Carros", new[] { "CondAlugarId" });
            DropIndex("dbo.Carros", new[] { "AvalcarroId" });
            DropTable("dbo.ParticularServicos");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Profissionais");
            DropTable("dbo.Mensagens");
            DropTable("dbo.CriteriosFornecedor");
            DropTable("dbo.CriteriosCliente");
            DropTable("dbo.Particulares");
            DropTable("dbo.Servicos");
            DropTable("dbo.Fotos");
            DropTable("dbo.Zonas");
            DropTable("dbo.CondicoesdeAluguer");
            DropTable("dbo.Carros");
            DropTable("dbo.AvaliaCarro");
        }
    }
}
