using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharp.Compiler.Model.Compiler
{
    public class BaseCompiler
    {
        public string path_csharp_file
        {
            get;set;
        }
        public string Content
        {
            get; set;
        } = "";
        public virtual void Open( string path_ = null)
        {
            if (path_ != null)
                path_csharp_file = path_;
            if (File.Exists(path_csharp_file))
            {
                Content = File.ReadAllText(path_csharp_file);
            }
        }
        public virtual void Save(string path_save)
        {
            try
            {
                File.WriteAllText(path_save, Content);
            }
            catch (Exception e)
            {

                System.Console.WriteLine(e.Message);
            }
            
        }
    }
}
