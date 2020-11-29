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
        public async Task<Estoque> ObterEstoqueProduto(int produtoId)
        {
            return await Db.Estoques.AsNoTracking()
                .Include(p => p.Produtos)
                .Include(p => p.Endereco)
                .FirstOrDefaultAsync(p => p.Id == produtoId);

            
                //return await Db.Fornecedores.AsNoTracking()
                //     .Include(c => c.Produtos)
                //     .Include(c => c.Endereco)
                //     .FirstOrDefaultAsync(c => c.Id == id);
            }

        public async Task<Estoque> ObterEstoquePorId(int estoqueId)
        {
            return await Db.Estoques.AsNoTracking()
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(e => e.Id == estoqueId);
        }

        public async Task<Estoque> ObterEstoqueEndereco (int estoqueId)
        {
            return await Db.Estoques.AsNoTracking()
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(e => e.Id == estoqueId);

        }

        public Task<IEnumerable<Estoque>> ObterEstoquePorRegiao(string pRegiao)
        {
            throw new NotImplementedException();
        }
    }
}
