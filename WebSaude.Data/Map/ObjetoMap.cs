using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Map
{
    public class ObjetoMap : IEntityTypeConfiguration<Objeto>
    {
        public void Configure(EntityTypeBuilder<Objeto> builder)
        {
            builder.ToTable("objeto");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Descricao).HasColumnName("descricao");
            builder.Property(p => p.Url).HasColumnName("url");
            builder.Property(p => p.Icone).HasColumnName("icone");

            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.Itens).WithOne().HasForeignKey(fk => fk.IdObjetoPai);
            builder.HasMany(p => p.ObjetosFilhos).WithOne(f => f.Objeto).HasForeignKey(fk => fk.IdObjetoFilho);
        }
    }
}
