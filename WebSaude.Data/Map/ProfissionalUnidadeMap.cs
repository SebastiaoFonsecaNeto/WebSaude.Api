using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Map
{
    public class ProfissionalUnidadeMap : IEntityTypeConfiguration<ProfissionalUnidade>
    {
        public void Configure(EntityTypeBuilder<ProfissionalUnidade> builder)
        {
            builder.ToTable("profissional_unidade");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.IdProfissional).HasColumnName("profissional_id");
            builder.Property(p => p.IdUnidade).HasColumnName("unidade_id");

            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Unidade)
                   .WithMany().HasForeignKey(fk => fk.IdUnidade);
        }
    }
}
