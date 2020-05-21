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
                if (k % 5 == 0)
                {
                    result.Append(k % 15 == 0 ? RED : YELLOW);
                }
            }

            var valueCheck = result.ToString().PadRight(11, ORANGE);
            return valueCheck;

        }
    }
}
