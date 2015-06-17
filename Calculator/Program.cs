namespace Calculator
{
    using System.Linq;

    class Program
    {
        public static void Main(string[] args)
        {
            ProcessArgs(args);

            var calculator = new CalculatorDriver(new ConsoleProxy(), new Calculator());
            calculator.Start();
        }

        static void ProcessArgs(string[] args)
        {
            var arg = args.FirstOrDefault(); // Currently, there is only one possible argument.
            DebugHelper.PauseToAttachDebugger(arg);
        }
    }
}
