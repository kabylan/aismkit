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
    public class EmplPosHistoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmplPosHistoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EduInstitutions/EmplPosHistories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmplPosHistory.Include(e => e.Employee).Include(e => e.Faculty).Include(e => e.Position);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EduInstitutions/EmplPosHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emplPosHistory = await _context.EmplPosHistory
                .Include(e => e.Employee)
                .Include(e => e.Faculty)
                .Include(e => e.Position)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emplPosHistory == null)
            {
                return NotFound();
            }

            return View(emplPosHistory);
        }

        // GET: EduInstitutions/EmplPosHistories/Create
        public IActionResult Create()
        {
            // new SelectList(IEnumerable, "Value", "Text");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name");
            ViewData["PositionId"] = new SelectList(_context.Set<Position>(), "Id", "Name");
            return View();
        }

        // POST: EduInstitutions/EmplPosHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,PositionId,FacultyId")] EmplPosHistory emplPosHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emplPosHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", emplPosHistory.EmployeeId);
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name", emplPosHistory.FacultyId);
            ViewData["PositionId"] = new SelectList(_context.Set<Position>(), "Id", "Name", emplPosHistory.PositionId);
            return View(emplPosHistory);
        }

        // GET: EduInstitutions/EmplPosHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emplPosHistory = await _context.EmplPosHistory.FindAsync(id);
            if (emplPosHistory == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", emplPosHistory.EmployeeId);
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name", emplPosHistory.FacultyId);
            ViewData["PositionId"] = new SelectList(_context.Set<Position>(), "Id", "Name", emplPosHistory.PositionId);
            return View(emplPosHistory);
        }

        // POST: EduInstitutions/EmplPosHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,PositionId,FacultyId")] EmplPosHistory emplPosHistory)
        {
            if (id != emplPosHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emplPosHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmplPosHistoryExists(emplPosHistory.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", emplPosHistory.EmployeeId);
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name", emplPosHistory.FacultyId);
            ViewData["PositionId"] = new SelectList(_context.Set<Position>(), "Id", "Name", emplPosHistory.PositionId);
            return View(emplPosHistory);
        }

        // GET: EduInstitutions/EmplPosHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emplPosHistory = await _context.EmplPosHistory
                .Include(e => e.Employee)
                .Include(e => e.Faculty)
                .Include(e => e.Position)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emplPosHistory == null)
            {
                return NotFound();
            }

            return View(emplPosHistory);
        }

        // POST: EduInstitutions/EmplPosHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emplPosHistory = await _context.EmplPosHistory.FindAsync(id);
            _context.EmplPosHistory.Remove(emplPosHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmplPosHistoryExists(int id)
        {
            return _context.EmplPosHistory.Any(e => e.Id == id);
        }
    }
}
