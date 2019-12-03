using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.SubInstitutions.Controllers
{
    [Area("SubInstitutions")]
    public class MainController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubInstitutions/Main
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubInstitutions.ToListAsync());
        }

        // GET: SubInstitutions/Main/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subInstitution = await _context.SubInstitutions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subInstitution == null)
            {
                return NotFound();
            }

            return View(subInstitution);
        }

        // GET: SubInstitutions/Main/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubInstitutions/Main/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TIN,Name,LegalAddress,Contact,DomainEmail,ShortInfo,Category")] SubInstitution subInstitution)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subInstitution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subInstitution);
        }

        // GET: SubInstitutions/Main/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subInstitution = await _context.SubInstitutions.FindAsync(id);
            if (subInstitution == null)
            {
                return NotFound();
            }
            return View(subInstitution);
        }

        // POST: SubInstitutions/Main/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TIN,Name,LegalAddress,Contact,DomainEmail,ShortInfo,Category")] SubInstitution subInstitution)
        {
            if (id != subInstitution.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subInstitution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubInstitutionExists(subInstitution.Id))
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
            return View(subInstitution);
        }

        // GET: SubInstitutions/Main/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subInstitution = await _context.SubInstitutions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subInstitution == null)
            {
                return NotFound();
            }

            return View(subInstitution);
        }

        // POST: SubInstitutions/Main/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subInstitution = await _context.SubInstitutions.FindAsync(id);
            _context.SubInstitutions.Remove(subInstitution);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubInstitutionExists(int id)
        {
            return _context.SubInstitutions.Any(e => e.Id == id);
        }
    }
}
