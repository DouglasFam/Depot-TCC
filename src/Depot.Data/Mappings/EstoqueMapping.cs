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

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

                      
            // 1 : N => Estoque : Produtos
            builder.HasMany(e => e.Produtos)
                .WithOne(p => p.Estoque)
                .HasForeignKey(p => p.EstoqueId);

            builder.ToTable("estoques");

        }
    }
}
