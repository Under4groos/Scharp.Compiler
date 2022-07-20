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
        public static void Run(string FileName, string[] args , Action<string> EventOutput = null)
        {
            System.Diagnostics.Process Process_ = new System.Diagnostics.Process
            {
                StartInfo = new ProcessStartInfo(FileName)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                }
            };
          
            
            Process_.Start();
            foreach (var item in args)
            {
                Process_.StandardInput.WriteLine(item);
            }
           

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
