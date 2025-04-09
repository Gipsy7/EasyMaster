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

            // Configurar a chave prim�ria para a entidade Componente
            modelBuilder.Entity<Componente>()
                .HasKey(c => c.IdComponente);

            // Configurar a chave prim�ria para outras entidades, se necess�rio
            modelBuilder.Entity<Modulo>()
                .HasKey(m => m.IdModulo);

            modelBuilder.Entity<Sistema>()
                .HasKey(s => s.IdSistema);

            modelBuilder.Entity<Personagem>()
                .HasKey(p => p.IdPersonagem);
        }
    }
}
