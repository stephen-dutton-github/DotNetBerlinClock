using BerlinClock.Classes.Clock;
using BerlinClock.Interfaces;
using System    ;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace BerlinClock.Classes
{

    public class TimeConverter : ITimeConverter
    {

        private MainClockGroupDisplay Clock { get; set; } = new MainClockGroupDisplay();

        /// <summary>
        /// Default Implementation of ITimeConverter
        /// </summary>
        /// <param name="aTime"></param>
        /// <returns></returns>
        public string ConvertTime(string aTime)
        {
            Clock.SetTime(aTime);
            var result = Clock.ToString();
            return result;
        }

     
    }
}
