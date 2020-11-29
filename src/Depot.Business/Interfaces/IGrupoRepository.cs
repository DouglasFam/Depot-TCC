using Depot.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Interfaces
{
  public interface IGrupoRepository : IRepository<Grupo>
    {
        Task<IEnumerable<Grupo>> ObterTodosGrupos();
        Task<IEnumerable<Grupo>> ObterProdutosPorGrupo(int id);
    }
}
