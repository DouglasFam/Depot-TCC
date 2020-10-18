using Depot.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Interfaces
{
   public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(int fornecedorId);

        Task<IEnumerable<Produto>> ObterProdutosPorEstoque(int EstoqueId);

        Task<IEnumerable<Produto>> ObterProdutosPorGrupo(int GrupoID);

        Task<IEnumerable<Produto>> ObterProdutosFornecedores();

        Task<Produto> ObterProdutoFornecedor(int id);
    }
}
