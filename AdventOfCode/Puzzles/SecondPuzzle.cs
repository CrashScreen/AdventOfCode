using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Puzzles
{
    public class SecondPuzzle
    {
        FileParser parser = new FileParser();
        List<string> parsedIDs = new List<string>();
        string filePath = (@"E:\Projects\AdventOfCode\AdventOfCode\Puzzles\puzzle2.txt");

        public SecondPuzzle()
        {
            parsedIDs = parser.ObtainStringList(filePath);
        }

        public string Answer()
        {
            return "First answer: " + CalculateFirstAnswer() + "\nSecond answer is: " + CalculateSecondAnswer();
        }

        public string CalculateFirstAnswer()
        {
            Dictionary<char, int> duplicateChar = new Dictionary<char, int>();

            int doubleCount = 0;
            int trebleCount = 0;

            foreach (string ID in parsedIDs)
            {
                duplicateChar.Clear();
                foreach (char character in ID)
                {
                    if (duplicateChar.ContainsKey(character))
                        duplicateChar[character]++;
                    else 
                        duplicateChar.Add(character, 1);
                }
                if (duplicateChar.Values.Contains(2))
                    doubleCount++;
                if (duplicateChar.Values.Contains(3))
                    trebleCount++;
                //doubleCount += duplicateChar.Where(character => character.Value == 2).Count();
                //trebleCount += duplicateChar.Where(character => character.Value == 3).Count();
            }
            return (doubleCount * trebleCount).ToString();
        }

        public string CalculateSecondAnswer()
        {
            foreach(string ID in parsedIDs)
            {
                foreach(string otherID in parsedIDs)
                {
                    string comparativeString = string.Empty;
                    if (!ID.Equals(otherID))
                    {
                        for(int index = 0; index < ID.Count(); index++)
                        {
                            if (ID[index] == otherID[index])
                                comparativeString += ID[index];
                        }
                    }
                    if (comparativeString.Count() == ID.Count() - 1)
                        return comparativeString;
                }
            }
            return string.Empty;
        }
    }
}
