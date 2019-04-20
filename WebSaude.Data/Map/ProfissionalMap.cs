using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Map
{
    public class ProfissionalMap : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.ToTable("profissional");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Nome).HasColumnName("nome");
            builder.Property(p => p.IdCbo).HasColumnName("cbo_id");
            builder.Property(p => p.Documento).HasColumnName("documento");
            builder.Property(p => p.Email).HasColumnName("email");
            builder.Property(p => p.Telefone).HasColumnName("telefone");
            builder.Property(p => p.Celular).HasColumnName("celular");
            builder.Property(p => p.IdCelularOperadora).HasColumnName("celular_operadora_id");
            builder.Property(p => p.Endereco).HasColumnName("endereco");
            builder.Property(p => p.Numero).HasColumnName("numero");
            builder.Property(p => p.Complemento).HasColumnName("complemento");
            builder.Property(p => p.Bairro).HasColumnName("bairro");
            builder.Property(p => p.Cidade).HasColumnName("cidade");
            builder.Property(p => p.Estado).HasColumnName("estado");
            builder.Property(p => p.Cep).HasColumnName("cep");
            builder.Property(p => p.Ativo).HasColumnName("ativo");
            builder.Property(p => p.Observacao).HasColumnName("observacao");
            builder.Property(p => p.Foto).HasColumnName("foto");

            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Acesso).WithMany().HasForeignKey(fk => fk.Id);
            builder.HasMany(p => p.Unidades).WithOne().HasForeignKey(fk => fk.IdProfissional);
        }
    }
}
