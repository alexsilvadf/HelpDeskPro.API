using HDP.Core.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDP.Infra.Configuracao
{
    internal class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnType("varchar(100)")
                   .HasComment("Nome da Categoria")
                   .HasColumnName("Nome");

            builder.Property(e => e.Status)
                   .IsRequired()
                   .HasColumnType("int")
                   .HasComment("0 Ativo, 1 Inativo")
                   .HasColumnName("Status");

            builder.Property(e => e.UsuarioInclusao)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnType("varchar(50)")
                   .HasComment("Usuário de Inclusão")
                   .HasColumnName("Usuario_Inc");

            builder.Property(e => e.DataHoraInclusao)
                   .IsRequired()
                   .HasColumnType("DATE")
                   .HasComment("Data Hora Inclusão do Registro")
                   .HasColumnName("Data_Hora_Inc");

            builder.Property(e => e.UsuarioAlteracao)
                  .IsRequired()
                  .HasMaxLength(50)
                  .HasColumnType("varchar(50)")
                  .HasComment("Usuário de Alteração")
                  .HasColumnName("Usuario_Alt");

            builder.Property(e => e.DataHoraAlteracao)
                   .IsRequired()
                   .HasColumnType("DATE")
                   .HasComment("Data Hora Alteração do Registro")
                   .HasColumnName("Data_Hora_Alt");
        }
    }
}
