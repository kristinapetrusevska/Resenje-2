using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resenje_2.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}