using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Map
{
    public class PermissaoMap : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.ToTable("permissao");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Descricao).HasColumnName("descricao");

            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.Itens).WithOne().HasForeignKey(fk => fk.IdPermissao);
        }
    }
}
