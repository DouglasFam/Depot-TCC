using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Depot.App.ViewModels;
using Depot.Business.Interfaces;
using AutoMapper;
using Depot.Business.Models;

namespace Depot.App.Controllers
{
    public class ColaboradoresController : BaseController
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IPerfilRepository _perfilRepository;
        private readonly IMapper _mapper;

        public ColaboradoresController(IColaboradorRepository colaboradorRepository,
                                       IPerfilRepository perfilRepository,
                                     IMapper mapper,
                                     INotificador notificador) : base(notificador)
        {
            _colaboradorRepository = colaboradorRepository;
            _perfilRepository = perfilRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ColaboradorViewModel>>(await _colaboradorRepository.ObterColaboradores()));
        }

        public async Task<IActionResult> Details(int id)
        {
            var colaboradorViewModel = await ObterPerfilColabortador(id);

            if (colaboradorViewModel == null)
            {
                return NotFound();
            }

            return View(colaboradorViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var colaboradorViewModel = await PopularPerfilColaborador(new ColaboradorViewModel());

            return View(colaboradorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ColaboradorViewModel colaboradorViewModel)
        {
             colaboradorViewModel = await PopularPerfilColaborador(colaboradorViewModel);

            if (!ModelState.IsValid) return View(colaboradorViewModel);
          
            await _colaboradorRepository.Adicionar(_mapper.Map<Colaborador>(colaboradorViewModel));

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var colaboradorViewModel = await ObterPerfilColaboradorHistorico(id);
           
            if (colaboradorViewModel == null)
            {
                return NotFound();
            }
            return View(colaboradorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ColaboradorViewModel colaboradorViewModel)
        {
            if (id != colaboradorViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(colaboradorViewModel);

            var colaborador = _mapper.Map<Colaborador>(colaboradorViewModel);
            await _colaboradorRepository.Atualizar(colaborador);

            return RedirectToAction("index");


        }

        public async Task<IActionResult> Delete(int id)
        {
            var colaboradorViewModel = await ObterPerfilColabortador(id);

            if (colaboradorViewModel == null)
            {
                return NotFound();
            }

            return View(colaboradorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaboradorViewModel = await ObterPerfilColabortador(id);

            if (colaboradorViewModel == null) return NotFound();

            await _colaboradorRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }


        private async Task<ColaboradorViewModel> PopularPerfilColaborador(ColaboradorViewModel colaborador)
        {
            colaborador.Perfis = _mapper.Map<IEnumerable<PerfilViewModel>>(await _perfilRepository.ObterTodos());

            return colaborador;

        }

        private async Task<ColaboradorViewModel> ObterPerfilColabortador(int id)
        {
            return _mapper.Map<ColaboradorViewModel>(await _colaboradorRepository.ObterPerfilColaborador(id));
        }

        private async Task<ColaboradorViewModel> ObterPerfilColaboradorHistorico(int id)
        {
            return _mapper.Map<ColaboradorViewModel>(await _colaboradorRepository.ObterPerfilColaboradorHistorico(id));
        }
    }
}
