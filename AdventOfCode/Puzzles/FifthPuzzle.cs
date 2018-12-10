using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    class FifthPuzzle : iPuzzle
    {
        FileParser parser = new FileParser();
        string filepath = @"E:\Projects\AdventOfCode\AdventOfCode\Puzzles\puzzle5.txt";
        string parsedString;

        public FifthPuzzle()
        {
            parsedString = parser.ObtainString(filepath);
        }

        public string Answer()
        {
            string units = string.Empty;
            for (int i = 0; i < parsedString.Length; i++)
            {
                if (units.Length == 0)
                    units += parsedString[i];
                else if (!units[units.Length - 1].Equals(parsedString[i])
                    && (char.ToLower(units[units.Length - 1]).Equals(parsedString[i])
                    || char.ToUpper(units[units.Length - 1]).Equals(parsedString[i])))
                    units = units.Remove(units.Length - 1);
                else
                    units += parsedString[i];
            }
            return "Answer 1 is: " + units.Length.ToString() + Answer2(units);
        }

        public string Answer2(string reactedUnits)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Dictionary<char, int> sizeChart = new Dictionary<char, int>();
            foreach(char letter in alphabet)
            {
                string tempUnits = reactedUnits.Replace(letter.ToString(), string.Empty).Replace(letter.ToString().ToLower(), string.Empty);

                string units = string.Empty;
                for (int i = 0; i < tempUnits.Length; i++)
                {
                    if (units.Length == 0)
                        units += tempUnits[i];
                    else if (!units[units.Length - 1].Equals(tempUnits[i])
                        && (char.ToLower(units[units.Length - 1]).Equals(tempUnits[i])
                        || char.ToUpper(units[units.Length - 1]).Equals(tempUnits[i])))
                        units = units.Remove(units.Length - 1);
                    else
                        units += tempUnits[i];
                }
                sizeChart.Add(letter, units.Count());
            }
            char selectedLetter = sizeChart.OrderBy(l => l.Value).First().Key;
            return "\nAnswer 2 is: " + sizeChart[selectedLetter].ToString();
        }
    }
}
