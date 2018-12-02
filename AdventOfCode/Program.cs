using System;
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
            FirstPuzzle firstPuzzle = new FirstPuzzle();
            SecondPuzzle secondPuzzle = new SecondPuzzle();
            System.Console.WriteLine(secondPuzzle.Answer());
            System.Console.ReadKey();
        }
    }
}
