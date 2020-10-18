using Depot.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Interfaces
{
  public  interface IGrupoProdutoRepository : IRepository<GrupoProduto>
    {
        Task<IEnumerable<GrupoProduto>> ObterGruposProdutos();
    }
}
