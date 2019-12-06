using Resenje_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resenje_2.ViewModels
{
    public class StudentViewModel
    {
        public Student student { get; set; }
        public IEnumerable<Exam> exams { get; set; }
        public IEnumerable<Course> courses { get; set; }
    }
}