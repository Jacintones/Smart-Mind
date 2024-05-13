using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Mind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.infrastructure.EntitiesConfigurations
{
    public class QuestaoConfiguration : IEntityTypeConfiguration<Questao>
    {
        public void Configure(EntityTypeBuilder<Questao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Enunciado).IsRequired();
            builder.Property(x => x.AssuntoId).IsRequired();
            builder.Property(x => x.Dificuldade).IsRequired();

            builder.HasOne(e => e.Assunto).WithMany(e => e.Questoes).HasForeignKey(e => e.AssuntoId);

        }
    }
}
