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
    public class EducationalUnitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EducationalUnitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EduInstitutions/EducationalUnits
        public async Task<IActionResult> Index()
        {
            return View(await _context.EducationalUnits.ToListAsync());
        }

        // GET: EduInstitutions/EducationalUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationalUnit = await _context.EducationalUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationalUnit == null)
            {
                return NotFound();
            }

            return View(educationalUnit);
        }

        // GET: EduInstitutions/EducationalUnits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EduInstitutions/EducationalUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] EducationalUnit educationalUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educationalUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educationalUnit);
        }

        // GET: EduInstitutions/EducationalUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationalUnit = await _context.EducationalUnits.FindAsync(id);
            if (educationalUnit == null)
            {
                return NotFound();
            }
            return View(educationalUnit);
        }

        // POST: EduInstitutions/EducationalUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] EducationalUnit educationalUnit)
        {
            if (id != educationalUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educationalUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationalUnitExists(educationalUnit.Id))
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
            return View(educationalUnit);
        }

        // GET: EduInstitutions/EducationalUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationalUnit = await _context.EducationalUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationalUnit == null)
            {
                return NotFound();
            }

            return View(educationalUnit);
        }

        // POST: EduInstitutions/EducationalUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educationalUnit = await _context.EducationalUnits.FindAsync(id);
            _context.EducationalUnits.Remove(educationalUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationalUnitExists(int id)
        {
            return _context.EducationalUnits.Any(e => e.Id == id);
        }
    }
}
