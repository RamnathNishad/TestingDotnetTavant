using TechTalk.SpecFlow;

namespace SpecflowTestDemo.StepDefinitions
{
    [Binding]
    public class CalculatorSteps
    {
        [Given("I have opened the calculator and entered 5 and 3")]
        public void GivenHaveOpenedCalculator()
        {
            Console.WriteLine("I have opened the calculator");
        }

        [When("I press the equals button")]
        public void WhenButtonIsPress()
        {
            Console.WriteLine("I press the equals button");
        }

        [Then("The result should be 8")]
        public void ThenResultShouldBe8()
        {
            Console.WriteLine("The result should be 8");
        }       
    }
}