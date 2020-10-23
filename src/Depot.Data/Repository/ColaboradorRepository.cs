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
    public class ColaboradorRepository : Repository<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(DepotContext context) : base(context) { }
        public async Task<IEnumerable<Colaborador>> ObterColaboradores()
        {
            //return await ObterTodos();

            return await Db.Colaboradores.AsNoTracking().Include(p => p.Perfil)
                .ToListAsync();
                

            //return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
            //    .Include(e => e.Estoque)
            //    .Include(g => g.GrupoProduto)
            //    .OrderBy(p => p.Nome).ToListAsync();
        }       

        public async Task<Colaborador> ObterPerfilColaborador(int id)
        {
            return await Db.Colaboradores.AsNoTracking()
                .Include(p => p.Perfil)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Colaborador> ObterPerfilColaboradorHistorico(int id)
        {
            return await Db.Colaboradores.AsNoTracking()
                .Include(h => h.Historicos)
                .Include(p => p.Perfil)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

    }
}
