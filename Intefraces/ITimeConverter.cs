using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;


namespace BerlinClock.Interfaces
{
    public interface ITimeConverter
    {
        string ConvertTime(String aTime);
    }
}
