using Depot.Business.Interfaces;
using Depot.Business.Interfaces.Services;
using Depot.Business.Models;
using Depot.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depot.Business.Services
{
    public class EstoqueService : BaseService, IEstoqueService
    {

        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        public EstoqueService(IEstoqueRepository estoqueRepository,
                              IEnderecoRepository enderecoRepository,
                              INotificador notificador) : base(notificador)
        {
            _estoqueRepository = estoqueRepository;
            _enderecoRepository = enderecoRepository;
        }
        public async Task Adicionar(Estoque estoque)
        {
            if (!ExecutarValidacao(new EstoqueValidation(), estoque)
                 || !ExecutarValidacao(new EnderecoValidation(), estoque.Endereco)) return;

            Estoque insertEstoque = new Estoque();
            Endereco insertEndereco = new Endereco();

            try
            {
                //ENDERECO
                insertEndereco.Cep = estoque.Endereco.Cep;
                insertEndereco.Cidade = estoque.Endereco.Cidade;
                insertEndereco.Bairro = estoque.Endereco.Bairro;
                insertEndereco.Numero = estoque.Endereco.Numero;
                insertEndereco.Complemento = estoque.Endereco.Complemento;
                insertEndereco.Estado = estoque.Endereco.Estado;
                insertEndereco.Logradouro = estoque.Endereco.Logradouro;

                await _enderecoRepository.Adicionar(insertEndereco);

                //ESTOQUE
                insertEstoque.Nome = estoque.Nome;
                insertEstoque.EnderecoId = insertEndereco.Id;
                insertEstoque.DataCadastro = estoque.DataCadastro;
                insertEstoque.Ativo = estoque.Ativo;

                await _estoqueRepository.Adicionar(insertEstoque);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

        }

        public async Task Atualizar(Estoque estoque)
        {
            if (!ExecutarValidacao(new EstoqueValidation(), estoque)) return;

               await _estoqueRepository.Atualizar(estoque);
        }
      

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            Endereco UpdateEndereco = new Endereco();

            //ENDERECO
            UpdateEndereco.Id = endereco.Id;
            UpdateEndereco.Cep = endereco.Cep;
            UpdateEndereco.Cidade = endereco.Cidade;
            UpdateEndereco.Bairro = endereco.Bairro;
            UpdateEndereco.Numero = endereco.Numero;
            UpdateEndereco.Complemento = endereco.Complemento;
            UpdateEndereco.Estado = endereco.Estado;
            UpdateEndereco.Logradouro = endereco.Logradouro;

            await _enderecoRepository.Atualizar(UpdateEndereco);
        }

        public async Task RemoverEndereco(int id)
        {
            await _enderecoRepository.Remover(id);
        }
        public async Task Remover(int id)
        {
            if (_estoqueRepository.ObterEstoqueEndereco(id).Result.Produtos.Any())
            {
                Notificar("O estoque possui produtos cadastrados");
                return;
            }

            await _estoqueRepository.Remover(id);
        }

        public void Dispose()
        {
            _estoqueRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }

    }
}
