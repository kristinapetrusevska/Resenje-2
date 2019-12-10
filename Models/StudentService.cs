using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resenje_2.Models
{
    public class PersonService : IStudentService
    {
        public List<Student> Students { get; set; }

        public PersonService()
        {
            var i = 0;
            Students = new List<Student>(50);
            Students.ForEach(person =>
            {
                i++;
                person.Id = i;
            });
        }

        public IEnumerable<Student> GetAll()
        {
            return Students;
        }

        public Student Get(int id)
        {
            return Students.First(_ => _.Id == id);
        }

        public Student Add(Student student)
        {
            var newid = Students.OrderBy(_ => _.Id).Last().Id + 1;
            student.Id = newid;

            Students.Add(student);

            return student;
        }

        public void Update(int id, Student person)
        {
            var existing = Students.First(_ => _.Id == id);
            existing.Name = person.Name;
            existing.Surname = person.Surname;
            existing.Address = person.Address;
            existing.Town = person.Town;
        }

        public void Delete(int id)
        {
            var existing = Students.First(_ => _.Id == id);
            Students.Remove(existing);
        }
    }

    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        Student Get(int id);
        Student Add(Student person);
        void Update(int id, Student person);
        void Delete(int id);
    }
}