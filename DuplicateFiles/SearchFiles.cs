using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFiles
{
    static internal class SearchFiles
    {
        static private bool FileCompare(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            if (file1 == file2)
                return true;

            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);

            if (fs1.Length != fs2.Length)
            {
                fs1.Close();
                fs2.Close();
                return false;
            }

            do
            {
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while (file1byte == file2byte && file1byte != -1);

            fs1.Close();
            fs2.Close();

            return file1byte == file2byte;
        }
        
        static public List<DuplicateFile> GetDuplicates(string path)
        {
            string[] filePathes = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            var output = new List<DuplicateFile>();
            for (int i = 0; i < filePathes.Length - 1; i++)
            {
                if (filePathes[i] is null)
                    continue;
                bool matched = false;
                for (int j = i + 1; j < filePathes.Length; j++)
                {
                    if (filePathes[j] is null)
                        continue;
                    if (FileCompare(filePathes[i], filePathes[j]))
                    {
                        if (matched == false)
                        {
                            matched = true;
                            var dupl = new DuplicateFile(filePathes[i]);
                            output.Add(dupl);
                        }
                        output.Last().Add(filePathes[j]);
                        filePathes[j] = null;
                    }
                }
            }
            return output;
        }
    }
}
