using Depot.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Depot.Data.Mappings
{
    public class HistoricoProdutoMapping : IEntityTypeConfiguration<HistoricoProduto>
    {
        public void Configure(EntityTypeBuilder<HistoricoProduto> builder)
        {
            builder.HasKey(hp => hp.Id);

            //builder.Property(hp => hp.AcaoId)
            //    .IsRequired()
            //    .HasColumnType("int");

            builder.Property(hp => hp.EstoqueId)
                .IsRequired()
                .HasColumnType("Int");

            builder.Property(hp => hp.GrupoId)
                .IsRequired()
                .HasColumnType("Int");

            builder.Property(hp => hp.FornecedorId)
                .IsRequired()
                .HasColumnType("Int");

            builder.Property(hp => hp.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(hp => hp.Descricao)
                .IsRequired()
                .HasColumnType("nvarchar(1000)");

            builder.Property(hp => hp.Quantidade)
                .IsRequired()
                .HasColumnType("Int");

            builder.Property(hp => hp.Ativo)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(hp => hp.DataCriacao)
                .IsRequired()
                .HasColumnType("datetime");



            builder.ToTable("historicoprodutos");


        }
    }
}
