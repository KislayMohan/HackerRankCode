using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class TaumAndBirthday
    {
        public static void TaumAndBirthdayFlow()
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());
            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
                int b = Convert.ToInt32(firstMultipleInput[0]);
                int w = Convert.ToInt32(firstMultipleInput[1]);
                string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
                int bc = Convert.ToInt32(secondMultipleInput[0]);
                int wc = Convert.ToInt32(secondMultipleInput[1]);
                int z = Convert.ToInt32(secondMultipleInput[2]);
                long result = TaumBday(b, w, bc, wc, z);
                Console.WriteLine(result);
            }
        }

        private static long TaumBday(int b, int w, int bc, int wc, int z)
        {
            long result = 0;

            //No conversion cost
            result = ((long)b * (long)bc) + ((long)w * (long)wc);
            var blackConversionCost = (((long)w + (long)b) * (long)bc) + ((long)w * (long)z);
            if (result > blackConversionCost)
            {
                result = blackConversionCost;
            }
            var whiteConversionCost = (((long)w + (long)b) * (long)wc) + ((long)b * (long)z);
            if (result > whiteConversionCost)
            {
                result = whiteConversionCost;
            }
            return result;
        }
    }
}
