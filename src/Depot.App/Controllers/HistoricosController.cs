using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Depot.App.Data;
using Depot.App.ViewModels;
using Depot.Business.Interfaces;
using AutoMapper;
using Depot.Business.Models;

namespace Depot.App.Controllers
{
    public class HistoricosController : BaseController
    {
        private readonly IHistoricoRepository _historicoRepository;
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IMapper _mapper;

        public HistoricosController(IHistoricoRepository historicoRepository,
                                   IColaboradorRepository colaboradorRepository,
                                   IMapper mapper,
                                   INotificador notificador) : base(notificador)
        {
            _historicoRepository = historicoRepository;
            _colaboradorRepository = colaboradorRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<HistoricoViewModel>>(await _historicoRepository.ObterHistoricoProdutoColaborador()));
        }

        public async Task<IActionResult> Details(int id)
        {
            var historicoViewModel = await ObterColaboradorHistorico(id);
               
            if (historicoViewModel == null)
            {
                return NotFound();
            }

            return View(historicoViewModel);
        }

        public async Task<IActionResult> Create()
        {
           var historicoViewlModel = await PopularColaboradores(new HistoricoViewModel());
            return View(historicoViewlModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HistoricoViewModel historicoViewModel)
        {
            historicoViewModel = await PopularColaboradores(new HistoricoViewModel());


            if (!ModelState.IsValid) return View(historicoViewModel);

            await _historicoRepository.Adicionar(_mapper.Map<Historico>(historicoViewModel));
          
                return View(historicoViewModel);
                               
        }

        public async Task<IActionResult> Edit(int id)
        {


            var historicoViewModel = await ObterColaboradorHistorico(id);
            if (historicoViewModel == null)
            {
                return NotFound();
            }
            
            return View(historicoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HistoricoViewModel historicoViewModel)
        {
            if (id != historicoViewModel.Id) return View(historicoViewModel);


            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));


            await _historicoRepository.Atualizar(_mapper.Map<Historico>(historicoViewModel));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var historico = await ObterColaboradorHistorico(id);

            if (historico == null)
            {
                return NotFound();
            }

            return View(historico);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historico = await ObterColaboradorHistorico(id);

            if (historico == null)
            {
                return NotFound();
            }

            await _historicoRepository.Remover(id);
            return RedirectToAction("Index");
        }

        private async Task<HistoricoViewModel> ObterColaboradorHistorico(int id)
        {
            var historico = _mapper.Map<HistoricoViewModel>(await _colaboradorRepository.ObterPerfilColaboradorHistorico(id));   
            
            return historico;
        }

        private async Task<HistoricoViewModel> PopularColaboradores(HistoricoViewModel historico)
        {
            historico.Colaborador = _mapper.Map<IEnumerable<ColaboradorViewModel>>(await _historicoRepository.ObterTodos());

            return historico;
        }
    }
}
