using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Resenje_2.Models
{
    public class Course
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }
    }
}