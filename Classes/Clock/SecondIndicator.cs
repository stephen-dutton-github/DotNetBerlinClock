using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Clock
{
    public class SecondIndicator : ClockDisplayElement
    {
        public override string GetLampDisplay()
        {
            var result = Value % 2 == 0 ? "Y" : "O";
            return result;
        }
    }
}
