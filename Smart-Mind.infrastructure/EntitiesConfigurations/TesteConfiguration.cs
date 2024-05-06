using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using Smart_Mind.Domain.Entities;

namespace Smart_Mind.infrastructure.EntitiesConfigurations
{
    internal class TesteConfiguration : IEntityTypeConfiguration<Teste>
    {
        public void Configure(EntityTypeBuilder<Teste> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.DataDaRealizacao).IsRequired();

            builder.HasOne(e => e.Usuario).WithMany(e => e.Testes).HasForeignKey(e => e.UsuarioId);

            builder.HasMany(e => e.Questoes).WithMany(e => e.Testes);

        }
    }
}
