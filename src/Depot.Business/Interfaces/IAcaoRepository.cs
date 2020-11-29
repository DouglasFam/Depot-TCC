using Depot.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Interfaces
{
   public interface IAcaoRepository : IRepository<Acao>
    {
        Task ObterAcao(Acao acao);
    }
}
