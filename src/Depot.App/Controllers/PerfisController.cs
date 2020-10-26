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
    public class PerfisController : BaseController
    {

        private readonly IPerfilRepository _perfilRepository;
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IMapper _mapper;

        public PerfisController(IPerfilRepository perfilRepository,
                                 IColaboradorRepository colaboradorRepository,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _perfilRepository = perfilRepository;
            _colaboradorRepository = colaboradorRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PerfilViewModel>>(await _perfilRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(int id)
        {
            var perfilViewModel = await _perfilRepository.ObterPorId(id);

            if  (perfilViewModel == null)
            {
                return NotFound();
            }
                
            return View(perfilViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PerfilViewModel perfilViewModel)
        {
            if (!ModelState.IsValid) return View(perfilViewModel);

            await _perfilRepository.Adicionar(_mapper.Map<Perfil>(perfilViewModel));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var perfilViewModel = await _perfilRepository.ObterPorId(id);

            if (perfilViewModel == null)
            {
                return NotFound();
            }
            
            return View(perfilViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PerfilViewModel perfilViewModel)
        {
            if (id != perfilViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return View(perfilViewModel);

            var perfil = _mapper.Map<Perfil>(perfilViewModel);
            await _perfilRepository.Atualizar(perfil);

            return RedirectToAction("Index");
            
           
        }

        public async Task<IActionResult> Delete(int id)
        {
            var perfilViewModel = await _perfilRepository.ObterPorId(id);

              
            if (perfilViewModel == null)
            {
                return NotFound();
            }

            return View(perfilViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perfilViewModel = await _perfilRepository.ObterPorId(id);

            if (perfilViewModel == null) return NotFound();

            await _perfilRepository.Remover(id);

           
            return RedirectToAction("Index");
        }

 
    }
}
