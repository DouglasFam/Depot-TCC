namespace Depot.Business.Models.Produtos.Command
{
    public class ProdutoBaixaCommand
    {
        public int ColaboradorId { get; set; }

        public int ProdutoId { get; set; }

        public string Descricao { get; set; }
        public int Quantidade { get; set; }
    }
}
