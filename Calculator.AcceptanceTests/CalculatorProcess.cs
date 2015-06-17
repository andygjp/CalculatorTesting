namespace Calculator.AcceptanceTests
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using Properties;

    sealed class CalculatorProcess : IDisposable
    {
        Process process;
        StreamReader output;
        StreamWriter input;
        bool started;

        public CalculatorProcess(bool pauseToAttachDebugger = false)
        {
            var info = new ProcessStartInfo(Settings.Default.PathToCalculatorExe)
            {
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                Arguments = pauseToAttachDebugger ? "-w:20" : ""
            };

            process = new Process { StartInfo = info };
        }

        public void StartAndWaitForInstructions()
        {
            Start();
            ReadOutput();
        }

        public void Start()
        {
            if (started)
            {
                return;
            }
            process.Start();
            output = process.StandardOutput;
            input = process.StandardInput;
            started = true;
        }

        public string ReadResult()
        {
            return ReadOutput() + ReadOutput();
        }

        public string ReadOutput()
        {
            CheckStarted();
            return output.ReadLine();
        }

        public void WriteInstruction(string instruction)
        {
            CheckStarted();
            input.WriteLine(instruction);
        }

        void CheckStarted([CallerMemberName] string callingMethod = null)
        {
            if(started)
            {
                return;
            }
#if VS2013
            string message = string.Format("The Calculator process has not been started. Call Start before calling {0}.", callingMethod);
#else
            string message = $"The Calculator process has not been started. Call {nameof(Start)} before calling {callingMethod}.";
#endif
            throw new InvalidOperationException(message);
        }

        public void Dispose()
        {
            if(started)
            {
                process.Kill();
                process.Dispose();
            }
        }
    }
}