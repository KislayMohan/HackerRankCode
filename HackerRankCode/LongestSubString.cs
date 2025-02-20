using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class LongestSubString
    {
        public int LengthOfLongestSubstring(string s)
        {
            var longestStrLen = 0;
            var tempCount = 0;
            var lookUp = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (lookUp.ContainsKey(s[i]))
                {
                    if (tempCount > longestStrLen)
                    {
                        longestStrLen = tempCount;
                    }
                    tempCount = 0;
                    i = lookUp[s[i]];
                    lookUp.Clear();
                }
                else
                {
                    lookUp[s[i]] = i;
                    tempCount++;
                }
            }
            if (tempCount > longestStrLen)
            {
                longestStrLen = tempCount;
            }

            return longestStrLen;
        }
    }
}
