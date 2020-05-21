using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Clock
{
    public class HourAccumulatorMinor : ClockDisplayElement
    {
        public override string GetLampDisplay()
        {
            if (Value < 1)
                return ZeroHours;

            var result = new StringBuilder();

            var activeLamps = Value < 5 ? Value : Value % 5;

            for (var k = 0; k < activeLamps; k++)
                result.Append("R");


            return result.ToString().PadRight(4, 'O');
        }
    }
}
