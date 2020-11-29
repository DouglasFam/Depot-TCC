using Depot.Business.Interfaces;
using Depot.Business.Interfaces.Services;
using Depot.Business.Models;
using Depot.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Depot.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {

        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;
      

        public FornecedorService(IFornecedorRepository fornecedorRepository,
                                IEnderecoRepository enderecoRepository,
                                INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
                 || !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

            if (_fornecedorRepository.Buscar(f => f.CNPJ == fornecedor.CNPJ).Any())
            {
                Notificar("Já existe um fornecedor com este documento informado.");
                return;
            }
            var novoDocumento = RemoverCaracteres(fornecedor.CNPJ);
            fornecedor.CNPJ = await novoDocumento;

             
            Endereco insertEndereco = new Endereco();
            Fornecedor insertFornecedor = new Fornecedor();

            try
            {  
                //ENDERECO
                insertEndereco.Cep = fornecedor.Endereco.Cep;
                insertEndereco.Cidade = fornecedor.Endereco.Cidade;
                insertEndereco.Bairro = fornecedor.Endereco.Bairro;
                insertEndereco.Numero = fornecedor.Endereco.Numero;
                insertEndereco.Complemento = fornecedor.Endereco.Complemento;
                insertEndereco.Estado = fornecedor.Endereco.Estado;
                insertEndereco.Logradouro = fornecedor.Endereco.Logradouro;

                await _enderecoRepository.Adicionar(insertEndereco);


                //FORNECEDOR
                insertFornecedor.Nome = fornecedor.Nome;
                insertFornecedor.CNPJ = fornecedor.CNPJ;
                insertFornecedor.Ativo = fornecedor.Ativo;
                insertFornecedor.EnderecoId = insertEndereco.Id;

                await _fornecedorRepository.Adicionar(insertFornecedor);

            }
            catch (Exception ex)
            {

                throw ex;
            }

            //if (_fornecedorRepository.Buscar(f => f.CNPJ == fornecedor.CNPJ).Result.Any())

               
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            if (_fornecedorRepository.Buscar(f => f.CNPJ == fornecedor.CNPJ && f.Id != fornecedor.Id).Any())
            {
                Notificar("Já existe um fornecedor com este documento informado.");
                return;
            }

            var novoDocumento = RemoverCaracteres(fornecedor.CNPJ);
            fornecedor.CNPJ = await novoDocumento;

            //Fornecedor UpdateFornecedor = new Fornecedor();
            ////FORNECEDOR
            //UpdateFornecedor.Nome = fornecedor.Nome;
            //UpdateFornecedor.CNPJ = fornecedor.CNPJ;
            //UpdateFornecedor.Ativo = fornecedor.Ativo;
          

            await _fornecedorRepository.Atualizar(fornecedor);
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
            if (_fornecedorRepository.ObterFornecedorProdutosEndereco(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return;
            }

            await _fornecedorRepository.Remover(id);

        }
        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }

        private async Task<string> RemoverCaracteres(string doc)
        {
            string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(doc, replacement);

            return result;
        }
        
       
    }
}
