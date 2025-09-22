using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLib
{
    public class StudentService
    {
        List<Student> students=new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public Student GetStudentById(int id)
        {
            var student = students.Where(o => o.Id == id)
                            .FirstOrDefault();

            if (student == null)
            {
                //throw the exception StudentNotFoundException
                throw new StudentNotFoundException($"Student with id:{id} does not exist");
            }

            return student;
        }

    }
}
