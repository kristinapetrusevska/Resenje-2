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
        public ActionResult Index()
        {
            var exams = _context.Exams.Include(m=>m.Course).Include(m=>m.Student).ToList();
            
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
                courses=_context.Courses.ToList()

            };
            return View("ExamForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Exam exam)
        {
            if (!ModelState.IsValid)
            {
                return View("ExamForm", exam);
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
            var students=_context.Students.ToList();
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