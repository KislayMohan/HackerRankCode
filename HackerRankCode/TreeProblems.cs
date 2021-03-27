using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class TreeProblems
    {
        public static int GetfirstNumber(int sum)
        {
            int firstNum = 0;
            var quo = sum / 10;
            var remain = sum % 10;
            if (remain != 9)
            {
                var testnum = string.Empty;
                for (int i = 0; i < quo; i++)
                {
                    testnum += "9";
                }
                firstNum = Convert.ToInt32((quo + remain).ToString() + testnum);
            }
            else
            {
                var testnum = string.Empty;
                for (int i = 0; i < quo + 1; i++)
                {
                    testnum += "9";
                }
                firstNum = Convert.ToInt32(quo.ToString() + testnum);
            }
            return firstNum;
        }

        public static int digitSumInverse(int sum, int numberLength)
        {

            int firstMatch = GetfirstNumber(sum);
            int delta = GetNextNumberDelta(sum);
            int count = 0;
            for (int i = firstMatch; i < Convert.ToInt32(Math.Pow(10, numberLength)); i = i + delta)
            {
                count = count + 1;
            }
            return count;

        }

        public static int GetNextNumberDelta(int sum)
        {
            return 9 * (Convert.ToInt32(Math.Pow(10, sum / 9 - 1)));
        }

        public static void DictioanryTest(int[] numList, int k)
        {
            var a = new HashSet<int>(numList);
            Dictionary<int, int> sumDict = new Dictionary<int, int>();
            int count = 0;
            foreach (var item in numList)
            {
                if (item > k)
                {
                    continue;
                }
                var diff = k - item;
                var key = diff;
                var value = item;
                if (item < diff)
                {
                    key = item;
                    value = diff;
                }
                if (!sumDict.ContainsKey(key))
                {
                    //sumDict.Add(key, value);
                    sumDict.Add(key, 1);
                }
                else if(sumDict[key] < 2)
                {
                    sumDict[key]= 2;
                    count = count + 1;
                    Console.WriteLine(string.Format("{0}: {1}",item.ToString(),diff));
                }
            }
            Console.WriteLine(count);
        }
    }
}
