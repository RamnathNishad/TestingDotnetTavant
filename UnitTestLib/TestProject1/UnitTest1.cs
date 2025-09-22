using UnitTestLib;

namespace TestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(10,5,15)]
        [InlineData(20,10,30)]
        [InlineData(30,5,35)]
        public void TestAdd(int a, int b, int expected)
        {

            //Arrange: Arrange the elements needed to perform test
            var calculator=new Calculator();            

            //Act: Execute the test case
            var actual=calculator.Add(a, b);

            //Assert: Test is passed or failed based on expected and actual output
            Assert.Equal(expected, actual);          
        }

        [Theory]
        [MemberData(nameof(AddTestData))]
        public void TestAdd2(int a, int b, int expected)
        {

            //Arrange: Arrange the elements needed to perform test
            var calculator = new Calculator();

            //Act: Execute the test case
            var actual = calculator.Add(a, b);

            //Assert: Test is passed or failed based on expected and actual output
            Assert.Equal(expected, actual);
        }


        [Theory]
        [ClassData(typeof(AddTestDataClass))]
        public void TestAdd3(int a, int b, int expected)
        {

            //Arrange: Arrange the elements needed to perform test
            var calculator = new Calculator();

            //Act: Execute the test case
            var actual = calculator.Add(a, b);

            //Assert: Test is passed or failed based on expected and actual output
            Assert.Equal(expected, actual);
        }
        public static IEnumerable<object[]> AddTestData()
        {
            var data = new List<object[]>
            {
                new object[]{2,5,7 },
                new object[]{10,2,12},
                new object[]{11,3,14}
            };

            return data;
        }
    }
}

/*
 When to use what?
 1) [InlineData] - quick small test data sample
 2) [MemberData] - Reuse the data from methods/properties for dynamic data
 3) [ClassData] - Bigger datasets shared across test classes.
*/