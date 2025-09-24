using System;
using Reqnroll;

namespace CalculatorReqnrollProject1.StepDefinitions
{
    [Binding]
    public class AmazonSearchFunctionalityStepDefinitions
    {
        Product product;
        Search search;

        [Given("I have search field on Amazon page")]
        public void GivenIHaveSearchFieldOnAmazonPage()
        {
            Console.WriteLine("Amazon search page is opened");
        }

        [When("I search for {string}")]
        public void WhenISearchFor(string laptop)
        {
            Console.WriteLine($"Searching for {laptop}");
            product = new Product { Name=laptop,Price=50000.00};
        }

        [Then("I expect a {string} related resuls")]
        public void ThenIExpectARelatedResuls(string laptop)
        {
            Console.WriteLine("Verified that search results contain " + laptop);
            search = new Search();
            String result=search.DisplayProduct(product);
            if (result != null)
            {
                Assert.Equal(laptop, result);
            }
            else
            {
                Console.WriteLine("Product not found");
                Assert.True(false);
            }
        }
    }
}
