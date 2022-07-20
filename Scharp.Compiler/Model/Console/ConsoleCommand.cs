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
        public void Initialize()
        {
            string data_ = "";
            while (true)
            {
                data_ = System.Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(data_) && data_ == string.Empty)
                    continue;
                foreach (var item in this)
                {
                    if(item.ToLower)
                        data_ = data_.ToLower();
                    if (item.IsRegex)
                    {
                        if(Regex.IsMatch(data_,item.command))
                        {
                            if (item.Event != null)
                                item.Event(data_);
                            continue;
                        }
                        if (item.Event != null)
                            item.Event(data_);
                        continue;
                    }
                    if(data_ == item.command)
                        if (item.Event != null)
                            item.Event(data_);
                }
            }
        }
    }
}
