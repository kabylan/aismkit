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
    public class MainController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EduInstitutions/Main
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ListOfEducations.Include(l => l.ClUchZavedCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EduInstitutions/Main/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfEducations = await _context.ListOfEducations
                .Include(l => l.ClUchZavedCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfEducations == null)
            {
                return NotFound();
            }
            //IEnumerable<FacultySpecialty>  = _context.
            //    .Include(f => f.Faculty) // иниц. самого факультета
            //    .Include(f => f.Specialty) // иниц. самого специальности
            //    .Where(m => m.Id == id) // где Id == id
            //    .ToList();

            // Факультеты
            // выбрать факультеты из таблицы Faculties
            // где ListOfEducationsId равняется id
            // т.е. факультеты этого учебного заведения
            IEnumerable<Faculty> faculties = _context.Faculties
                .Include(l => l.listOfEducationsModel)
                .Where(m => m.ListOfEducationsId == id)
                .ToList();

            // Факультеты-Специальности
            IEnumerable<FacultySpecialty> facultySpecialties = _context.FacultySpecialties
                .Include(f => f.Faculty) // иниц. самого факультета
                .Include(f => f.Specialty) // иниц. самого специальности
                .Where(m => m.Faculty.ListOfEducationsId == id) // где Id == id
                .ToList();

            // Сотрудники-Должностьи
            IEnumerable<EmplPosHistory> emplPosHistories = _context.EmplPosHistories
                .Include(e => e.Employee)
                .Include(e => e.Faculty)
                .Include(e => e.Position)
                .Where(e => e.Faculty.ListOfEducationsId == id) 
                .ToList();

            // Сотрудники-Подразделения
            IEnumerable<EmplEducationalUnit> emplEducationalUnits = _context.EmplEducationalUnits
                .Include(e => e.Employee)
                .Include(e => e.EducationalUnit)
                .Include(e => e.Faculty)
                .Where(e => e.Faculty.ListOfEducationsId == id)
                .ToList();

            // Все Должности в БД
            IEnumerable<Position> positions = _context.Positions.ToList();

            // Все Сотрудники в БД
            IEnumerable<Employee> employees = _context.Employees.ToList();

            // Все Специальности в БД
            IEnumerable<Specialty> specialties = _context.Specialties.ToList();

            // Все Подразделения в БД
            IEnumerable<EducationalUnit> educationalUnits = _context.EducationalUnits.ToList();

            // Все нужные перечисления в представлении, содержаться в модели ListsEduInstitutions
            ListsEduInstitutions listsForEduInstitution = new ListsEduInstitutions();

            listsForEduInstitution.EduInstitution = listOfEducations; // Рассматриваемая Учебное заведение
            listsForEduInstitution.Faculties = faculties;
            listsForEduInstitution.FacultySpecialties = facultySpecialties;
            listsForEduInstitution.EmplPosHistories = emplPosHistories;
            listsForEduInstitution.EmplEducationalUnits = emplEducationalUnits;
            listsForEduInstitution.Positions = positions;
            listsForEduInstitution.Employees = employees;
            listsForEduInstitution.Specialties = specialties;
            listsForEduInstitution.EducationalUnits = educationalUnits;

            return View(listsForEduInstitution);
        }

        // GET: EduInstitutions/Main/Create
        public IActionResult Create()
        {
            ViewData["ClUchZavedCategoryId"] = new SelectList(_context.ClUchZavedCategory, "Id", "Name");
            return View();
        }

        // POST: EduInstitutions/Main/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,INN,Name,Address,DomenNames,DateOfCreated,ClUchZavedCategoryId")] ListOfEducations listOfEducations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfEducations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClUchZavedCategoryId"] = new SelectList(_context.ClUchZavedCategory, "Id", "Name", listOfEducations.ClUchZavedCategoryId);
            return View(listOfEducations);
        }

        // GET: EduInstitutions/Main/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfEducations = await _context.ListOfEducations.FindAsync(id);
            if (listOfEducations == null)
            {
                return NotFound();
            }
            ViewData["ClUchZavedCategoryId"] = new SelectList(_context.ClUchZavedCategory, "Id", "Name", listOfEducations.ClUchZavedCategoryId);
            return View(listOfEducations);
        }

        // POST: EduInstitutions/Main/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,INN,Name,Address,DomenNames,DateOfCreated,ClUchZavedCategoryId")] ListOfEducations listOfEducations)
        {
            if (id != listOfEducations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOfEducations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfEducationsExists(listOfEducations.Id))
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
            ViewData["ClUchZavedCategoryId"] = new SelectList(_context.ClUchZavedCategory, "Id", "Name", listOfEducations.ClUchZavedCategoryId);
            return View(listOfEducations);
        }

        // GET: EduInstitutions/Main/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfEducations = await _context.ListOfEducations
                .Include(l => l.ClUchZavedCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfEducations == null)
            {
                return NotFound();
            }

            return View(listOfEducations);
        }

        // POST: EduInstitutions/Main/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfEducations = await _context.ListOfEducations.FindAsync(id);
            _context.ListOfEducations.Remove(listOfEducations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfEducationsExists(int id)
        {
            return _context.ListOfEducations.Any(e => e.Id == id);
        }
    }
}
