using Depot.Business.Interfaces;
using Depot.Business.Models;
using Depot.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Data.Repository
{
   public class GrupoRepository : Repository<Grupo>, IGrupoRepository
    {
        public GrupoRepository(DepotContext context) : base(context) { }

        public async Task<IEnumerable<Grupo>> ObterProdutosPorGrupo(int id)
        {
            return await Db.Grupos
                .Include(p => p.Produtos)
                .OrderBy(p => p.Id == id).ToListAsync();
                
        }

        public async Task<IEnumerable<Grupo>> ObterTodosGrupos()
        {
            return await ObterTodos();
        }
    }
}
