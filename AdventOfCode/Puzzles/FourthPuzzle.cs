using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOfCode.Puzzles
{
    public class FourthPuzzle : iPuzzle
    {
        FileParser parser = new FileParser();
        string filepath = @"E:\Projects\AdventOfCode\AdventOfCode\Puzzles\puzzle4.txt";
        Dictionary<DateTime, string> guardLog = new Dictionary<DateTime, string>();

        public FourthPuzzle()
        {
            guardLog = parser.ObtainSleepingPattern(filepath);
        }

        public string Answer()
        {
            return "First Answer: " + FirstAnswer();
        }

        public string FirstAnswer()
        {
            Dictionary<int, Guards> guardList = new Dictionary<int, Guards>();
            Guards currentGuard = null;
            foreach (KeyValuePair<DateTime, string> log in guardLog)
            {
                if (log.Value.Contains("Guard"))
                {
                    int id = Convert.ToInt32(Regex.Match(log.Value, @"\d+").Value);
                    if (!guardList.ContainsKey(id))
                        guardList.Add(id, new Guards(id));
                    currentGuard = guardList[id];
                }
                else if (log.Value.Contains("falls asleep"))
                    currentGuard.BeginSleep = log.Key;
                else if (log.Value.Contains("wakes up"))
                    currentGuard.EndSleep = log.Key;
            }
            KeyValuePair<int,Guards> longestDurationGuard = guardList.OrderByDescending(g => ((Guards)g.Value).LongestMinute).First();
            KeyValuePair<int, Guards> longestMinuteGuard = guardList.OrderByDescending(g => ((Guards)g.Value).LongestMinuteLength).First();
            return (longestDurationGuard.Value.LongestMinute * longestDurationGuard.Value.id).ToString() + 
                "\nSecond Answer: " + (longestMinuteGuard.Value.LongestMinute * longestMinuteGuard.Value.id).ToString();
        }
    }
}
