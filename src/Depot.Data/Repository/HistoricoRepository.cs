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
    public class HistoricoRepository : Repository<Historico>, IHistoricoRepository
    {
        public HistoricoRepository(DepotContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Historico>> ObterHistorico(int HistoricoId)
        {
            return await Buscar(h => h.Id == HistoricoId);
        }

        public async Task<IEnumerable<Historico>> ObterHistoricoAutorizador(int AutorizadorId)
        {
            return await Buscar(h => h.AutorizadorId == AutorizadorId);
        }

        public async Task<IEnumerable<Historico>> ObterHistoricoDepositador(int DepositanteId)
        {
            return await Buscar(h => h.DepositanteId == DepositanteId);
        }

        public async Task<IEnumerable<Historico>> ObterHistoricoRetirante(int RetiranteId)
        {
            return await Buscar(h => h.RetiranteId == RetiranteId);
        }

        public async Task<IEnumerable<Historico>> ObterHistoricoProduto(int ProdutoId)
        {
            return await Db.Historicos.AsNoTracking()
                .Include(p => p.HistoricoProduto)
                .ThenInclude(p => p.Produto)
                .ToListAsync();
        }
        public async Task<IEnumerable<Historico>> ObterHistoricoProdutoColaborador()
        {
            return await Db.Historicos.AsNoTracking()
                .Include(c => c.Colaborador)
                .Include(p => p.HistoricoProduto)
                .ThenInclude(p => p.Produto)
                .ToListAsync();
        }
    }
}
