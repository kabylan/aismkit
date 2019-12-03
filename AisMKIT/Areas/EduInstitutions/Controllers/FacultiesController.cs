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
    public class FacultiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacultiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EduInstitutions/Faculties
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListFaculties.Include(f => f.listOfEducationsModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EduInstitutions/Faculties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.ListFaculties
                .Include(f => f.listOfEducationsModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // GET: EduInstitutions/Faculties/Create
        public IActionResult Create()
        {
            ViewData["ListOfEducationsId"] = new SelectList(_context.ListOfEducations, "Id", "Name");
            return View();
        }

        // POST: EduInstitutions/Faculties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ListOfEducationsId")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faculty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ListOfEducationsId"] = new SelectList(_context.ListOfEducations, "Id", "Name", faculty.ListOfEducationsId);
            return View(faculty);
        }

        // GET: EduInstitutions/Faculties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.ListFaculties.FindAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            ViewData["ListOfEducationsId"] = new SelectList(_context.ListOfEducations, "Id", "Name", faculty.ListOfEducationsId);
            return View(faculty);
        }

        // POST: EduInstitutions/Faculties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ListOfEducationsId")] Faculty faculty)
        {
            if (id != faculty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faculty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyExists(faculty.Id))
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
            ViewData["ListOfEducationsId"] = new SelectList(_context.ListOfEducations, "Id", "Name", faculty.ListOfEducationsId);
            return View(faculty);
        }

        // GET: EduInstitutions/Faculties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.ListFaculties
                .Include(f => f.listOfEducationsModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // POST: EduInstitutions/Faculties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faculty = await _context.ListFaculties.FindAsync(id);
            _context.ListFaculties.Remove(faculty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultyExists(int id)
        {
            return _context.ListFaculties.Any(e => e.Id == id);
        }
    }
}
