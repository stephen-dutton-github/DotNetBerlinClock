using BerlinClock.Interfaces;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Management.Instrumentation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.Classes.Clock
{
    public enum ClockSection { 
        Seconds,
        HoursMajor,
        HoursMinor,
        MinutesByFive,
        SecondsByFive
    }

    public class MainClockGroupDisplay : ClockDisplayElement, IFormatProvider
    {

        public SecondIndicator          Secs   { get; set; } = new SecondIndicator();
        public HourAccumulatorMajor     HrsMaj { get; set; } = new HourAccumulatorMajor();
        public HourAccumulatorMinor     HrsMin { get; set; } = new HourAccumulatorMinor();
        public MinuteAccumulatorMajor   MinMaj { get; set; } = new MinuteAccumulatorMajor();
        public MinuteAccumulatorMinor   MinMin { get; set; } = new MinuteAccumulatorMinor();
        public List<ClockDisplayElement>     DisplayElements { get; set; } = new List<ClockDisplayElement>();

        public MainClockGroupDisplay()
        {
            DisplayElements = new ClockDisplayElement[] { Secs, HrsMaj, HrsMin, MinMaj, MinMin }.ToList();
        }

        /// <summary>
        /// IFormatProvider imlementaion 
        /// </summary>
        /// <param name="formatType"></param>
        /// <returns></returns>
        public object GetFormat(Type formatType)
        {
            //ignore formatType we only want the time for this class
            return "HH24:mm:ss";
        }

        /// <summary>
        /// Assignemnt of formatted time to the Display Elements
        /// </summary>
        /// <param name="aTime"></param>
        public void SetTime(DateTime aTime)
        {
            Secs.Value = aTime.Second;
            HrsMaj.Value = HrsMin.Value = aTime.Hour;
            MinMaj.Value = MinMin.Value = aTime.Minute;
        }


        /// <summary>
        /// Public string overload of the SetTime function used to filter,
        /// 
        /// </summary>
        /// <param name="aTime"></param>
        public void SetTime(string aTime)
        {
            var set24Notation = aTime.Trim().EndsWith("24:00:00");
            if (set24Notation)
            {
                aTime = aTime.Replace("24:00:00", "00:00:00");
            }
            var result = DateTime.Parse(aTime, this, System.Globalization.DateTimeStyles.None);
            Value = result.ToFileTime();
            Secs.Value = result.Second;
            HrsMaj.Value = HrsMin.Value = set24Notation ? 24 : result.Hour ;
            MinMaj.Value = MinMin.Value = result.Minute;
        }


        /// <summary>
        /// GetLampDisplay is called implicitly by the ToString method in order to simplify serialization, 
        /// testing and recursion with Clock DiusplayElement object groups
        /// </summary>
        /// <returns></returns>
        public override string GetLampDisplay()                
        {
            //Polymorphic recursion for lamp display behavior.

            var result = String.Join("\r\n", DisplayElements.Select(k => k.GetLampDisplay()).ToArray());
            return result;
        }

        
    }
}
