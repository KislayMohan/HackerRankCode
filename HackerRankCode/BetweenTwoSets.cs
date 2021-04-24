using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class BetweenTwoSets
    {
        public static void GetTotalXFlow()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int m = Convert.ToInt32(firstMultipleInput[1]);
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();
            int total = getTotalX(arr, brr);
            Console.WriteLine(total);
        }

        private static int getTotalX(List<int> a, List<int> b)
        {
            var result = 0;
            var lcm = FindLCM(a);
            var hcf = FindGCD(b);
            for (int i = lcm; i <= hcf; i+=lcm)
            {
                if (hcf % i == 0)
                {
                    result++;
                }
            }
            return result;
        }

        private static int Gcd(int Num1, int Num2)
        {
            if (Num1 == 0)
            {
                return Num2;
            }
            return Gcd(Num2 % Num1, Num1);
        }

        private static int FindGCD(List<int> NumList)
        {
            var result = NumList[0];
            for (int i = 1; i < NumList.Count; i++)
            {
                result = Gcd(NumList[i], result);
                if (result == 1)
                {
                    return result;
                }
            }
            return result;
        }

        private static int FindLCM(List<int> NumList)
        {
            int lcm_of_array_elements = 1;
            int divisor = 2;

            while (true)
            {

                int counter = 0;
                bool divisible = false;
                for (int i = 0; i < NumList.Count; i++)
                {

                    // lcm_of_array_elements (n1, n2, ... 0) = 0.
                    // For negative number we convert into
                    // positive and calculate lcm_of_array_elements.
                    if (NumList[i] == 0)
                    {
                        return 0;
                    }
                    else if (NumList[i] < 0)
                    {
                        NumList[i] = NumList[i] * (-1);
                    }
                    if (NumList[i] == 1)
                    {
                        counter++;
                    }

                    // Divide NumList by devisor if complete
                    // division i.e. without remainder then replace
                    // number with quotient; used for find next factor
                    if (NumList[i] % divisor == 0)
                    {
                        divisible = true;
                        NumList[i] = NumList[i] / divisor;
                    }
                }

                // If divisor able to completely divide any number
                // from array multiply with lcm_of_array_elements
                // and store into lcm_of_array_elements and continue
                // to same divisor for next factor finding.
                // else increment divisor
                if (divisible)
                {
                    lcm_of_array_elements = lcm_of_array_elements * divisor;
                }
                else
                {
                    divisor++;
                }

                // Check if all NumList is 1 indicate
                // we found all factors and terminate while loop.
                if (counter == NumList.Count)
                {
                    return lcm_of_array_elements;
                }
            }
        }
    }
}
