using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.EduInstitutions.Controllers
{
    [Area("EduInstitutions")]
    public class PositionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PositionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EduInstitutions/Positions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Position.ToListAsync());
        }

        // GET: EduInstitutions/Positions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Position
                .FirstOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // GET: EduInstitutions/Positions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EduInstitutions/Positions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Position position)
        {
            if (ModelState.IsValid)
            {
                _context.Add(position);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(position);
        }

        // GET: EduInstitutions/Positions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Position.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }

        // POST: EduInstitutions/Positions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Position position)
        {
            if (id != position.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(position);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionExists(position.Id))
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
            return View(position);
        }

        // GET: EduInstitutions/Positions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Position
                .FirstOrDefaultAsync(m => m.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // POST: EduInstitutions/Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var position = await _context.Position.FindAsync(id);
            _context.Position.Remove(position);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionExists(int id)
        {
            return _context.Position.Any(e => e.Id == id);
        }
    }
}
