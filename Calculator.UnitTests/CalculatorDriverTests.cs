namespace Calculator.UnitTests
{
    using FluentAssertions;
    using NSubstitute;
    using Xunit;

    public class When_the_calculator_driver_starts
    {
        string actual;
        IConsole console;

        public When_the_calculator_driver_starts()
        {
            // See: http://nsubstitute.github.io/
            console = Substitute.For<IConsole>();
            
            var calculator = new CalculatorDriver(console, Substitute.For<ICalculator>());

            console.WhenForAnyArgs(c => c.WriteLine("")).Do(info => actual = actual ?? info.Arg<string>());
            console.When(c => c.ReadLine()).Do(_ => calculator.Cancel());

            calculator.Start();
        }

        [Fact]
        public void It_should_invoke_DisplayInstructions()
        {
            console.ReceivedWithAnyArgs().WriteLine("");
        }

        [Fact]
        public void It_should_display_the_expected_message()
        {
            actual.ShouldBeEquivalentTo("Enter a number or an operator. Entering a number will add it to the stack. " +
                                        "Entering an operator will pop the last two numbers off the stack (if there are any) " +
                                        "and push the result of the operation back on the stack.");
        }
    }
}
