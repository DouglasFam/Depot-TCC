using Depot.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Interfaces
{
   public interface IColaboradorRepository : IRepository<Colaborador>
    {
        Task<IEnumerable<Colaborador>> ObterColaboradores();

        Task<Colaborador> ObterPerfilColaborador(int id);

        Task<Colaborador> ObterPerfilColaboradorHistorico(int id);
    }
}
