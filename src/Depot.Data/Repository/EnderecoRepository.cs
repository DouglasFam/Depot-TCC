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
   public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DepotContext context) : base(context)
        {

        }

        public async Task<Endereco> ObterEndrecoPorFornecedor(int fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                            .Include(e => e.Fornecedor)
                            .ThenInclude(f => f.Endereco)
                            .FirstOrDefaultAsync(e => e.Id == fornecedorId);
        }
    }
}
