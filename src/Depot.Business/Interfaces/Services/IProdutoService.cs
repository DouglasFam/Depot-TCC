using Depot.Business.Models;
using Depot.Business.Models.Produtos.Command;
using System;
using System.Threading.Tasks;

namespace Depot.Business.Interfaces.Services
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto produto, int colaboradorId);
        Task Baixa(ProdutoBaixaCommand produtoBaixaCommand);
        Task Atualizar(Produto produto);
        Task Remover(int id);
    }
}
