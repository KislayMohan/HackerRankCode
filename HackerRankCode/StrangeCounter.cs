using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class StrangeCounter
    {
        public static void StrangeCounterFlow()
        {
            long t = Convert.ToInt64(Console.ReadLine().Trim());
            long result = StrangeCounterSolve(t);
            Console.WriteLine(result);
        }

        /// <summary>
        /// Observe first time and first value in earc series. There's a pattern.
        /// First time=1, First Value = 3. Sum=4
        /// Second time=4, Second Value = 6, Sum = 10. Formula for Time: (previous time + previous value => 1 + 3), Formula for Sum: (Previous sum *2 + 2 => 4 * 2 + 2)
        /// Third time= 10, Third Value = 12, Sum = 22 . Formula for Time: (previous time + previous value => 4 + 6), Formula for Sum: (Previous sum *2 + 2 => 10 * 2 + 2)
        /// Use this formulat to get first value and time of next series until its time doesn't exceed t. Then, its mere suntraction.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private static long StrangeCounterSolve(long t)
        {
            long currentTime = 1;
            long currentValue = 3;

            while (currentTime + currentValue <= t)
            {
                var nextTime = currentTime + currentValue;
                currentValue = (currentTime + currentValue) * 2 + 2 - nextTime;
                currentTime = nextTime;
            }

            currentValue -= t - currentTime;

            return currentValue;
        }
    }
}
