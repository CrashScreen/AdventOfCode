﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Puzzles;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            iPuzzle puzzle = new FourthPuzzle();
            System.Console.WriteLine(puzzle.Answer());
            System.Console.ReadKey();
        }
    }
}
