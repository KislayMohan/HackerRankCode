using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class BiggerIsGreaterString
    {
        public static void BiggerIsGreaterStringFlow()
        {
            int T = Convert.ToInt32(Console.ReadLine().Trim());
            for (int TItr = 0; TItr < T; TItr++)
            {
                string w = Console.ReadLine();
                string result = BiggerIsGreater(w);
                Console.WriteLine(result);
            }
        }

        private static string BiggerIsGreater(string w)
        {
            var result = "no answer";
            char[] chrArr = (w.ToCharArray());
            var byteArr = Encoding.ASCII.GetBytes(w);
            var suffixIndex = -1;
            for (int i = byteArr.Length - 1; i > 0; i--)
            {
                if (byteArr[i - 1] < byteArr[i])
                {
                    suffixIndex = i - 1;
                    break;
                }
            }
            if (suffixIndex == -1)
            {
                return result;
            }
            var smallestSuffix = suffixIndex + 1;
            var suffix = byteArr[suffixIndex];
            for (int i = suffixIndex + 1; i < byteArr.Length; i++)
            {
                if (byteArr[i] > suffix && byteArr[i] <= byteArr[smallestSuffix])
                {
                    smallestSuffix = i;
                }
            }
            Swap(byteArr, suffixIndex, smallestSuffix);
            //Reverse remaining array after suffix
            for (int i = 1; i <= (byteArr.Length - suffixIndex) / 2; i++)
            {
                Swap(byteArr, suffixIndex + i, byteArr.Length - i);
            }
            result = Encoding.ASCII.GetString(byteArr);
            return result;
        }

        private static void Swap(byte[] ByteArr, int index1, int index2)
        {
            var temp1 = ByteArr[index1];
            var temp2 = ByteArr[index2];
            ByteArr[index1] = temp2;
            ByteArr[index2] = temp1;
        }
    }
}
