namespace Calculator
{
    using System;
    using System.Globalization;
    using System.Threading;

    static internal class DebugHelper
    {
        public static void PauseToAttachDebugger(string arg)
        {
            if (!StartsWithWaitArgument(arg))
            {
                return;
            }

            int n;
            if (TryParse(arg.Substring(3), out n))
            {
                PauseExecution(n);
            }
        }

        static bool StartsWithWaitArgument(string arg)
        {
            return !string.IsNullOrWhiteSpace(arg) && arg.StartsWith("-w:", StringComparison.OrdinalIgnoreCase);
        }

        static bool TryParse(string wait, out int n)
        {
            return int.TryParse(wait, NumberStyles.Integer, CultureInfo.InvariantCulture.NumberFormat, out n);
        }

        static void PauseExecution(int n)
        {
            Thread.Sleep(TimeSpan.FromSeconds(n));
        }
    }
}