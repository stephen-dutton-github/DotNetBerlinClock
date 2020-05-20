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

            var result = new StringBuilder();

            for (var k = 1; k <= Value; k++)
            {
                var lamp = k % 5 == 0 ? "R" : String.Empty; 
                result.Append(lamp);
            }

            return result.ToString().PadRight(4, 'O');

        }
    }
}
