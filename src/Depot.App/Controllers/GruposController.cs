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
    public class GruposController : BaseController
    {
        private readonly IGrupoRepository _grupoRepository;
        private readonly IMapper _mapper;

        public GruposController(IGrupoRepository grupoRepository,
                                        IMapper mapper,
                                        INotificador notificador) : base(notificador)
        {
            _grupoRepository = grupoRepository;
            _mapper = mapper;
        }

        // GET: GrupoProdutos
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<GrupoViewModel>>(await _grupoRepository.ObterTodos()));
        }

        // GET: GrupoProdutos/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var grupoProdutoViewModel = await _grupoRepository.ObterPorId(id);

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
        public async Task<IActionResult> Create(GrupoViewModel grupoProdutoViewModel)
        {
            var verificaPerfil = JsonConvert.DeserializeObject<Colaborador>(HttpContext.Session.GetString("SessionColaborador"));

            if (verificaPerfil.PerfilId != 1 && verificaPerfil.PerfilId != 2)
            {

                Notificar("Seu perfil não tem autorização");
                throw new Exception("Seu perfil não tem autorização");
            }

            if (!ModelState.IsValid) return View(grupoProdutoViewModel);

            await _grupoRepository.Adicionar(_mapper.Map<Grupo>(grupoProdutoViewModel));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var grupoProdutoViewModel = await _grupoRepository.ObterPorId(id);
            if (grupoProdutoViewModel == null)
            {
                return NotFound();
            }
            return View(grupoProdutoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GrupoViewModel grupoProdutoViewModel)
        {
            var verificaPerfil = JsonConvert.DeserializeObject<Colaborador>(HttpContext.Session.GetString("SessionColaborador"));

            if (verificaPerfil.PerfilId != 1 && verificaPerfil.PerfilId != 2)
            {

                Notificar("Seu perfil não tem autorização");
                throw new Exception("Seu perfil não tem autorização");
            }

            if (id != grupoProdutoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(grupoProdutoViewModel);

            var grupoProduto = _mapper.Map<Grupo>(grupoProdutoViewModel);
            await _grupoRepository.Atualizar(grupoProduto);

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

            var grupoProdutoViewModel = await _grupoRepository.ObterPorId(id);

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
            var grupoProdutoViewModel = await _grupoRepository.ObterPorId(id);

            if (grupoProdutoViewModel == null) return NotFound();

            await _grupoRepository.Remover(id);

            return RedirectToAction("Index");
        }

    }
}
