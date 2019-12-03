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
    public class DirectorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DirectorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EduInstitutions/Directors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListDirectors.Include(d => d.listOfEducationsModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EduInstitutions/Directors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.ListDirectors
                .Include(d => d.listOfEducationsModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // GET: EduInstitutions/Directors/Create
        public IActionResult Create()
        {
            ViewData["ListOfEducationsId"] = new SelectList(_context.ListOfEducations, "Id", "Name");
            return View();
        }

        // POST: EduInstitutions/Directors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,SecondName,ManagementStartDate,ManagementEndDate,ListOfEducationsId")] Director director)
        {
            if (ModelState.IsValid)
            {
                _context.Add(director);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ListOfEducationsId"] = new SelectList(_context.ListOfEducations, "Id", "Name", director.ListOfEducationsId);
            return View(director);
        }

        // GET: EduInstitutions/Directors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.ListDirectors.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            ViewData["ListOfEducationsId"] = new SelectList(_context.ListOfEducations, "Id", "Name", director.ListOfEducationsId);
            return View(director);
        }

        // POST: EduInstitutions/Directors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,SecondName,ManagementStartDate,ManagementEndDate,ListOfEducationsId")] Director director)
        {
            if (id != director.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(director);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorExists(director.Id))
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
            ViewData["ListOfEducationsId"] = new SelectList(_context.ListOfEducations, "Id", "Name", director.ListOfEducationsId);
            return View(director);
        }

        // GET: EduInstitutions/Directors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.ListDirectors
                .Include(d => d.listOfEducationsModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // POST: EduInstitutions/Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var director = await _context.ListDirectors.FindAsync(id);
            _context.ListDirectors.Remove(director);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorExists(int id)
        {
            return _context.ListDirectors.Any(e => e.Id == id);
        }
    }
}
