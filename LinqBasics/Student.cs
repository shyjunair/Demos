using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public static List<Student> Students()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student { Id = 1, Age = 12, Name = "Anil" });
            students.Add(new Student { Id = 2, Age = 10, Name = "Sunil" });
            students.Add(new Student { Id = 3, Age = 9, Name = "Chithra" });
            students.Add(new Student { Id = 4, Age = 13, Name = "Arun" });
            students.Add(new Student { Id = 5, Age = 11, Name = "Sushil" });
            return students;
        }
    }
}
