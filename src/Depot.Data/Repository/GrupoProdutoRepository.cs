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
   public class GrupoProdutoRepository : Repository<GrupoProduto>, IGrupoProdutoRepository
    {
        public GrupoProdutoRepository(DepotContext context) : base(context) { }

        public async Task<IEnumerable<GrupoProduto>> ObterGruposProdutos()
        {          
            return await ObterTodos();
        }
    }
}
