using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Map
{
    public class ObjetoFilhoMap : IEntityTypeConfiguration<ObjetoFilho>
    {
        public void Configure(EntityTypeBuilder<ObjetoFilho> builder)
        {
            builder.ToTable("objeto_filho");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.IdObjetoFilho).HasColumnName("objeto_filho");
            builder.Property(p => p.IdObjetoPai).HasColumnName("objeto_pai");

            builder.HasKey(p => p.Id);
        }
    }
}
