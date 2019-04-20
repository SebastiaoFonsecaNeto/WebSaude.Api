using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebSaude.Domain.Entities;

namespace WebSaude.Data.Map
{
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("paciente");
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Nome).HasColumnName("nome");
            builder.Property(p => p.DataNascimento).HasColumnName("data_nascimento");
            builder.Property(p => p.Sexo).HasColumnName("sexo");

            builder.HasKey(p => p.Id);
        }
    }
}
