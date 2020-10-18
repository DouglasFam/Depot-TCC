using Depot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Depot.Data.Mappings
{
    public class EstoqueMapping : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.NomeEstoque)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Regiao)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.HasOne(e => e.Endereco)
                .WithOne(k => k.Estoque)
                .HasForeignKey<Endereco>(e => e.EstoqueId);
           
            builder.HasMany(e => e.Produtos)
                .WithOne(p => p.Estoque)
                .HasForeignKey(p => p.EstoqueId);

            builder.ToTable("Estoques");

        }
    }
}
