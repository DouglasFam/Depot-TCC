using Depot.Business.Interfaces;
using Depot.Business.Models;
using Depot.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Data.Repository
{
    public class AcaoRepository : Repository<Acao>, IAcaoRepository
    {
        public AcaoRepository(DepotContext context) : base(context)
        {

        }
        public Task ObterAcao(Acao acao)
        {
            throw new NotImplementedException();
        }
    }
}
