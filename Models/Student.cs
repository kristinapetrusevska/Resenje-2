using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resenje_2.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required (ErrorMessage="Please enter a name.")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a surname.")]
        [StringLength(20)]
        public string Surname { get; set; }

        [StringLength(25)]
        public string Address { get; set; }

        [StringLength(20)]
        public string Town { get; set; }      
        public string FullName()
        {
            return Name + " " + Surname;
        }
    }
}