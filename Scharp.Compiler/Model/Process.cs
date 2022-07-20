using System;
using System.Diagnostics;

namespace Scharp.Compiler.Model
{
    public static class Process
    {
        public static void Run(string FileName, string Arguments = "", Action<string> EventOutput = null)
        {
            System.Diagnostics.Process Process_ = new System.Diagnostics.Process
            {
                StartInfo = new ProcessStartInfo(FileName, "/c " + Arguments)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,

                }
            };
            Process_.Start();
            while (!Process_.StandardOutput.EndOfStream)
            {
                if (EventOutput != null)
                {
                    EventOutput(Process_.StandardOutput.ReadLine());
                }
            }
        }
    }
}
