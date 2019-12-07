using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resenje_2.Models
{
    //Checking if there is already a grade for a given student and course in exam.
    public class CheckForValidExam : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = new ApplicationDbContext();
            var exam = (Exam)validationContext.ObjectInstance;
            foreach(var ex in _context.Exams)
            {
                if(ex.StudentId == exam.StudentId && ex.CourseId == exam.CourseId)
                {
                    return new ValidationResult("A student cannot have more than 1 grade for a given course.");
                }
            }

            return ValidationResult.Success;           
            
        }
    }
}