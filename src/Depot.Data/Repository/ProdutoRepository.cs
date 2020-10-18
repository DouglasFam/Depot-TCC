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
   public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DepotContext context) : base(context)  { }

        public async Task<Produto> ObterProdutoFornecedor(int id)
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
               .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .Include(e => e.Estoque)
                .Include(g => g.GrupoProduto)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorEstoque(int EstoqueId)
        {
            return await Buscar(p => p.EstoqueId == EstoqueId);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(int fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorGrupo(int GrupoID)
        {
            return await Buscar(p => p.GrupoId == GrupoID);
        }
    }
}
