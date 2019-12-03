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
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EduInstitutions/Employees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListEmployees.Include(e => e.listOfEducationsModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EduInstitutions/Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.ListEmployees
                .Include(e => e.listOfEducationsModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: EduInstitutions/Employees/Create
        public IActionResult Create()
        {
            ViewData["ListOfEducationsId"] = new SelectList(_context.ListOfEducations, "Id", "Name");
            return View();
        }

        // POST: EduInstitutions/Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,SecondName,PositionHeld,ListOfEducationsId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ListOfEducationsId"] = new SelectList(_context.ListOfEducations, "Id", "Name", employee.ListOfEducationsId);
            return View(employee);
        }

        // GET: EduInstitutions/Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.ListEmployees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["ListOfEducationsId"] = new SelectList(_context.ListOfEducations, "Id", "Name", employee.ListOfEducationsId);
            return View(employee);
        }

        // POST: EduInstitutions/Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,SecondName,PositionHeld,ListOfEducationsId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["ListOfEducationsId"] = new SelectList(_context.ListOfEducations, "Id", "Address", employee.ListOfEducationsId);
            return View(employee);
        }

        // GET: EduInstitutions/Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.ListEmployees
                .Include(e => e.listOfEducationsModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: EduInstitutions/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.ListEmployees.FindAsync(id);
            _context.ListEmployees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.ListEmployees.Any(e => e.Id == id);
        }
    }
}
