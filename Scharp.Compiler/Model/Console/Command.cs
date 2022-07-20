using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharp.Compiler.Model.Console
{
    public class Command
    {
        public Command()
        {

        }
        public Command(Action<string> action)
        {
            Event += action;
        }
        public string command
        {
            get;set;
        }
        public bool IsRegex
        {
            get; set;
        } = false;
        public bool ToLower
        {
            get; set;
        } = false;
        public Action<string> Event;
    }
}
