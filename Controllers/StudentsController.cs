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
        private IStoreAppContext _context= new ApplicationDbContext();

        public StudentsController()
        {
           
        }
        public StudentsController(IStoreAppContext context)
        {
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //Students
        public int Kvadrat(int num)
        {
            return num * num;
        }
        

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
        [ValidateAntiForgeryToken]
        public ActionResult Save(Student student)
        {
            if (!ModelState.IsValid)
            {
                var stud = new Student();       
                return View("CustomerForm", stud);
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