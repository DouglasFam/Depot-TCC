using Depot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Depot.Data.Mappings
{
    class GrupoMapping : IEntityTypeConfiguration<GrupoProduto>
    {
        public void Configure(EntityTypeBuilder<GrupoProduto> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Grupo)
           .IsRequired()
           .HasColumnType("varchar(200)");

            // 1 : N => Grupo : Produtos
            builder.HasMany(g => g.Produtos)
                .WithOne(p => p.GrupoProduto)
                .HasForeignKey(p => p.GrupoId);


            builder.ToTable("Grupos");

        }
    }
}
