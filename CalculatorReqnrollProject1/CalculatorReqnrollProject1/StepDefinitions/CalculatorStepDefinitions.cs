namespace CalculatorReqnrollProject1.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on Reqnroll step definitions see https://go.reqnroll.net/doc-stepdef

        int n1, n2, sum;

        [Given("I have opened the calculator")]
        public void GivenHaveOpenedCalculator()
        {
            Console.WriteLine("I have opened the calculator");
            sum = 0;
        }

        [Given("I have entered 5")]
        public void HaveEnteredNumber1()
        {
            Console.WriteLine("I have entered 5");
            n1 = 5;
        }

        [Given("I have entered 3")]
        public void HaveEnteredNumber2()
        {
            Console.WriteLine("I have entered 3");
            n2 = 2;
        }

        [When("I press the equals button")]
        public void WhenButtonIsPress()
        {
            Console.WriteLine("I press the equals button");
            sum = n1 + n2;
        }

        [Then("The result should be 8")]
        public void ThenResultShouldBe8()
        {
            Console.WriteLine("The result should be 8");
            Assert.Equal(8, sum);
        }
    }
}
