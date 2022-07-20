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
        public Action<string> EventError;
        Dictionary<string, string> Patterns = new Dictionary<string, string>()
        {
            { "include", "@include[\\s]+((\"\")|(\\\"[\\w\\W]+?\\\"))?;" },
            { "url_adn_path", "\"[\\w\\W]+?\"" },
            { "url", "^(https|http)?:\\/\\/[\\w\\.\\/]+" },
        };
        
        public Compiler()
        {

        }
        public void LogError(string str_ = null)
        {
            if (EventError != null)
                EventError(str_);
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
                    try
                    {
                        string Dstring = new Model.WebClient.WebClient().DownloadString(data_);

                        this.Content = this.Content.Replace(item.Value, Dstring);
                    }
                    catch (Exception e)
                    {

                        this.Content = this.Content.Replace(item.Value, "");
                        LogError(e.Message);
                    }
                   
                   
                }
                else if (File.Exists(data_))
                {
                    try
                    {
                        string str_code = File.ReadAllText(data_);
                        if (str_code != "" || str_code != null)
                        {
                            this.Content = this.Content.Replace(item.Value, str_code + "\n");
                        }
                    }
                    catch (Exception e)
                    {

                        this.Content = this.Content.Replace(item.Value, "");
                        LogError(e.Message);
                    }
                }

               
              


            }


        }
    }
}
