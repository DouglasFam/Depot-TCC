using Depot.Business.Interfaces;
using Depot.Business.Models;
using Depot.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Depot.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DepotContext context) : base(context)  { }


        public override Task<Produto> ObterPorId(int id)
        {
            return DbSet
                .Include(p => p.Fornecedor)
                .Include(p => p.HistoricoProduto)
                .Include(p => p.Estoque)
                .Include(p => p.Grupo)
                .FirstOrDefaultAsync(p => p.Id == id); 
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos
                .Include(f => f.Fornecedor)
                .Include(e => e.Estoque)
                .Include(g => g.Grupo)
                .AsNoTracking()
                .Where(p => p.Ativo == true)
                .OrderBy(p => p.Nome).ToListAsync();
        }
        public async Task<Produto> ObterProdutosCompleto(int id)
        {
            return await Db.Produtos
                .Include(p => p.HistoricoProduto)    
                .Include(f => f.Fornecedor)
                .Include(e => e.Estoque)
                .Include(g => g.Grupo)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public IEnumerable<Produto> ObterProdutosPorEstoque(int EstoqueId)
        {
            return Buscar(p => p.EstoqueId == EstoqueId);
        }

        public IEnumerable<Produto> ObterProdutosPorFornecedor(int fornecedorId)
        {
            return Buscar(p => p.FornecedorId == fornecedorId);
        }

        public IEnumerable<Produto> ObterProdutosPorGrupo(int GrupoID)
        {
            return Buscar(p => p.GrupoId == GrupoID);
        }
    
    }
}
