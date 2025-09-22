using EmployeeRepository;
using Moq;

namespace EmployeeManagement.Tests
{
    public class EmployeeServiceTests
    {
        Mock<IEmployeeRepository> mockRepo;
        EmployeeService service;

        public EmployeeServiceTests()
        {
            mockRepo = new Mock<IEmployeeRepository>();
            service = new EmployeeService(mockRepo.Object);
        }


        [Fact]
        public void GetEmployee_ExistingId()
        {
            //Arrange
            int id = 1;
            Employee emp = new Employee { Id = 1, Name = "John", Salary = 5000 };
            mockRepo.Setup(r=>r.GetEmployee(id)).Returns(emp);

            //Act
            Employee result = service.GetEmployee(id);

            //Assert
            Assert.Equal("John", result.Name);
        }

        [Fact]
        public void GetEmployee_NonExistingId_ThrowsException()
        {
            mockRepo.Setup(r => r.GetEmployee(999)).Returns((Employee)null);

            Assert.Throws<Exception>(() => service.GetEmployee(999));
        }

        [Fact]
        public void RegisterEmployee_ValidEmployee()
        {
            var emp = new Employee { Id = 2, Name = "David", Salary = 40000 };
            mockRepo.Setup(r => r.AddEmployee(emp)).Returns(emp.Id);

            
            int id = service.RegisterEmployee(emp);

            Assert.Equal((int)emp.Id, id);

            mockRepo.Verify(r=>r.AddEmployee(emp),Times.Once());
        }

        [Fact]
        public void RegisterEmployee_InvalidEmployee()
        {
            var emp = new Employee { Id = 4, Name = "", Salary = 30000 };
            Assert.Throws<ArgumentException>(() => service.RegisterEmployee(emp));
        }

        [Fact]
        public void GetAllEmployees_Test()
        {
            List<Employee> emps = new List<Employee>
            {
                new Employee{ Id=1,Name="John",Salary=50000},
                new Employee{ Id=2,Name="Johny",Salary=950000},
                new Employee{ Id=3,Name="Jane",Salary=70000}
            };
            mockRepo.Setup(r => r.GetAllEmployees()).Returns(emps);

            var actualEmps=service.GetEmployees();
            Assert.Equal(emps.Count, actualEmps.Count);
        }


        [Fact]
        public void GetHighestPaidEmployee_Employees_Found()
        {
            var emps = new List<Employee>
            {
                new Employee{ Id=1,Name="John",Salary=50000},
                new Employee{ Id=2,Name="Johny",Salary=950000},
                new Employee{ Id=3,Name="Jane",Salary=70000}
            };

            mockRepo.Setup(r => r.GetAllEmployees()).Returns(emps);

            var top=service.GetHighestPaidEmployee();

            Assert.Equal("Johny", top.Name);
            Assert.Equal(950000, top.Salary);
        }

        [Fact]
        public void GetHighestPaidEmployee_NoEmployee_ThrowsException()
        {
            mockRepo.Setup(r => r.GetAllEmployees()).Returns(new List<Employee>());

            Assert.Throws<Exception>(()=>service.GetHighestPaidEmployee());
        }
    }
}