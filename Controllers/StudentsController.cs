using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Data.Entities;
using StudentManagement.Services;
using StudentManagement.ViewModels;

namespace StudentManagement.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _lessonsService;
        private readonly ICoursesService _coursesService;
        private readonly CourseDbContext _context;
        int PAGESIZE = 5;
        public StudentsController(IStudentService lessonsService, ICoursesService coursesService)
        {
            _lessonsService = lessonsService;
            _coursesService = coursesService;
        }

        // GET: Students
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? courseId, int? pageNumber)
        {
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("title") ? "title_desc" : "";
            ViewData["DateCreatedSortParm"] = String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("date_created") ? "date_created_desc" : "date_created";

            var courses = await _coursesService.GetAll();
            ViewData["CourseId"] = courses.Select(x => new SelectListItem()
            {
                Text = x.CourseID,
                Value = x.Id.ToString(),
                Selected = courseId.HasValue && courseId == x.Id
            });
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;

            return View(await _lessonsService.GetAllFilter(sortOrder, currentFilter, searchString, courseId, pageNumber, PAGESIZE));
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var lesson = await _lessonsService.GetById(id);
            if (lesson == null)
            {
                return NotFound();
            }
            return View(lesson);
        }

        // GET: Students/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CourseId"] = new SelectList(await _coursesService.GetAll(), "Id", "CourseID");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentRequest request)
        {
            if (ModelState.IsValid)
            {
                await _lessonsService.Create(request);
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var lesson = await _lessonsService.GetById(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(await _coursesService.GetAll(), "Id", "CourseID");
            return View(lesson);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentViewModel lesson)
        {
            if (id != lesson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _lessonsService.Update(lesson);
                return RedirectToAction(nameof(Index));
            }
            return View(lesson);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var lesson = await _lessonsService.GetById(id);
            if (lesson == null)
            {
                return NotFound();
            }
            return View(lesson);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _lessonsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
