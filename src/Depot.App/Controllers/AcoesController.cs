using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Depot.App.Data;
using Depot.App.ViewModels;

namespace Depot.App.Controllers
{
    public class AcoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Acoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AcaoViewModel.ToListAsync());
        }

        // GET: Acoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acaoViewModel = await _context.AcaoViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acaoViewModel == null)
            {
                return NotFound();
            }

            return View(acaoViewModel);
        }

        // GET: Acoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] AcaoViewModel acaoViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acaoViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acaoViewModel);
        }

        // GET: Acoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acaoViewModel = await _context.AcaoViewModel.FindAsync(id);
            if (acaoViewModel == null)
            {
                return NotFound();
            }
            return View(acaoViewModel);
        }

        // POST: Acoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] AcaoViewModel acaoViewModel)
        {
            if (id != acaoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acaoViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcaoViewModelExists(acaoViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(acaoViewModel);
        }

        // GET: Acoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acaoViewModel = await _context.AcaoViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (acaoViewModel == null)
            {
                return NotFound();
            }

            return View(acaoViewModel);
        }

        // POST: Acoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acaoViewModel = await _context.AcaoViewModel.FindAsync(id);
            _context.AcaoViewModel.Remove(acaoViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcaoViewModelExists(int id)
        {
            return _context.AcaoViewModel.Any(e => e.Id == id);
        }
    }
}
