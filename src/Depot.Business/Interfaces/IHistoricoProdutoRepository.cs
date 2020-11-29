using Depot.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Interfaces
{
    public interface IHistoricoProdutoRepository : IRepository<HistoricoProduto>
    {
        Task<IEnumerable<HistoricoProduto>> ObterHistoricoProdutos();

        Task<IEnumerable<HistoricoProduto>> ObterHistoricoEntrada();
        Task<IEnumerable<HistoricoProduto>> ObterHistoricoSaida();

        Task<IEnumerable<HistoricoProduto>> ObterHistoricoProtudoPorProduto(int id);

        Task<IEnumerable<HistoricoProduto>> ObterHistoricoProdutoPorColaborador(int id);

    }
}
