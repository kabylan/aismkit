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
    public class EmplEducationalUnitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmplEducationalUnitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EduInstitutions/EmplEducationalUnits
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmplEducationalUnit.Include(e => e.EducationalUnit).Include(e => e.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EduInstitutions/EmplEducationalUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emplEducationalUnit = await _context.EmplEducationalUnit
                .Include(e => e.EducationalUnit)
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emplEducationalUnit == null)
            {
                return NotFound();
            }

            return View(emplEducationalUnit);
        }

        // GET: EduInstitutions/EmplEducationalUnits/Create
        public IActionResult Create()
        {
            ViewData["EducationalUnitId"] = new SelectList(_context.EducationalUnit, "Id", "Name");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
            return View();
        }

        // POST: EduInstitutions/EmplEducationalUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,EducationalUnitId")] EmplEducationalUnit emplEducationalUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emplEducationalUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EducationalUnitId"] = new SelectList(_context.EducationalUnit, "Id", "Name", emplEducationalUnit.EducationalUnitId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", emplEducationalUnit.EmployeeId);
            return View(emplEducationalUnit);
        }

        // GET: EduInstitutions/EmplEducationalUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emplEducationalUnit = await _context.EmplEducationalUnit.FindAsync(id);
            if (emplEducationalUnit == null)
            {
                return NotFound();
            }
            ViewData["EducationalUnitId"] = new SelectList(_context.EducationalUnit, "Id", "Name", emplEducationalUnit.EducationalUnitId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", emplEducationalUnit.EmployeeId);
            return View(emplEducationalUnit);
        }

        // POST: EduInstitutions/EmplEducationalUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,EducationalUnitId")] EmplEducationalUnit emplEducationalUnit)
        {
            if (id != emplEducationalUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emplEducationalUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmplEducationalUnitExists(emplEducationalUnit.Id))
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
            ViewData["EducationalUnitId"] = new SelectList(_context.EducationalUnit, "Id", "Name", emplEducationalUnit.EducationalUnitId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", emplEducationalUnit.EmployeeId);
            return View(emplEducationalUnit);
        }

        // GET: EduInstitutions/EmplEducationalUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emplEducationalUnit = await _context.EmplEducationalUnit
                .Include(e => e.EducationalUnit)
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emplEducationalUnit == null)
            {
                return NotFound();
            }

            return View(emplEducationalUnit);
        }

        // POST: EduInstitutions/EmplEducationalUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emplEducationalUnit = await _context.EmplEducationalUnit.FindAsync(id);
            _context.EmplEducationalUnit.Remove(emplEducationalUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmplEducationalUnitExists(int id)
        {
            return _context.EmplEducationalUnit.Any(e => e.Id == id);
        }
    }
}
