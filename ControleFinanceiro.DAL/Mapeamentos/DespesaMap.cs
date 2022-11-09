using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class DespesaMap : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.HasKey(x => x.DespesaId);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Dia).IsRequired();
            builder.Property(x => x.Ano).IsRequired();

            builder.HasOne(x => x.Cartao).WithMany(x => x.Despesas).HasForeignKey(x => x.CartaoId).IsRequired();
            builder.HasOne(x => x.Categoria).WithMany(x => x.Despesas).HasForeignKey(x => x.CategoriaId).IsRequired();
            builder.HasOne(x => x.Mes).WithMany(x => x.Despesas).HasForeignKey(x => x.MesId).IsRequired();
            builder.HasOne(x => x.Usuario).WithMany(x => x.Despesas).HasForeignKey(x => x.UsuarioId).IsRequired();

            builder.ToTable("Despesas");
        }
    }
}