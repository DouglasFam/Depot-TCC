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

            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado.");
                return;
            }
            var novoDocumento = RemoverCaracteres(fornecedor.Documento);

            fornecedor.Documento = await novoDocumento;
            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            if (_fornecedorRepository.Buscar(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado.");
                return;
            }

            await _fornecedorRepository.Atualizar(fornecedor);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
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
