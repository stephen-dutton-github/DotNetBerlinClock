using BerlinClock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Clock
{
    public class HourAccumulatorMajor : ClockDisplayElement
    {
        public override string GetLampDisplay()
        {
            if (Value < 1)
                return ZeroHours;

            var sb = new StringBuilder();

            for (var k = 1; k <= Value; k++)
            {
                if(k % 5 == 0)
                    sb.Append(RED);
            }
            var result = sb.ToString().PadRight(4, ORANGE);
            return result;

        }
    }
}
