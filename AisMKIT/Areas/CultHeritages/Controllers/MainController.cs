using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.CultHeritages.Controllers
{
    [Area("CultHeritages")]
    public class MainController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CultHeritages/Main
        public async Task<IActionResult> Index()
        {
            return View(await _context.CultHeritages.ToListAsync());
        }

        // GET: CultHeritages/Main/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cultHeritage = await _context.CultHeritages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cultHeritage == null)
            {
                return NotFound();
            }

            return View(cultHeritage);
        }

        // GET: CultHeritages/Main/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CultHeritages/Main/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ShortInfo,Address,Kind,Category,Date")] CultHeritage cultHeritage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cultHeritage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cultHeritage);
        }

        // GET: CultHeritages/Main/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cultHeritage = await _context.CultHeritages.FindAsync(id);
            if (cultHeritage == null)
            {
                return NotFound();
            }
            return View(cultHeritage);
        }

        // POST: CultHeritages/Main/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ShortInfo,Address,Kind,Category,Date")] CultHeritage cultHeritage)
        {
            if (id != cultHeritage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cultHeritage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CultHeritageExists(cultHeritage.Id))
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
            return View(cultHeritage);
        }

        // GET: CultHeritages/Main/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cultHeritage = await _context.CultHeritages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cultHeritage == null)
            {
                return NotFound();
            }

            return View(cultHeritage);
        }

        // POST: CultHeritages/Main/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cultHeritage = await _context.CultHeritages.FindAsync(id);
            _context.CultHeritages.Remove(cultHeritage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CultHeritageExists(int id)
        {
            return _context.CultHeritages.Any(e => e.Id == id);
        }
    }
}
