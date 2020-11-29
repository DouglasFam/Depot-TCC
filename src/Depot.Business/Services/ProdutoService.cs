using Depot.Business.Interfaces;
using Depot.Business.Interfaces.Services;
using Depot.Business.Models;
using Depot.Business.Models.Produtos.Command;
using Depot.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace Depot.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IHistoricoProdutoRepository _historicoProdutoRepository;

        public ProdutoService(IProdutoRepository produtoRepository,
                              IHistoricoProdutoRepository historicoProdutoRepository,
                              INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _historicoProdutoRepository = historicoProdutoRepository;
        }

        public async Task Baixa(ProdutoBaixaCommand produtoBaixaCommand)
        {
            //if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            var produto = await _produtoRepository.ObterPorId(produtoBaixaCommand.ProdutoId);

            if (produtoBaixaCommand.Quantidade >= produto.Quantidade)
            {
                Notificar("A nova quantidade não pode ser inferior a anterior");
                throw new Exception("A nova quantidade não pode ser inferior a anterior");
            }

            produto.Descricao = produtoBaixaCommand.Descricao;
            produto.Quantidade = produtoBaixaCommand.Quantidade;

            //HISTORICO PRODUTOS
            HistoricoProduto novoRegistro =
                new HistoricoProduto(produto, produtoBaixaCommand.ColaboradorId, 2);

            produto.HistoricoProduto.Add(novoRegistro);

            await _produtoRepository.Atualizar(produto);

        }

        public async Task Adicionar(Produto produto, int colaboradorId)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

           
            //HISTORICO PRODUTOS
            HistoricoProduto primeiroHistorico = 
                new HistoricoProduto(produto, colaboradorId, 1);

            
            produto.HistoricoProduto.Add(primeiroHistorico);

            await _produtoRepository.Adicionar(produto);

         //   Notificar($"Foi dado a baixa no produto {produto.Nome}");
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            Produto produtoAnterior = new Produto();
             produtoAnterior = await _produtoRepository.ObterProdutosCompleto(produto.Id);

           // PASSAR OS DADOS DE FORNECEDOR,HISTORICO,ESTOQUE E GRUPO
            

            produto.DataCadastro = produtoAnterior.DataCadastro;
            produto.Ativo = produtoAnterior.Ativo;
            produto.Estoque = produtoAnterior.Estoque;
            produto.Fornecedor = produtoAnterior.Fornecedor;
            produto.Grupo = produtoAnterior.Grupo;
            produto.HistoricoProduto = produtoAnterior.HistoricoProduto;
            produto.EstoqueId = produtoAnterior.EstoqueId;
            produto.GrupoId = produtoAnterior.GrupoId;
            produto.FornecedorId = produtoAnterior.FornecedorId;
           
           
           //await _produtoRepository.Atualizar(produto);

           //await  Baixa(produto);
        }

        public async Task Remover(int id)
        {
            await _produtoRepository.Remover(id);
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

    }
}
