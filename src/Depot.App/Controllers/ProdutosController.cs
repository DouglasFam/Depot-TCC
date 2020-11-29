using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Depot.App.ViewModels;
using Depot.Business.Interfaces;
using AutoMapper;
using Depot.Business.Models;
using System;
using System.Linq;
using Depot.Business.Interfaces.Services;
using Depot.Business.Models.Produtos.Command;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Depot.App.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IGrupoRepository _grupoRepository;
        private readonly IMapper _mapper;
     

        public ProdutosController(IProdutoRepository produtoRepository,
                                  IProdutoService produtoService,
                                  IFornecedorRepository fornecedorRepository,
                                  IEstoqueRepository estoqueRepotisory,
                                  IGrupoRepository grupoRepository,
                                  IMapper mapper,
                                  INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _fornecedorRepository = fornecedorRepository;
            _produtoService = produtoService;
            _estoqueRepository = estoqueRepotisory;
            _grupoRepository = grupoRepository;
            _mapper = mapper;
        }

      

        public async Task<IActionResult> Index()
        {
            var result = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores()); ;
            return View(result);
        }

      

        public async Task<IActionResult> Details(int id)
        {
            var produtoViewModel = await ObterProduto(id);
              
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopularFornecedores(new ProdutoViewModel());
            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            var verificaPerfil = JsonConvert.DeserializeObject<Colaborador>(HttpContext.Session.GetString("SessionColaborador"));

            if (verificaPerfil.PerfilId != 1 && verificaPerfil.PerfilId != 2)
            {

                Notificar("Seu perfil não tem autorização");
                throw new Exception("Perfil sem autorização");
            }

            produtoViewModel = await PopularFornecedores(produtoViewModel);

            if (!ModelState.IsValid) return View(produtoViewModel);

            produtoViewModel.DataCadastro = DateTime.Now;

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel), verificaPerfil.Id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produtoViewModel = await ObterProduto(id);

           
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            var lista = await PopularFornecedores(produtoViewModel);
            ProdutoViewModel editProduto = new ProdutoViewModel();

            editProduto.Id = produtoViewModel.Id;
            editProduto.Nome = produtoViewModel.Nome;
            editProduto.Ativo = produtoViewModel.Ativo;
            editProduto.DataCadastro = produtoViewModel.DataCadastro;
            editProduto.Descricao = produtoViewModel.Descricao;
            editProduto.Quantidade = produtoViewModel.Quantidade;
            editProduto.EstoqueId = produtoViewModel.EstoqueId;
            editProduto.Estoques = lista.Estoques.ToList();
            editProduto.FornecedorId = produtoViewModel.FornecedorId;
            editProduto.Fornecedores = lista.Fornecedores;
            editProduto.GrupoId = produtoViewModel.GrupoId;
            editProduto.Grupos = lista.Grupos.ToList();
          
            return View(editProduto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();



            if (!ModelState.IsValid) return View(produtoViewModel);

            await _produtoRepository.Atualizar(_mapper.Map<Produto>(produtoViewModel));
            return  RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produto = await ObterProduto(id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await ObterProduto(id);

            if (produto == null)
            {
                return NotFound();
            }

            await _produtoRepository.Remover(id);

            return RedirectToAction("Index");
        }
    
      
        //public async Task Baixa(int id)
        //{
        //    var produtoBaixa = await ObterProduto(id);

        //    await _produtoService.Baixa(produtoBaixa);
        //}

        public async Task<IActionResult> BaixaProduto(int id)
        {
            var verificaPerfil = JsonConvert.DeserializeObject<Colaborador>(HttpContext.Session.GetString("SessionColaborador"));

            if (verificaPerfil.PerfilId != 1 && verificaPerfil.PerfilId != 3)
            {

                Notificar("Seu perfil não tem autorização");
                throw new Exception("Perfil sem autorização");
            }
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            produtoViewModel.Descricao = "";
            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BaixaProduto(int id, ProdutoViewModel produtoViewModel)
        {
            var verificaPerfil = JsonConvert.DeserializeObject<Colaborador>(HttpContext.Session.GetString("SessionColaborador"));

            if (verificaPerfil.PerfilId != 1 && verificaPerfil.PerfilId != 3)
            {

                Notificar("Seu perfil não tem autorização");
                throw new Exception("Perfil sem autorização");
            }

            if (id != produtoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(produtoViewModel);


            await _produtoService.Baixa(new ProdutoBaixaCommand() 
            {
                ColaboradorId = verificaPerfil.Id,
                ProdutoId = id,
                Descricao = produtoViewModel.Descricao,
                Quantidade = produtoViewModel.Quantidade
            });



            return RedirectToAction("Index");
        }

        private async Task<ProdutoViewModel> ObterProduto(int id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
            // produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());


            return produto;
        }
        private async Task<ProdutoViewModel>PopularFornecedores(ProdutoViewModel produto)
        {           
            produto.Fornecedores = _mapper.Map<List<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            produto.Estoques = _mapper.Map<List<EstoqueViewModel>>(await _estoqueRepository.ObterTodos());
            produto.Grupos = _mapper.Map<List<GrupoViewModel>>(await _grupoRepository.ObterTodos());
            return produto;
        }
    }
}
