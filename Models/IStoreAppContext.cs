using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Resenje_2.Models
{
    public interface IStoreAppContext : IDisposable
    {
         DbSet<Student> Students { get; }
         DbSet<Course> Courses { get; }
         DbSet<Exam> Exams { get; }
        int SaveChanges();
        void MarkAsModified(Student item);
    }
}