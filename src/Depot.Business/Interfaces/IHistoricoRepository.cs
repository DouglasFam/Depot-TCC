using Depot.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Interfaces
{
   public interface IHistoricoRepository : IRepository<HistoricoProduto>
    {
        Task<IEnumerable<HistoricoProduto>> ObterHistorico(int HistoricoId);
        Task<IEnumerable<HistoricoProduto>> ObterHistoricoProduto(int ProdutoId);
        Task<IEnumerable<HistoricoProduto>> ObterHistoricoDepositador(int DepositanteId);
        Task<IEnumerable<HistoricoProduto>> ObterHistoricoRetirante(int RetiranteId);
        Task<IEnumerable<HistoricoProduto>> ObterHistoricoProdutoColaborador();
    }
}
