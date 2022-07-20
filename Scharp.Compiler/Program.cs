using Scharp.Compiler.Data;
using Scharp.Compiler.Model;
using Scharp.Compiler.Model.Compiler;
using Scharp.Compiler.Model.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Process = Scharp.Compiler.Model.Process;
 
namespace Scharp.Compiler
{
    internal class Program
    {
        static ConsoleCommand consoleCommand = new ConsoleCommand();
        static DataApp dataApp = new DataApp();
        static Model.Compiler.Compiler compiler = new Model.Compiler.Compiler();
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
               
                Directory.Delete(dataApp.StartupLocationDir, true);
                dataApp.Create();
                Console.WriteLine($"cd {dataApp.StartupLocationDir}; dotnet new console");
                Process.Run("cmd", new string[] { $"cd {dataApp.StartupLocationDir}", "dotnet new console"});
                
            })
            {
                command = "create new",
                ToLower = true,
            });

            consoleCommand.Add(new Command((o) =>
            {
                string path_cs_file = Regex.Match(o, "\"[\\w\\W]+?\"").Value.Replace("\"" , "");
                if (!File.Exists(path_cs_file))
                    return;          
                string path_main_cs_ = Path.Combine(dataApp.StartupLocationDir, "Program.cs");

                if (!File.Exists(path_main_cs_))
                    return;
                compiler.EventError += (e) =>
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[ERROR]: {e}");
                };
                compiler.Open(path_cs_file);
                compiler.Rebuild();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(compiler.Content);
                FileInfo fi = new FileInfo(path_cs_file);
                compiler.Save(Path.Combine(dataApp.StartupLocationDir, "Program.cs"));
                Process.Run("cmd", new string[] { $"cd {dataApp.StartupLocationDir}", "dotnet build " }, (s) =>
                {
                    Console.WriteLine(s);
                });
                Process.Run("cmd", new string[] { $"cd {dataApp.StartupLocationDir}", "dotnet run " }, (s) =>
                {
                    Console.WriteLine(s);
                });
            })
            {
                IsRegex = true,
                command = "^run ?\"[\\w\\W]+?\"",
                
            });

            consoleCommand.Add(new Command((o) =>
            {
                Console.WriteLine($"Commands");
                foreach (var item in consoleCommand)
                {
                    Console.WriteLine($"  {item.command}");
                }
                 
            })
            {
                command = "/help",
            });

            consoleCommand.Initialize();
        }
    }
}
