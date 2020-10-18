using Depot.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Interfaces
{
   public interface IHistoricoRepository : IRepository<Historico>
    {
        Task<IEnumerable<Historico>> ObterHistorico(int HistoricoId);
        Task<IEnumerable<Historico>> ObterHistoricoProduto(int ProdutoId);

        Task<IEnumerable<Historico>> ObterHistoricoDepositador(int DepositanteId);

        Task<IEnumerable<Historico>> ObterHistoricoRetirante(int RetiranteId);

        Task<IEnumerable<Historico>> ObterHistoricoAutorizador(int AutorizadorId);

        Task<IEnumerable<Historico>> ObterHistoricoProdutoColaborador();
    }
}
