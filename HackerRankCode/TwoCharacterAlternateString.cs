using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class TwoCharacterAlternateString
    {
        public static void TwoCharacterAlternateStringSol()
        {
            string s = Console.ReadLine();
            int result = AlternateCharString(s);
            Console.WriteLine(result);
        }

        private static int AlternateCharString(string? s)
        {
            int maxLength = 0;
            for (int i = 0; i < 26; i++)
            {
                for (int j = i + 1; j < 26; j++)
                {
                    char c1 = (char)('a' + i);
                    char c2 = (char)('a' + j);

                    string t = "";
                    for (int k = 0; k < s.Length; k++)
                    {
                        if (s[k] == c1 || s[k] == c2)
                        {
                            t += s[k];
                        }
                    }

                    bool valid = true;
                    for (int k = 1; k < t.Length; k++)
                    {
                        if (t[k] == t[k - 1])
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (valid)
                    {
                        maxLength = Math.Max(maxLength, t.Length);
                    }
                }
            }

            return maxLength;
        }
    }
}
