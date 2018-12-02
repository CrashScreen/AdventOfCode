using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;

namespace AdventOfCode
{
    public class FileParser
    {
        public FileParser()
        {
        }

        public List<int> ObtainIntList(string filename)
        {
            List<int> intParse = new List<int>();
            using (StreamReader reader = new StreamReader(filename))
            {
                while(!reader.EndOfStream)
                {
                    intParse.Add(Convert.ToInt32(reader.ReadLine()));
                }
            }
            return intParse;
        }

        public List<string> ObtainStringList(string filename)
        {
            List<string> stringParse = new List<string>();
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                    stringParse.Add(reader.ReadLine());
            }
            return stringParse;
        }
    }
}
