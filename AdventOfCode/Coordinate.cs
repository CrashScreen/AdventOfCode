using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Distance;
        public bool IsInfinte { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
            Distance = 0;
            IsInfinte = false;
        }

        public Coordinate()
        {

        }

        public void IncreaseDistance()
        {
            Distance++;
        }

        public void DeterminedInfinite()
        {
            IsInfinte = true;
        }
    }
}
