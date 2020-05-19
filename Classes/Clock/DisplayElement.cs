using BerlinClock.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Clock
{
    public abstract class ClockDisplayElement : ILampDisplayRow
    {
        public const string ZeroMinutes = "";
        public const string SecondsLt5 = "";
        public const string Minutes = "";
        

        public int Value { get; set; }

        public abstract string GetLampDisplay();

        public override string ToString()
        {
            return GetLampDisplay();
        }
    }
}
