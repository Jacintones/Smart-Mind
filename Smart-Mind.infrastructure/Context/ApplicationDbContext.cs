using Microsoft.EntityFrameworkCore;
using Smart_Mind.Domain.Entities;

namespace Smart_Mind.infrastructure.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public ApplicationDbContext()
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Materia> Materias { get; set; }

        public DbSet<Assunto> Assuntos { get; set; }

        public DbSet<Questao> Questoes { get; set; }

        public DbSet<Teste> Testes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
                .Assembly);
        }
    }
}
