using Resenje_2.Models;
using Resenje_2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Resenje_2.Controllers
{
    public class ExamsController : Controller
    {
        public ApplicationDbContext _context;
        public ExamsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Exams
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CourseSortParm = sortOrder == "Course" ? "course_desc" : "Course";
            ViewBag.GradeSortParm = sortOrder == "Grade" ? "grade_desc" : "Grade";

            var exams = _context.Exams.Include(m => m.Course).Include(m => m.Student).ToList();
            switch (sortOrder)
            {
                case "name_desc":
                    exams = exams.OrderByDescending(s => s.Student.Name).ToList();
                    break;
                case "Course":
                    exams = exams.OrderBy(s => s.Course.Name).ToList();
                    break;
                case "course_desc":
                    exams = exams.OrderByDescending(s => s.Course.Name).ToList();
                    break;
                case "Grade":
                    exams = exams.OrderBy(s => s.Grade).ToList();
                    break;
                case "grade_desc":
                    exams = exams.OrderByDescending(s => s.Grade).ToList();
                    break;
                default:
                    exams = exams.OrderBy(s => s.Student.Name).ToList();
                    break;
            }

            return View(exams);
        }
        public ActionResult Delete(int id)
        {
            var exam = _context.Exams.SingleOrDefault(c => c.Id == id);
            _context.Exams.Remove(exam);
            _context.SaveChanges();
            return RedirectToAction("Index", "Exams");
        }
        public ActionResult Edit(int id)
        {
            var exam = _context.Exams.SingleOrDefault(c => c.Id == id);
            if (exam == null) return HttpNotFound();
            var viewModel = new ExamViewModel()
            {
                exam = exam,
                students = _context.Students.ToList(),
                courses = _context.Courses.ToList()

            };
            return View("ExamForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Exam exam)
        {
            if (!ModelState.IsValid)
            {
                var ex = new Exam();
                var viewModel = new ExamViewModel()
                {
                    exam = ex,
                    courses = _context.Courses.ToList(),
                    students=_context.Students.ToList()
                    
                };
                return View("ExamForm", viewModel);
            }
            if (exam.Id == 0)
                _context.Exams.Add(exam);
            else
            {
                var examInDb = _context.Exams.Single(c => c.Id == exam.Id);
                examInDb.CourseId = exam.CourseId;
                examInDb.StudentId = exam.StudentId;
                examInDb.Grade = exam.Grade;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Exams");

        }
        public ActionResult New()
        {
            var courses = _context.Courses.ToList();
            var students = _context.Students.ToList();
            var viewModel = new ExamViewModel()
            {
                exam = new Exam(),
                courses = courses,
                students = students
            };
            return View("ExamForm", viewModel);
        }
        
    }
}