using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class PalindromicSubstring
    {
        public static string LargestPalindromicSubstring(string str)
        {
            var palindromeStr = string.Empty;

            bool[,] visit = new bool[str.Length, str.Length];

            int maxLength = 1;
            for (int i = 0; i < str.Length; ++i)
                visit[i, i] = true;

            int start = 0;

            for (int i = 0; i < str.Length - 1; ++i)
            {
                if (str[i] == str[i + 1])
                {
                    visit[i, i + 1] = true;
                    start = i;
                    maxLength = 2;
                }
            }

            for (int k = 3; k <= str.Length; ++k)
            {
                for (int i = 0; i < str.Length - k + 1; ++i)
                {
                    int j = i + k - 1;
                    if (visit[i + 1, j - 1] && str[i] == str[j])
                    {
                        visit[i, j] = true;
                        if (k > maxLength)
                        {
                            start = i;
                            maxLength = k;
                        }
                    }
                }
            }
            if (start == 0 && maxLength == 1)
            {
                palindromeStr = "none";
            }
            else
            {
                palindromeStr = str.Substring(start, maxLength);
            }
            Console.Write("Longest palindrome substring is: {0}", palindromeStr);

            palindromeStr += "350ygqomb9c";
            var finalStr = new StringBuilder();
            int counter = 0;
            while (counter + 3 < palindromeStr.Length)
            {
                finalStr.Append(palindromeStr.Substring(counter, 3)).Append("_");
                counter += 4;
            }
            finalStr.Append(palindromeStr.Substring(counter, palindromeStr.Length - counter));
            Console.WriteLine("Final string: {0}", finalStr.ToString());

            return finalStr.ToString();
        }

        public static string LargestFour(int[] arr )
        {
            var sum = arr.OrderByDescending(a => a).Take(4).Sum();
            var str = sum.ToString() + "350ygqomb9c";
            var finalStr = new StringBuilder();
            int counter = 0;
            while (counter + 3 < str.Length)
            {
                finalStr.Append(str.Substring(counter, 3)).Append("_");
                counter += 4;
            }
            finalStr.Append(str.Substring(counter, str.Length - counter));
            Console.WriteLine("Final string: {0}", finalStr.ToString());

            return finalStr.ToString();
        }
    }
}
