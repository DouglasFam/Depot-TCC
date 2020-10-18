using Depot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Depot.Data.Mappings
{
    public class ProdutoMappings : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.DataCadastro)
                   .HasColumnType("datetime");

            builder.Property(p => p.Ativo)
                .IsRequired()
                .HasColumnType("bit");

           

            builder.ToTable("Produtos");
        }
    }
}
