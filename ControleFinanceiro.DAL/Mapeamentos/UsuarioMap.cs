using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CPF).IsRequired().HasMaxLength(20);
            builder.HasIndex(x => x.CPF).IsUnique();

            builder.Property(x => x.Profissao).IsRequired().HasMaxLength(30);

            builder.HasMany(x => x.Cartoes).WithOne(x => x.Usuario).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Despesas).WithOne(x => x.Usuario).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Ganhos).WithOne(x => x.Usuario).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Usuarios");
        }
    }
}
