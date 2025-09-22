using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestLib;

namespace TestProject1
{
    public class StudentServiceTest
    {

        [Fact]
        public void TestGetStudentsAssertEqual()
        {
            //Arrange
            StudentService studentService = new StudentService();
            
            Student student = new Student();
            studentService.AddStudent(student);

            //Act
            var students = studentService.GetStudents();
            var count = students.Count();

            //Assert
            Assert.Equal(0, count);

        }

        [Fact]
        public void TestGetStudentsAssertNotEqual()
        {
            //Arrange
            StudentService studentService = new StudentService();

            Student student = new Student();
            studentService.AddStudent(student);

            //Act
            var students = studentService.GetStudents();
            var count = students.Count();

            //Assert
            Assert.NotEqual(0, count);

        }

        [Fact]
        public void TestGetStudentByIdUsingAssertNull()
        {
            StudentService studentService = new StudentService();

            Student student = new Student { Id=1,Name="John"};
            studentService.AddStudent(student);

            Student actual=studentService.GetStudentById(2);

            Assert.Null(actual);

        }

        [Fact]
        public void TestGetStudentByIdUsingAssertNotNull()
        {
            StudentService studentService = new StudentService();

            Student student = new Student { Id = 1, Name = "John" };
            studentService.AddStudent(student);

            Student actual = studentService.GetStudentById(1);

            Assert.NotNull(actual);

        }

        [Fact]
        public void GetStudentById_ThrowsStudentNotFoundException()
        {
            StudentService studentService = new StudentService();

            Student student = new Student { Id = 1, Name = "John" };
            studentService.AddStudent(student);

            var exception = Assert.Throws<StudentNotFoundException>(()=> studentService.GetStudentById(2));

            Assert.Equal("Student with id:2 does not exist", exception.Message);
        }
    }
}
