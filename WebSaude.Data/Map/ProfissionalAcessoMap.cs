using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Map
{
    public class ProfissionalAcessoMap : IEntityTypeConfiguration<ProfissionalAcesso>
    {
        public void Configure(EntityTypeBuilder<ProfissionalAcesso> builder)
        {
            builder.ToTable("profissional_acesso");
            builder.Property(p => p.IdProfissional).HasColumnName("profissional_id");
            builder.Property(p => p.IdPermissao).HasColumnName("permissao_id");
            builder.Property(p => p.HoraInicio).HasColumnName("hora_inicio");
            builder.Property(p => p.HoraFim).HasColumnName("hora_fim");
            builder.Property(p => p.Senha).HasColumnName("senha");
            builder.Property(p => p.Domingo).HasColumnName("dom");
            builder.Property(p => p.Segunda).HasColumnName("seg");
            builder.Property(p => p.Terca).HasColumnName("ter");
            builder.Property(p => p.Quarta).HasColumnName("qua");
            builder.Property(p => p.Quinta).HasColumnName("qui");
            builder.Property(p => p.Sexta).HasColumnName("sex");
            builder.Property(p => p.Sabado).HasColumnName("sab");
            builder.Property(p => p.Ultimo).HasColumnName("ultimo");
            builder.Property(p => p.Ip).HasColumnName("ip");
            builder.Property(p => p.QuantidadeMinuto).HasColumnName("quantidade_minuto");
            builder.Property(p => p.Token).HasColumnName("token");

            builder.HasKey(p => p.IdProfissional);
            builder.HasOne(p => p.Permissao).WithMany().HasForeignKey(fk => fk.IdPermissao);
        }
    }
}
