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

            builder.Property(c => c.Login)
                .IsRequired()
                .HasColumnType("varchar(8)");

            // 1 : 1 => Colaborador : Perfil
            //builder.HasOne(c => c.Perfil)
            //    .WithOne(p => p.Colaborador);


            // 1 : N => Colaborador : Historico
            builder.HasMany(h => h.Historicos)
                 .WithOne(c => c.Colaborador)
                 .HasForeignKey(c => c.ColaboradorId);

            builder.ToTable("Colaboradores");

        }
    }
}
