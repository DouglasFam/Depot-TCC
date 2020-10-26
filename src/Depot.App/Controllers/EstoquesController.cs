using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Depot.App.ViewModels;
using Depot.Business.Interfaces;
using AutoMapper;
using Depot.Business.Models;

namespace Depot.App.Controllers
{
    public class EstoquesController : BaseController
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IMapper _mapper;

        public EstoquesController(IEstoqueRepository estoqueRepository,
                                  IMapper mapper,
                                  INotificador notificador) : base(notificador)
        {
            _estoqueRepository = estoqueRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<EstoqueViewModel>>(await _estoqueRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(int id)
        {
            var estoqueViewModel = await ObterEstoqueEndereco(id);

            if (estoqueViewModel == null)
            {
                return NotFound();
            }

            return View(estoqueViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstoqueViewModel estoqueViewModel)
        {
            if (!ModelState.IsValid) return View(estoqueViewModel);

            estoqueViewModel.DataCadastro = DateTime.Now;

            await _estoqueRepository.Adicionar(_mapper.Map<Estoque>(estoqueViewModel));

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int id)
        {
            var estoqueViewModel = await ObterEstoque(id);

            if (estoqueViewModel == null)
            {
                return NotFound();
            }
            return View(estoqueViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EstoqueViewModel estoqueViewModel)
        {
            if (id != estoqueViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return View(estoqueViewModel);

            var estoque = _mapper.Map<Estoque>(estoqueViewModel);

            await _estoqueRepository.Atualizar(estoque);

            return RedirectToAction("Index");
        }
  

        public async Task<IActionResult> Delete(int id)
        {

            var estoque = await ObterEstoque(id);

            if (estoque == null)
            {
                return NotFound();
            }


            return View(estoque);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estoque = await ObterEstoque(id);

            if (estoque == null) return NotFound();

            await _estoqueRepository.Remover(id);

            return RedirectToAction("Index");
        }   
        
        private async Task<EstoqueViewModel> ObterEstoque(int id)
        {
            return _mapper.Map<EstoqueViewModel>(await _estoqueRepository.ObterEstoquePorId(id));
        }
        private async Task<EstoqueViewModel> ObterEstoqueEndereco(int id)
        {
            return _mapper.Map<EstoqueViewModel>(await _estoqueRepository.ObterEstoqueEndereco(id));
        }

        private async Task<EstoqueViewModel>ObterEstoqueProduto(int id)
        {
            return _mapper.Map<EstoqueViewModel>(await _estoqueRepository.ObterEstoquePorProduto(id));
        }
    }
}
