using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x => x.CategoriaId);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Icone).IsRequired().HasMaxLength(15);

            builder.HasOne(x => x.Tipo).WithMany(x => x.Categorias).HasForeignKey(x => x.TipoId).IsRequired();
            builder.HasMany(x => x.Ganhos).WithOne(x => x.Categoria);
            builder.HasMany(x => x.Despesas).WithOne(x => x.Categoria);
          
            builder.ToTable("Categorias");
        }
    }
}
