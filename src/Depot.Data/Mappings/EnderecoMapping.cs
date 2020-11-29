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

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");
            builder.Property(c => c.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");


            // 1 : 1 => Endereco : Estoque
            builder.HasOne(e => e.Estoque)
               .WithOne(k => k.Endereco)
                .HasForeignKey<Estoque>(k => k.EnderecoId);

            // 1 : 1 => Endereco : Fornecedor
            builder.HasOne(e => e.Fornecedor)
                .WithOne(f => f.Endereco)
                .HasForeignKey<Fornecedor>(f => f.EnderecoId);


            builder.ToTable("enderecos");

        }


    }
}
