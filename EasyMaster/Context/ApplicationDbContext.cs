using Microsoft.EntityFrameworkCore;

namespace EasyMaster.Model.RPG
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sistema> Sistemas { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Componente> Componentes { get; set; }
        public DbSet<Personagem> Personagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar a chave primária para a entidade Componente
            modelBuilder.Entity<Componente>()
                .HasKey(c => c.IdComponente);

            // Configurar a chave primária para a entidade Modulo
            modelBuilder.Entity<Modulo>()
                .HasKey(m => m.IdModulo);

            // Configurar a chave primária para a entidade Sistema
            modelBuilder.Entity<Sistema>()
                .HasKey(s => s.IdSistema);

            // Configurar a chave primária para a entidade Personagem
            modelBuilder.Entity<Personagem>()
                .HasKey(p => p.IdPersonagem);

            // Configurar a relação de um para muitos entre Sistema e Modulo
            modelBuilder.Entity<Sistema>()
                .HasMany(s => s.Modulos)
                .WithOne(m => m.Sistema)
                .HasForeignKey(m => m.IdSistema);

            // Configurar a relação de um para muitos entre Modulo e Componente
            modelBuilder.Entity<Modulo>()
                .HasMany(m => m.Componentes)
                .WithOne(c => c.Modulo)
                .HasForeignKey(c => c.IdModulo);

            // Configurar a relação de um para muitos entre Sistema e Personagem
            modelBuilder.Entity<Sistema>()
                .HasMany(s => s.Personagens)
                .WithOne(p => p.Sistema)
                .HasForeignKey(p => p.IdSistema);
        }
    }
}
