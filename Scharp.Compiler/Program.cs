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
using System.Threading.Tasks;
using System.Threading.Tasks;
namespace Scharp.Compiler
{
    
    internal class Program
    {
        static ConsoleCommand consoleCommand = new ConsoleCommand();
        static DataApp dataApp = new DataApp();
        static void Main(string[] args)
        {
            
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

            consoleCommand.Add(new Command((o) =>
            {

                Process.Run("cmd", "ping google.com", (s) =>
                {
                    Console.WriteLine(s);
                });
            })
            {
                command = "ping",
            });



            consoleCommand.Add(new Command((o) =>
            {
               

                Directory.Delete(dataApp.StartupLocationDir, true);
                dataApp.Create();



                Console.WriteLine($"cd {dataApp.StartupLocationDir}; dotnet new console");
                Process.Run("cmd", new string[] { $"cd {dataApp.StartupLocationDir}", "dotnet new console" }, (s) =>
                {
                    Console.WriteLine(s);
                });
            })
            {
                command = "create new",
                ToLower = true,
            });

            consoleCommand.Add(new Command((o) =>
            {

                Console.WriteLine(o);
                 
            })
            {
                IsRegex = true,
                command = "^run ?\"[\\w\\W]+?\"",
                
            });


            //consoleCommand.RunCommand("run \"asdasd\"");

            consoleCommand.Initialize();






            
        }
    }
}
