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

        public List<Rectangle> ObtainRectangleList(string filename)
        {
            List<Rectangle> rectangleParse = new List<Rectangle>();
            char[] delimiters = { '@', ',', ':', 'x' };

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string[] readLine;
                    //initialParse.Add(reader.ReadLine());
                    readLine = reader.ReadLine().Split(delimiters);

                    Rectangle rectangle = new Rectangle(Convert.ToInt32(readLine[0].Substring(1)), Convert.ToInt32(readLine[1]), Convert.ToInt32(readLine[2]), Convert.ToInt32(readLine[3]), Convert.ToInt32(readLine[4]));
                    rectangleParse.Add(rectangle);
                }
            }
            return rectangleParse;
        }
    }
}
