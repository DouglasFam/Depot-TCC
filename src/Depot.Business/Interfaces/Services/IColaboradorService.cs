using Depot.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Interfaces.Services
{
    public interface IColaboradorService : IDisposable
    {
        Task Adicionar(Colaborador colaborador);
        Task Atualizar(Colaborador colaborador);
        Task Remover(int id);
        
        Task<int> AutenticaUsuario(string email, string senha);

    }
}
