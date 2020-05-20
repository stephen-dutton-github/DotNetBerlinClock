using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Clock
{
    public class MinuteAccumulatorMajor : ClockDisplayElement
    {
        public override string GetLampDisplay()
        {
            if (Value < 1)
                return ZeroMinutesMaj;

            var result = new StringBuilder();

            for (var k = 1; k <= Value ; k++)
            {
                var lamp = k % 5 == 0 ? "Y"  : String.Empty; //if k mod(5) == 0 Yellow
                    lamp = k % 15 == 0 ? "R" : lamp;         //if k mod(15) == 0 overwrite Red
                result.Append(lamp);
            }

            return result.ToString().PadRight(11, 'O');

        }
    }
}
