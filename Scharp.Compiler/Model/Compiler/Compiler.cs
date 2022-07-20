using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scharp.Compiler.Model.Compiler
{
    public class Compiler : BaseCompiler
    {
        Dictionary<string, string> Patterns = new Dictionary<string, string>()
        {
            { "include", "@include[\\s]+((\"\")|(\\\"[\\w\\W]+?\\\"))?;" },
            { "url_adn_path", "\"[\\w\\W]+?\"" },
            { "url", "^(https|http)?:\\/\\/[\\w\\.\\/]+" },
        };
        
        public Compiler()
        {

        }

        void Clearner()
        {
            if (this.Content == null)
                return;
            string data_ = "";
            foreach (Match item in Regex.Matches(this.Content, Patterns["include"]))
            {
                data_ = Regex.Match(item.Value, Patterns["url_adn_path"]).Value.Replace("\"", "").Trim();
                if (data_ == null || data_ == "" || data_ == "\"\"")
                {
                    this.Content = this.Content.Replace(item.Value, "");
                    continue;
                }

            }
        }

        public void Rebuild()
        {
            if (this.Content == null)
                return;
            string data_ = "";
            this.Clearner();
            foreach (Match item in Regex.Matches(this.Content , Patterns["include"]))
            {
                data_ = Regex.Match(item.Value, Patterns["url_adn_path"]).Value.Replace("\"", "").Trim();
                if(Regex.IsMatch(data_, Patterns["url"]))
                {


                }else if (File.Exists(data_))
                {

                }

               
              


            }


        }
    }
}
