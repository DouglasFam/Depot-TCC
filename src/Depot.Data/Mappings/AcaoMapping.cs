using Depot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Depot.Data.Mappings
{
    public class AcaoMapping : IEntityTypeConfiguration<Acao>
    {
        public void Configure(EntityTypeBuilder<Acao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(255)");

            //1 : N => Ação : HistoricoProduto
            builder.HasMany(a => a.HistoricoProdutos)
                .WithOne(hp => hp.Acao)
                .HasForeignKey(hp  => hp.AcaoId);

            builder.ToTable("acoes");
        }
    }
}
