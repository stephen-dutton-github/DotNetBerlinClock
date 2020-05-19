﻿using BerlinClock.Interfaces;
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

    public class ClockModel : ClockDisplayElement, IFormatProvider
    {

        public SecondIndicator          Secs   { get; set; } = new SecondIndicator();
        public HourAccumulatorMajor     HrsMaj { get; set; } = new HourAccumulatorMajor();
        public HourAccumulatorMinor     HrsMin { get; set; } = new HourAccumulatorMinor();
        public MinuteAccumulatorMajor   MinMaj { get; set; } = new MinuteAccumulatorMajor();
        public MinuteAccumulatorMinor   MinMin { get; set; } = new MinuteAccumulatorMinor();
        public List<ClockDisplayElement>     DisplayElements { get; set; } = new List<ClockDisplayElement>();

        public ClockModel()
        {
            DisplayElements = new ClockDisplayElement[] { Secs, HrsMaj, HrsMin, MinMaj, MinMin }.ToList();
        }

        public object GetFormat(Type formatType)
        {
            //ignore formatType we only want the time for this class
            return "HH24:mm:ss";
        }

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
            try
            {
                FormatTime(aTime, this, SetTime);
            }
            catch (Exception ex)
            {
                Assert.Inconclusive("Exception occured..", ex.StackTrace);
            }
            finally
            {
                SetTime(DateTime.Now);
            }
        }

        /// <summary>
        /// Exception generating date fomatter - used above as a trap for exception analysis
        /// delegates to the correct function if all ok
        /// </summary>
        /// <param name="aTime"></param>
        /// <param name="formatProvider"></param>
        /// <param name="slaveFunction"></param>
        private void FormatTime(string aTime, IFormatProvider formatProvider, Action<DateTime> slaveFunction)
        {
            var result = DateTime.Parse(aTime, formatProvider, System.Globalization.DateTimeStyles.None);
            slaveFunction(result);
        }



        public override string GetLampDisplay()                
        {
            var result = new StringBuilder();
            DisplayElements
                    .Select(k => k.GetLampDisplay())
                    .ToList()
                    .ForEach(k => result.AppendLine(k));

            return result.ToString();
        }

        
    }
}