using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resenje_2.Models
{
    public class Exam
    {
        public int Id { get; set; }

        [Required]
        [Range(6,10)]  
        
        public int Grade { get; set; }
        public Student Student { get; set; }
     
        [Required] 
        [Display(Name ="Student")]
        public int StudentId { get; set; }
        public Course Course { get; set; }

        [Required]
        [CheckForValidExam]
        [Display(Name ="Course")]
        public int CourseId { get; set; }
    }
}