using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySample.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public override string Id { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        [Required]
        public string Perfil { get; set; }

        public int ProfissionalId { get; set; }
        public int ParticularId { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Avalcarro> Avalcarros { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<CondAlugar> CondAlugars { get; set; }
        public DbSet<Critcliente> Critclientes { get; set; }
        public DbSet<CritFornecedor> CritFornecedors { get; set; }
        public DbSet<FotosdoCarro> FotosdoCarros { get; set; }
        public DbSet<Mensagem> Mensagems { get; set; }
        public DbSet<Particular> Particulares { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Servicos> Servicoses { get; set; }
        public DbSet<Zonas> Zonases { get; set; }
    }
}