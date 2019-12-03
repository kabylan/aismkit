using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.CultObjectsAndArts.Controllers
{
    [Area("CultObjectsAndArts")]
    public class MainController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CultObjectsAndArts/Main
        public async Task<IActionResult> Index()
        {
            return View(await _context.CultObjectsAndArts.ToListAsync());
        }

        // GET: CultObjectsAndArts/Main/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cultObjectAndArt = await _context.CultObjectsAndArts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cultObjectAndArt == null)
            {
                return NotFound();
            }

            return View(cultObjectAndArt);
        }

        // GET: CultObjectsAndArts/Main/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CultObjectsAndArts/Main/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ShortInfo,Address,Kind,Category,Date")] CultObjectAndArt cultObjectAndArt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cultObjectAndArt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cultObjectAndArt);
        }

        // GET: CultObjectsAndArts/Main/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cultObjectAndArt = await _context.CultObjectsAndArts.FindAsync(id);
            if (cultObjectAndArt == null)
            {
                return NotFound();
            }
            return View(cultObjectAndArt);
        }

        // POST: CultObjectsAndArts/Main/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ShortInfo,Address,Kind,Category,Date")] CultObjectAndArt cultObjectAndArt)
        {
            if (id != cultObjectAndArt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cultObjectAndArt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CultObjectAndArtExists(cultObjectAndArt.Id))
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
            return View(cultObjectAndArt);
        }

        // GET: CultObjectsAndArts/Main/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cultObjectAndArt = await _context.CultObjectsAndArts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cultObjectAndArt == null)
            {
                return NotFound();
            }

            return View(cultObjectAndArt);
        }

        // POST: CultObjectsAndArts/Main/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cultObjectAndArt = await _context.CultObjectsAndArts.FindAsync(id);
            _context.CultObjectsAndArts.Remove(cultObjectAndArt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CultObjectAndArtExists(int id)
        {
            return _context.CultObjectsAndArts.Any(e => e.Id == id);
        }
    }
}
