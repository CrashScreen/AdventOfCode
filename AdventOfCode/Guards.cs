using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Guards
    {
        public int id;
        int durationAsleep;
        DateTime beginSleep;
        int[] minuteCount = new int[60];

        public DateTime BeginSleep
        {
            set
            {
                beginSleep = value;
            }
        }

        public DateTime EndSleep
        {
            set
            {
                durationAsleep += value.Minute - beginSleep.Minute;
                for(int index = beginSleep.Minute; index < value.Minute; index++)
                {
                    minuteCount[index]++;
                }
            }
        }

        public int Duration
        {
            get
            {
                return durationAsleep;
            }
        }

        public int LongestMinute
        {
            get
            {
                int currentMax = 0;
                int maxIndex = 0;
                for(int index = 0; index < minuteCount.Length; index++)
                {
                    if (minuteCount[index] > currentMax)
                    {
                        currentMax = minuteCount[index];
                        maxIndex = index;
                    }
                }
                return maxIndex;
            }
        }

        public int LongestMinuteLength
        {
            get
            {
                int currentMax = 0;
                int maxIndex = 0;
                for (int index = 0; index < minuteCount.Length; index++)
                {
                    if (minuteCount[index] > currentMax)
                    {
                        currentMax = minuteCount[index];
                        maxIndex = index;
                    }
                }
                return currentMax;
            }
        }

        public Guards(int ID)
        {
            this.id = ID; 
        }
    }
}
