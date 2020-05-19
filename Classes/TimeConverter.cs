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

        

        /// <summary>
        /// Default Implementation of ITimeConverter
        /// </summary>
        /// <param name="aTime"></param>
        /// <returns></returns>
        public string ConvertTime(string aTime)
        {
            var result = string.Empty;
            try
            {
                //var time = new (aTime, this);
                //result  = time.ToString();
            }
            catch (FormatException fex)
            {
                result += $"Error:{fex.Message}";
            }
            finally
            {
                result += "\n";
            }

            return result;
        }

     
    }
}
