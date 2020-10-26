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
    public class GrupoProdutosController : BaseController
    {
        private readonly IGrupoProdutoRepository _grupoProdutoRepository;
        private readonly IMapper _mapper;

        public GrupoProdutosController(IGrupoProdutoRepository grupoProdutoRepository,
                                        IMapper mapper,
                                        INotificador notificador) : base(notificador)
        {
            _grupoProdutoRepository = grupoProdutoRepository;
            _mapper = mapper;
        }

        // GET: GrupoProdutos
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<GrupoProdutoViewModel>>(await _grupoProdutoRepository.ObterTodos()));
        }

        // GET: GrupoProdutos/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var grupoProdutoViewModel = await _grupoProdutoRepository.ObterPorId(id);
               
            if (grupoProdutoViewModel == null)
            {
                return NotFound();
            }

            return View(grupoProdutoViewModel);
        }

        // GET: GrupoProdutos/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GrupoProdutoViewModel grupoProdutoViewModel)
        {
            if (!ModelState.IsValid) return View(grupoProdutoViewModel);

            await _grupoProdutoRepository.Adicionar(_mapper.Map<GrupoProduto>(grupoProdutoViewModel));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var grupoProdutoViewModel = await _grupoProdutoRepository.ObterPorId(id);
            if (grupoProdutoViewModel == null)
            {
                return NotFound();
            }
            return View(grupoProdutoViewModel);
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GrupoProdutoViewModel grupoProdutoViewModel)
        {
            if (id != grupoProdutoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(grupoProdutoViewModel);

            var grupoProduto = _mapper.Map<GrupoProduto>(grupoProdutoViewModel);
            await _grupoProdutoRepository.Atualizar(grupoProduto);

            return RedirectToAction("Index");           
        }
     
        public async Task<IActionResult> Delete(int id)
        {

            var grupoProdutoViewModel = await _grupoProdutoRepository.ObterPorId(id);
               
            if (grupoProdutoViewModel == null)
            {
                return NotFound();
            }

            return View(grupoProdutoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupoProdutoViewModel = await _grupoProdutoRepository.ObterPorId(id);

            if (grupoProdutoViewModel == null) return NotFound();

            await _grupoProdutoRepository.Remover(id);
         
            return RedirectToAction("Index");
        }
  
    }
}
