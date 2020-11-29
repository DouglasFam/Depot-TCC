using Depot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Depot.Data.Mappings
{
    class GrupoMapping : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Nome)
           .IsRequired()
           .HasColumnType("varchar(200)");

            // 1 : N => Grupo : Produtos
            builder.HasMany(g => g.Produtos)
                .WithOne(p => p.Grupo)
                .HasForeignKey(p => p.GrupoId);


            builder.ToTable("grupos");

        }
    }
}
