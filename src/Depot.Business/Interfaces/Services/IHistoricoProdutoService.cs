using Depot.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Interfaces.Services
{
    public interface IHistoricoProdutoService : IDisposable
    {
        Task Adicionar(HistoricoProduto historicoProduto);

    }
}
