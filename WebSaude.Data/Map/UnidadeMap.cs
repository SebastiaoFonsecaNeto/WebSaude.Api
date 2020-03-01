using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Map
{
    public class UnidadeMap : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder.ToTable("unidade");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Descricao).HasColumnName("descricao");
            builder.Property(p => p.Telefone).HasColumnName("telefone");
            builder.Property(p => p.Endereco).HasColumnName("endereco");
            builder.Property(p => p.Numero).HasColumnName("numero");
            builder.Property(p => p.Complemento).HasColumnName("complemento");
            builder.Property(p => p.Bairro).HasColumnName("bairro");
            builder.Property(p => p.Cidade).HasColumnName("cidade");
            builder.Property(p => p.Estado).HasColumnName("estado");
            builder.Property(p => p.Cep).HasColumnName("cep");

            builder.HasKey(p => p.Id);
        }
    }
}
