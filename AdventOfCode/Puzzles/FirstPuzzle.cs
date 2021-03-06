﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode.Puzzles
{
    class FirstPuzzle : iPuzzle
    {
        FileParser parser = new FileParser();
        string filePath = (@"E:\Projects\AdventOfCode\AdventOfCode\Puzzles\puzzle1.txt");

        List<int> parsedPuzzleFile = new List<int>();

        private int value;
        private int repeatedValue;

        public FirstPuzzle()
        {
            parsedPuzzleFile = parser.ObtainIntList(filePath);
        }

        public string Answer()
        {
            return "Puzzle 1: " + CalculateAnswer1().ToString() + "\nPuzzle 2: " + CalculateAnswer2().ToString();// repeatedValue.ToString();
        }

        private int CalculateAnswer1()
        {
            List<int> calculatedFrequencies = new List<int>();
            foreach (int frequencyChange in parsedPuzzleFile)
            {
                value += frequencyChange;
            }
            return value;
        }

        private int CalculateAnswer2()
        {
            List<int> calculatedFrequencies = new List<int>();
            bool isRepeatValue = false;

            while (!isRepeatValue)
            {
                foreach (int frequencyChange in parsedPuzzleFile)
                {
                    repeatedValue += frequencyChange;
                    if (calculatedFrequencies.Contains(repeatedValue))
                    {
                        isRepeatValue = true;
                        return repeatedValue;
                    }
                    else
                        calculatedFrequencies.Add(repeatedValue);
                }
            }
            return 0;
        }
    }
}
