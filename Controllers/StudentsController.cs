using Resenje_2.Models;
using Resenje_2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resenje_2.Controllers
{
    public class StudentsController : Controller
    {
        public ApplicationDbContext _context;
        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //Students
        public ActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }
        //Details/1
        public ActionResult Details(int id)
        {
           var student = _context.Students.SingleOrDefault(m => m.Id == id);
            return View(student);
        }
        public ActionResult Delete(int id)
        {
            var student = _context.Students.SingleOrDefault(c => c.Id == id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index", "Students");
        }
        
        public ActionResult Edit(int id)
        {
            var student = _context.Students.SingleOrDefault(c => c.Id == id);
            if (student == null) return HttpNotFound();
           
            return View("StudentForm", student);
        }
        [HttpPost]
        public ActionResult Save(Student student)
        {
            if (!ModelState.IsValid)
            {               
                return View("CustomerForm", student);
            }
            if (student.Id == 0)
                _context.Students.Add(student);
            else
            {
                var studentInDb = _context.Students.Single(c => c.Id == student.Id);
                studentInDb.Name = student.Name;
                studentInDb.Surname=student.Surname;
                studentInDb.Address=student.Address;
                studentInDb.Town=student.Town;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Students");

        }
        public ActionResult New()
        {
            var student = new Student();
            return View("StudentForm", student);
        }
        public ActionResult Master()
        {
            List<StudentViewModel> master;
            master = new List<StudentViewModel>();
            foreach (var item in _context.Students.ToList())
            {
                var viewModel = new StudentViewModel()
                {
                    student = item,
                    courses = _context.Courses.ToList(),
                    exams = _context.Exams.Where(m => m.StudentId == item.Id).ToList()
                };
                master.Add(viewModel);
            }
            return View(master);
        }
    }
}