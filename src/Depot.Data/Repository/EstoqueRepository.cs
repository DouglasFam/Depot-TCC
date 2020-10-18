using Depot.Business.Interfaces;
using Depot.Business.Models;
using Depot.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Data.Repository
{
    public class EstoqueRepository : Repository<Estoque>, IEstoqueRepository
    {
        public EstoqueRepository(DepotContext context) : base(context)
        {

        }
        public async Task<Estoque> ObterEstoquePorProduto(int produtoId)
        {
            return await Db.Estoques.AsNoTracking()
                .Include(p => p.Produtos)
                .FirstOrDefaultAsync(p => p.Id == produtoId);
        }

        public async Task<Estoque> ObterEstoquePorId(int estoqueId)
        {
            return await Db.Estoques.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == estoqueId);
        }

        public Task<IEnumerable<Estoque>> ObterEstoquePorRegiao(string pRegiao)
        {
            throw new NotImplementedException();
        }
    }
}
