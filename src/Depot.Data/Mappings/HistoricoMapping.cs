using Depot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Depot.Data.Mappings
{
    public class HistoricoMapping : IEntityTypeConfiguration<Historico>
    {
        public void Configure(EntityTypeBuilder<Historico> builder)
        {
            builder.HasKey(h => h.Id);


            builder.Property(h => h.DataMovimento)               
                .HasColumnType("datetime");




            builder.ToTable("Historicos");

        }
    }
}
