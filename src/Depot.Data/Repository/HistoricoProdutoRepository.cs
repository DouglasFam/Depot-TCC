using Depot.Business.Interfaces;
using Depot.Business.Models;
using Depot.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.Data.Repository
{
    public class HistoricoProdutoRepository : Repository<HistoricoProduto>, IHistoricoProdutoRepository
    {
        public HistoricoProdutoRepository(DepotContext context) : base(context) { }

        public async Task<IEnumerable<HistoricoProduto>> ObterHistoricoProdutos()
        {
            return await ObterTodos();
        }

        public async Task<IEnumerable<HistoricoProduto>> ObterHistoricoProdutoPorColaborador(int id)
        {
            return await Db.HistoricoProdutos
                .Include(c => c.Colaborador)
                .OrderBy(c => c.ColaboradorId == id).ToListAsync();
        }

      

        public async Task<IEnumerable<HistoricoProduto>> ObterHistoricoProtudoPorProduto(int id)
        {
           return await Db.HistoricoProdutos
                .Include(p => p.Produto)
                .OrderBy(p => p.ProdutoId == id).ToListAsync();
        }

        public async Task<IEnumerable<HistoricoProduto>> ObterHistoricoEntrada()
        {
            return await Db.HistoricoProdutos
                .Include(p => p.Colaborador)
                .Include(p => p.Produto)
                .Include(p => p.Acao)
                .AsNoTracking()
               .Where(p => p.AcaoId == 1)
               .OrderByDescending(p => p.DataCriacao).ToListAsync();

              
        }

        public async Task<IEnumerable<HistoricoProduto>> ObterHistoricoSaida()
        {
            return await Db.HistoricoProdutos
              .Include(p => p.Colaborador)
              .Include(p => p.Produto)
              .Include(p => p.Acao)
              .AsNoTracking()
             .Where(p => p.AcaoId == 2)
             .OrderByDescending(p => p.DataCriacao).ToListAsync();
        }
    }
}
