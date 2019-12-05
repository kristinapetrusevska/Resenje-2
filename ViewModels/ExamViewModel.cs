using Resenje_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resenje_2.ViewModels
{
    public class ExamViewModel
    {
        public IEnumerable<Student> students { get; set; }
        public IEnumerable<Course> courses { get; set; }
        public Exam exam { get; set; }

        
    }
}