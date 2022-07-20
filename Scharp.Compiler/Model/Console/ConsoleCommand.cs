using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scharp.Compiler.Model.Console
{
    public class ConsoleCommand : List<Command>
    {
        
        public ConsoleCommand()
        {

        }
        public void RunCommand(string command)
        {
            
            if (string.IsNullOrEmpty(command) && command == string.Empty)
                return;
            foreach (var item in this)
            {
                if (item.ToLower)
                    command = command.ToLower();
                if (item.IsRegex)
                {
                    if (Regex.IsMatch(command, item.command))
                    {
                        if (item.Event != null)
                            item.Event(Regex.Match(command, item.command).Value);
                        break;
                    }

                }
                else
                {
                    if (command == item.command)
                    {
                        if (item.Event != null)
                            item.Event(command);
                        break;
                    }


                }

            }
        }
        public void Initialize()
        {
           
            while (true)
            {
                RunCommand(System.Console.ReadLine().Trim());
            }
        }
    }
}
