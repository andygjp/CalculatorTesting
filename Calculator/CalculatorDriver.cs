namespace Calculator
{
    using System;
    
    public class CalculatorDriver
    {
        const string CancelExecution = "x";
        readonly IConsole _console;
        readonly ICalculator _calculator;
        string _cancel;

        public CalculatorDriver(IConsole console, ICalculator calculator)
        {
            _console = console;
            _calculator = calculator;
        }

        public void Cancel()
        {
            _cancel = CancelExecution;
        }

        public void Start()
        {
            WriteInstructions();

            var input = ReadLine();
            while (!IsExecutionCancelled(input))
            {
                if (IsOperator(input))
                {
                    // TODO
                    // Pop last two values off the stack, workout the answer, write the answer to the console, 
                    // push the answer on to the stack, write the entire contents of the stack to the console.
                }
                else if (IsNumber(input))
                {
                    // TODO
                    // Add number to stack, write the entire contents of the stack to the console.
                }
                else
                {
                    WriteError();
                }
                input = ReadLine();
            }
        }

        static bool IsExecutionCancelled(string input)
        {
            return string.Equals(input, CancelExecution, StringComparison.OrdinalIgnoreCase);
        }

        void WriteInstructions()
        {
            _console.WriteLine("Enter a number or an operator. Entering a number will add it to the stack. " +
                               "Entering an operator will pop the last two numbers off the stack (if there are any) " +
                               "and push the result of the operation back on the stack.");
        }

        void WriteError()
        {
            _console.WriteLine("Unrecognised value. Enter a number or an operator.");
        }

        string ReadLine()
        {
            var line = _cancel ?? _console.ReadLine();
            return line;
        }

        bool IsNumber(string input)
        {
            // TODO
            return false;
        }

        bool IsOperator(string input)
        {
            // TODO
            return false;
        }
    }
}