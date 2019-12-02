using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.Cinematography.Controllers
{
    [Area("Cinematography")]
    public class ListISRCFilmsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListISRCFilmsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cinematography/ListISRCFilms
        public async Task<IActionResult> Index()
        {
            return View(await _context.listISRCFilms.ToListAsync());
        }

        // GET: Cinematography/ListISRCFilms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listISRCFilms = await _context.listISRCFilms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listISRCFilms == null)
            {
                return NotFound();
            }

            return View(listISRCFilms);
        }

        // GET: Cinematography/ListISRCFilms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cinematography/ListISRCFilms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieTitle,Country,ReleaseYear,Director,Duration,AgeRestrictions,DateCertificated")] ListISRCFilms listISRCFilms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listISRCFilms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listISRCFilms);
        }

        // GET: Cinematography/ListISRCFilms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listISRCFilms = await _context.listISRCFilms.FindAsync(id);
            if (listISRCFilms == null)
            {
                return NotFound();
            }
            return View(listISRCFilms);
        }

        // POST: Cinematography/ListISRCFilms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieTitle,Country,ReleaseYear,Director,Duration,AgeRestrictions,DateCertificated")] ListISRCFilms listISRCFilms)
        {
            if (id != listISRCFilms.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listISRCFilms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListISRCFilmsExists(listISRCFilms.Id))
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
            return View(listISRCFilms);
        }

        // GET: Cinematography/ListISRCFilms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listISRCFilms = await _context.listISRCFilms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listISRCFilms == null)
            {
                return NotFound();
            }

            return View(listISRCFilms);
        }

        // POST: Cinematography/ListISRCFilms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listISRCFilms = await _context.listISRCFilms.FindAsync(id);
            _context.listISRCFilms.Remove(listISRCFilms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListISRCFilmsExists(int id)
        {
            return _context.listISRCFilms.Any(e => e.Id == id);
        }
    }
}
