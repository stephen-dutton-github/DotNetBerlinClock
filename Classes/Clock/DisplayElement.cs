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
    /// <summary>
    /// Abstracted Template behavior for the Clock sections or "Display Elements"
    /// </summary>
    public abstract class ClockDisplayElement : ILampDisplayRow
    {
        /// <summary>
        /// Public "Zero" optimized states
        /// </summary>
        public const string ZeroMinutesMaj = "OOOOOOOOOOO";
        public const string ZeroMinutesMin = "OOOO";
        public const string ZeroHours = "OOOO";


        /// <summary>
        /// Generalised value 
        /// </summary>
        public long Value { get; set; }


        /// <summary>
        /// Provide polymorphic 
        /// </summary>
        /// <returns></returns>
        public abstract string GetLampDisplay();

        /// <summary>
        /// Override ToString for simplified direct "print to test" behavior
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return GetLampDisplay();
        }
    }
}
