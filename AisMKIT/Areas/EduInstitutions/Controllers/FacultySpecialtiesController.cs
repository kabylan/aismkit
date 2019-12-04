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
    public class FacultySpecialtiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacultySpecialtiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EduInstitutions/FacultySpecialties
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FacultySpecialties.Include(f => f.Faculty).Include(f => f.Specialty);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EduInstitutions/FacultySpecialties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultySpecialty = await _context.FacultySpecialties
                .Include(f => f.Faculty)
                .Include(f => f.Specialty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facultySpecialty == null)
            {
                return NotFound();
            }

            return View(facultySpecialty);
        }

        // GET: EduInstitutions/FacultySpecialties/Create
        public IActionResult Create()
        {
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name");
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "Id", "Name");
            return View();
        }

        // POST: EduInstitutions/FacultySpecialties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SpecialtyId,FacultyId")] FacultySpecialty facultySpecialty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facultySpecialty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name", facultySpecialty.FacultyId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "Id", "Name", facultySpecialty.SpecialtyId);
            return View(facultySpecialty);
        }

        // GET: EduInstitutions/FacultySpecialties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultySpecialty = await _context.FacultySpecialties.FindAsync(id);
            if (facultySpecialty == null)
            {
                return NotFound();
            }
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name", facultySpecialty.FacultyId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "Id", "Name", facultySpecialty.SpecialtyId);
            return View(facultySpecialty);
        }

        // POST: EduInstitutions/FacultySpecialties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SpecialtyId,FacultyId")] FacultySpecialty facultySpecialty)
        {
            if (id != facultySpecialty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facultySpecialty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultySpecialtyExists(facultySpecialty.Id))
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
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name", facultySpecialty.FacultyId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "Id", "Name", facultySpecialty.SpecialtyId);
            return View(facultySpecialty);
        }

        // GET: EduInstitutions/FacultySpecialties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultySpecialty = await _context.FacultySpecialties
                .Include(f => f.Faculty)
                .Include(f => f.Specialty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facultySpecialty == null)
            {
                return NotFound();
            }

            return View(facultySpecialty);
        }

        // POST: EduInstitutions/FacultySpecialties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facultySpecialty = await _context.FacultySpecialties.FindAsync(id);
            _context.FacultySpecialties.Remove(facultySpecialty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultySpecialtyExists(int id)
        {
            return _context.FacultySpecialties.Any(e => e.Id == id);
        }
    }
}
