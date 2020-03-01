using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Map
{
    public class PermissaoItemMap : IEntityTypeConfiguration<PermissaoItem>
    {
        public void Configure(EntityTypeBuilder<PermissaoItem> builder)
        {
            builder.ToTable("permissao_item");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.IdPermissao).HasColumnName("permissao_id");
            builder.Property(p => p.IdObjeto).HasColumnName("objeto_id");
            builder.Property(p => p.Incluir).HasColumnName("incluir");
            builder.Property(p => p.Excluir).HasColumnName("excluir");
            builder.Property(p => p.Alterar).HasColumnName("alterar");

            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Objeto).WithMany().HasForeignKey(fk => fk.IdObjeto);
        }
    }
}
