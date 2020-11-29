using Depot.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Interfaces.Services
{
   public interface IEstoqueService : IDisposable
    {
        Task Adicionar(Estoque estoque);
        Task Atualizar(Estoque estoque);
        Task AtualizarEndereco(Endereco endereco);
        Task RemoverEndereco(int id);
        Task Remover(int id);

    }
}
