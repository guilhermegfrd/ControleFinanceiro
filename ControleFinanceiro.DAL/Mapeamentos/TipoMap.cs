using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class TipoMap : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(EntityTypeBuilder<Tipo> builder)
        {
            builder.HasKey(x => x.TipoId);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(20);
            builder.HasMany(x => x.Categorias).WithOne(x => x.Tipo);
            builder.HasData(
                new Tipo
                {
                    TipoId = 1,
                    Nome = "Despesa"
                },
                new Tipo
                {
                    TipoId = 2,
                    Nome = "Ganho"
                }
            );
            builder.ToTable("Tipos");
        }
    }
}
