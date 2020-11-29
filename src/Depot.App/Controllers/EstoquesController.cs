using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Depot.App.ViewModels;
using Depot.Business.Interfaces;
using AutoMapper;
using Depot.Business.Models;
using Depot.Business.Interfaces.Services;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Depot.App.Controllers
{
    public class EstoquesController : BaseController
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMapper _mapper;

        public EstoquesController(IEstoqueRepository estoqueRepository,
                                  IEstoqueService estoqueService,
                                  IMapper mapper,
                                  INotificador notificador) : base(notificador)
        {
            _estoqueRepository = estoqueRepository;
            _estoqueService = estoqueService;
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
            var verificaPerfil = JsonConvert.DeserializeObject<Colaborador>(HttpContext.Session.GetString("SessionColaborador"));

            if (verificaPerfil.PerfilId != 1 && verificaPerfil.PerfilId != 2)
            {

                Notificar("Seu perfil não tem autorização");
                throw new Exception("Seu perfil não tem autorização");
            }

            if (!ModelState.IsValid) return View(estoqueViewModel);

            estoqueViewModel.DataCadastro = DateTime.Now;

            await _estoqueService.Adicionar(_mapper.Map<Estoque>(estoqueViewModel));

            //await _estoqueRepository.Adicionar(_mapper.Map<Estoque>(estoqueViewModel));

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int id)
        {
            var verificaPerfil = JsonConvert.DeserializeObject<Colaborador>(HttpContext.Session.GetString("SessionColaborador"));

            if (verificaPerfil.PerfilId != 1 && verificaPerfil.PerfilId != 2)
            {

                Notificar("Seu perfil não tem autorização");
                throw new Exception("Seu perfil não tem autorização");
            }

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
            var verificaPerfil = JsonConvert.DeserializeObject<Colaborador>(HttpContext.Session.GetString("SessionColaborador"));

            if (verificaPerfil.PerfilId != 1)
            {

                Notificar("Seu perfil não tem autorização");
                throw new Exception("Seu perfil não tem autorização");
            }

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

        [Route("obter-endereco-estoque/{id:int}")]
        public async Task<IActionResult> ObterEndereco(int id)
        {
            var estoque = await ObterEstoque(id);

            if (estoque == null) return NotFound();

            return PartialView("_DetalhesEndereco", estoque);
        }

        [Route("atualizar-endereco-estoque/{id:int}")]
        public async Task<IActionResult> AtualizarEnderecoEstoque(int id)
        {
            var estoque = await ObterEstoqueEndereco(id);

            if (estoque == null) return NotFound();

            return PartialView("_AtualizarEndereco", new EstoqueViewModel { Endereco = estoque.Endereco });

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("atualizar-endereco-estoque/{id:int}")]
        public async Task<IActionResult> AtualizarEnderecoEstoque(EstoqueViewModel estoqueViewModel)
        {
            ModelState.Remove("Nome");

            if (!ModelState.IsValid) return PartialView("_AtualizarEndereco", estoqueViewModel);

            await _estoqueService.AtualizarEndereco(_mapper.Map<Endereco>(estoqueViewModel.Endereco));

            if (!OperacaoValida()) return PartialView("_AtualizarEndereco", estoqueViewModel);

            var url = Url.Action("ObterEndereco", "Estoques", new { id = estoqueViewModel.Id });

            return Json(new { success = true, url });
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
            return _mapper.Map<EstoqueViewModel>(await _estoqueRepository.ObterEstoqueProduto(id));
        }
    }
}
