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
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Depot.App.Controllers
{
    public class HistoricoProdutosController : BaseController
    {
        private readonly IHistoricoProdutoRepository _historicoProdutoRepository;
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IAcaoRepository _acaoRepository;
        private readonly IMapper _mapper;

        public HistoricoProdutosController(IHistoricoProdutoRepository historicoProdutoRepository,
                                           IColaboradorRepository colaboradorRepository,
                                           IProdutoRepository produtoRepository,
                                           IAcaoRepository acaoRepository,
                                           IMapper mapper,
                                           INotificador notificador) : base(notificador)
        {
            _historicoProdutoRepository = historicoProdutoRepository;
            _colaboradorRepository = colaboradorRepository;
            _produtoRepository = produtoRepository;
            _acaoRepository = acaoRepository;
            _mapper = mapper;
        }

        // GET: HistoricoProdutos
        public async Task<IActionResult> Index()
        {
            var result = _mapper.Map<IEnumerable<HistoricoProdutoViewModel>>(await _historicoProdutoRepository.ObterTodos());

            return View(result);
        }

        // GET: HistoricoProdutos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var historicoProdutoViewModel = await _historicoProdutoRepository.ObterPorId(id);
               
            if (historicoProdutoViewModel == null)
            {
                return NotFound();
            }

            return View(historicoProdutoViewModel);
        }

        public async Task<IActionResult> HistoricoEntrada()
        {
            var verificaPerfil = JsonConvert.DeserializeObject<Colaborador>(HttpContext.Session.GetString("SessionColaborador"));

            if (verificaPerfil.PerfilId != 1 && verificaPerfil.PerfilId != 2)
            {

                Notificar("Seu perfil não tem autorização");
                throw new Exception("Seu perfil não tem autorização");
            }

            var resultEntrada = _mapper.Map<IEnumerable<HistoricoProdutoViewModel>>(await _historicoProdutoRepository.ObterHistoricoEntrada());
            return View(resultEntrada);
        }

        public async Task<IActionResult> HistoricoSaida()
        {
            var verificaPerfil = JsonConvert.DeserializeObject<Colaborador>(HttpContext.Session.GetString("SessionColaborador"));

            if (verificaPerfil.PerfilId != 1 && verificaPerfil.PerfilId != 3)
            {

                Notificar("Seu perfil não tem autorização");
                throw new Exception("Seu perfil não tem autorização");
            }

            var resultSaida = _mapper.Map<IEnumerable<HistoricoProdutoViewModel>>(await _historicoProdutoRepository.ObterHistoricoSaida());
            return View(resultSaida);
        }

        // GET: HistoricoProdutos/Create
        //public async Task<IActionResult> Create()
        //{
        //    var historicoViewModel = await PopularHistorico(new HistoricoProdutoViewModel());

        //    return View(historicoViewModel);
        //}

        //// POST: HistoricoProdutos/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create( HistoricoProdutoViewModel historicoProdutoViewModel)
        //{
        //    if (!ModelState.IsValid) return View(historicoProdutoViewModel);

        //    var historicoProduto = _mapper.Map<HistoricoProduto>(historicoProdutoViewModel);


        //}

        // GET: HistoricoProdutos/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var historicoProdutoViewModel = await _context.HistoricoProdutoViewModel.FindAsync(id);
        //    if (historicoProdutoViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ColaboradorId"] = new SelectList(_context.Set<ColaboradorViewModel>(), "Id", "Email", historicoProdutoViewModel.ColaboradorId);
        //    ViewData["ProdutoId"] = new SelectList(_context.ProdutoViewModel, "Id", "Descricao", historicoProdutoViewModel.ProdutoId);
        //    return View(historicoProdutoViewModel);
        //}

        //// POST: HistoricoProdutos/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,AcaoId,ColaboradorId,ProdutoId,EstoqueId,FornecedorId,GrupoId,Nome,Descricao,Quantidade,Ativo,DataCriacao")] HistoricoProdutoViewModel historicoProdutoViewModel)
        //{
        //    if (id != historicoProdutoViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(historicoProdutoViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!HistoricoProdutoViewModelExists(historicoProdutoViewModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ColaboradorId"] = new SelectList(_context.Set<ColaboradorViewModel>(), "Id", "Email", historicoProdutoViewModel.ColaboradorId);
        //    ViewData["ProdutoId"] = new SelectList(_context.ProdutoViewModel, "Id", "Descricao", historicoProdutoViewModel.ProdutoId);
        //    return View(historicoProdutoViewModel);
        //}

        //// GET: HistoricoProdutos/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var historicoProdutoViewModel = await _context.HistoricoProdutoViewModel
        //        .Include(h => h.Colaborador)
        //        .Include(h => h.Produto)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (historicoProdutoViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(historicoProdutoViewModel);
        //}

        //// POST: HistoricoProdutos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var historicoProdutoViewModel = await _context.HistoricoProdutoViewModel.FindAsync(id);
        //    _context.HistoricoProdutoViewModel.Remove(historicoProdutoViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private async Task<HistoricoProdutoViewModel> PopularHistorico(HistoricoProdutoViewModel historicoProdutoViewModel)
        {
            historicoProdutoViewModel.Colaboradores = _mapper.Map<List<ColaboradorViewModel>>(await _colaboradorRepository.ObterTodos());
            historicoProdutoViewModel.Produtos = _mapper.Map<List<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
            historicoProdutoViewModel.Acoes = _mapper.Map<List<AcaoViewModel>>(await _acaoRepository.ObterTodos());

            return historicoProdutoViewModel;
           // historicoProdutoViewModel.Acoes = _mapper.Map<List<AcaoViewModel>>(await)
        }
    }
}
