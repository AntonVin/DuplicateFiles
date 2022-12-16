using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFiles
{
    public class DuplicateFile
    {
        private List<string> paths;
        public List<string> Paths
        {
            get { return paths; }
            set { paths = value; }
        }

        public DuplicateFile(string path) => paths = new List<string>() { path };

        public void Add(string path)=> paths.Add(path);

    }
}
