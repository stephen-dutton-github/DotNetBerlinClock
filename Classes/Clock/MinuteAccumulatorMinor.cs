using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BerlinClock.Classes.Clock
{
    public class MinuteAccumulatorMinor : ClockDisplayElement
    {
        public override string GetLampDisplay()
        {
            if (Value < 1)
                return ZeroMinutesMin;

            var result = new StringBuilder();
            
            var activeLamps = Value < 5 ? Value : Value % 5;
            
            for(var k=1; k < activeLamps; k++) result.Append("R");

            return result.ToString().PadRight(4,'O');

        }
    }
}
