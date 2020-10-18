using Depot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Depot.Data.Mappings
{
    public class HistoricoProdutoMapping : IEntityTypeConfiguration<HistoricoProduto>
    {
        public void Configure(EntityTypeBuilder<HistoricoProduto> builder)
        {
            builder.HasOne<Historico>(hp => hp.Historico)
                .WithMany(h => h.HistoricoProduto)
                .HasForeignKey(hp => hp.HistoricoId);

            builder.HasOne<Produto>(hp => hp.Produto)
                .WithMany(p => p.HistoricoProduto)
                .HasForeignKey(hp => hp.ProdutoId);

          

            builder.ToTable("HistoricoProdutos");


        }
    }
}
