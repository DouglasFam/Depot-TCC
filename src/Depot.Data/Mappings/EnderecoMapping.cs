using Depot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Depot.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Logradouro)
            .IsRequired()
            .HasColumnType("varchar(200)");

            builder.Property(c => c.Numero)
            .IsRequired()
            .HasColumnType("varchar(50)");

            builder.Property(c => c.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.ToTable("Enderecos");

        }


    }
}
