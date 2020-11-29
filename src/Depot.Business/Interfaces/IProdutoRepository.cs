using Depot.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Interfaces
{
   public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> ObterProdutosPorFornecedor(int fornecedorId);

        Task<Produto> ObterProdutosCompleto(int id);

        IEnumerable<Produto> ObterProdutosPorEstoque(int EstoqueId);

        IEnumerable<Produto> ObterProdutosPorGrupo(int GrupoID);

        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
    }
}
