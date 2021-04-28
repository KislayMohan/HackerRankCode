using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class AppendAndDelete
    {
        public static void AppendAndDeleteFlow()
        {
            string s = Console.ReadLine();
            string t = Console.ReadLine();
            int k = Convert.ToInt32(Console.ReadLine().Trim());
            string result = AppendAndDeleteString(s, t, k);
            Console.WriteLine(result);
        }

        private static string AppendAndDeleteString(string s, string t, int k)
        {
            var minLength = s.Length;
            if (t.Length < minLength)
            {
                minLength = t.Length;
            }
            int i = 0;
            for (; i < minLength; i++)
            {
                if (t[i] == s[i])
                {
                    continue;
                }
                break;
            }
            if (s.Length - i + t.Length - i == k)
            {
                return "Yes";
            }
            else if (s.Length + t.Length - 2 * i < k)
            {
                if (k >= s.Length + t.Length)
                {
                    return "Yes";
                }
                var remainingSteps = k - s.Length - t.Length + 2 * i;
                if (remainingSteps % 2 == 0)
                {
                    return "Yes";
                }
                return "No";
            }
            else
            {
                return "No";
            }
        }
    }
}
