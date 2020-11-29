using Depot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Depot.Data.Mappings
{
    public class ColaboradorMapping : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Senha)
              .IsRequired()
              .HasColumnType("varchar(100)");

            //1 : N => Colaboradores : HistoricoProduto
            builder.HasMany(c => c.HistoricoProdutos)
                .WithOne(hp => hp.Colaborador)
                .HasForeignKey(hp => hp.ColaboradorId);
                

            builder.ToTable("colaboradores");

        }
    }
}
