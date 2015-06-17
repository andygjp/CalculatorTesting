namespace Calculator.AcceptanceTests
{
    using FluentAssertions;
    using TechTalk.SpecFlow;

    [Binding]
    public class CalculatorTestsSteps
    {
        CalculatorProcess calculator;

        [Given(@"the calculator exe is running")]
        public void GivenTheCalculatorExeIsRunning()
        {
            calculator = new CalculatorProcess();
            calculator.StartAndWaitForInstructions();
        }
        
        [When(@"I enter (.*)")]
        public void WhenIEnter(string number)
        {
            calculator.WriteInstruction(number);
        }
        
        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(string expected)
        {
            var actual = calculator.ReadResult();
            actual.ShouldBeEquivalentTo(expected);
        }

        [AfterScenario]
        public void CleanUp()
        {
            calculator.Dispose();
        }
    }
}
