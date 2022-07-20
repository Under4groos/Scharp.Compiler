using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scharp.Compiler.Data
{
    public class DataApp
    {
        public string LocalPath = "Data";
        public string StartupLocationDir
        {
            get;private set;
        } = Path.Combine(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName ,"Data");
        public void Create()
        {
            if (!Directory.Exists(LocalPath))
                Directory.CreateDirectory(LocalPath);
        }
    }
}
