using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode.Day_1
{
    class FirstPuzzle
    {
        private int value;

        public FirstPuzzle()
        {
            FileParser parser = new FileParser();
            List<int> parsedPuzzleFile = new List<int>();
            string filePath = (@"E:\Projects\AdventOfCode\AdventOfCode\Day 1\puzzle1.txt");
            parsedPuzzleFile = parser.ObtainIntList(filePath);
            
            foreach(int frequency in parsedPuzzleFile)
            {
                value += frequency;
            }
        }

        public string Answer()
        {
            return value.ToString();
        }

    }
}
