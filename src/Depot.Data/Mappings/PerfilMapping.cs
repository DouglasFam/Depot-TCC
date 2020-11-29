using Depot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Depot.Data.Mappings
{
   public class PerfilMapping : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
              .IsRequired()
              .HasColumnType("varchar(100)");

            builder.HasOne(p => p.Colaborador)
                  .WithOne(c => c.Perfil);

           

            builder.ToTable("perfis");
        }
    }
}
