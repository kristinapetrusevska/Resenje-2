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
        

        public ActionResult Index(string id, string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.IdSortParm = sortOrder == "Id" ? "id_desc" : "Id";
            var students = new List<Student>();
            
            if (!String.IsNullOrEmpty(id))
            {
                var rez = 0;
              
                 students = _context.Students.Where(s => s.Name.Contains(id) || s.Surname.Contains(id)).ToList(); 

                if (id.Contains(" "))
                {
                    var fullName = id.Split(' ');
                    string str1 = fullName[0];
                    string str2 = fullName[1];
                    students = _context.Students.Where(s => (s.Name.Contains(str1) && s.Surname.Contains(str2))
                                                || (s.Name.Contains(str2) && s.Surname.Contains(str1))).ToList();
                }
                if (Int32.TryParse(id, out rez))
                { students = _context.Students.Where(s => s.Id == rez).ToList(); }
                

            }
            else
            {
                students = _context.Students.ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Id":
                    students = students.OrderBy(s => s.Id).ToList();
                    break;
                case "id_desc":
                    students = students.OrderByDescending(s => s.Id).ToList();
                    break;
                default:
                    students = students.OrderBy(s => s.Name).ToList();
                    break;
            }
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
        public ActionResult Master(string id)
        {
            List<StudentViewModel> master;
            master = new List<StudentViewModel>();
            if (!String.IsNullOrEmpty(id))
            {
                foreach (var item in _context.Students.ToList())
                {
                    var viewModel = new StudentViewModel()
                    {
                        student = item,
                        courses = _context.Courses.ToList(),
                        exams = _context.Exams.Where(m => m.StudentId == item.Id).ToList()
                    };
                    foreach (var it in viewModel.exams.ToList())
                    {
                        if (it.Course.Name.Contains(id) || it.Course.Name.Contains(id.First().ToString().ToUpper()))
                        {
                            master.Add(viewModel);
                            break;
                        }
                    }
                }


            }
            else
            {
               
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
            }
            return View(master);
        }
    }
}