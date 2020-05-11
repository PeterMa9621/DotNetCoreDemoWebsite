using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Util
{
    public class TimeUtil
    {
        public static long GetTimeStamp(DateTime dateTime)
        {
            return (long) dateTime.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
        }
    }
}
