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
   public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(DepotContext context) : base(context)
        {

        }

        public async Task<Fornecedor> ObterFornecedorEndereco(int id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(int id)
        {
            return await Db.Fornecedores.AsNoTracking()
                 .Include(c => c.Produtos)
                 .Include(c => c.Endereco)
                 .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
