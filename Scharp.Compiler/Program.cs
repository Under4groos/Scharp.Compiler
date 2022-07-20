using Scharp.Compiler.Data;
using Scharp.Compiler.Model;
using Scharp.Compiler.Model.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Process = Scharp.Compiler.Model.Process;

namespace Scharp.Compiler
{
    
    internal class Program
    {
        static ConsoleCommand consoleCommand = new ConsoleCommand();
        static void Main(string[] args)
        {
            DataApp dataApp = new DataApp();
            dataApp.Create();


            consoleCommand.Add(new Command((o) => 
            {
                
                Process.Run("cmd", "dotnet --list-sdks", (s) =>
                {
                    Console.WriteLine(s);
                });
            })
            {
                command = "dotnet ver",  
            });
            consoleCommand.Initialize();


           




        }
    }
}
