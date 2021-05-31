using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class HappyLadyBug
    {
        public static void HappyLadyBugFlow()
        {
            int g = Convert.ToInt32(Console.ReadLine().Trim());
            for (int gItr = 0; gItr < g; gItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());
                string b = Console.ReadLine();
                string result = HappyLadybugs(b);
                Console.WriteLine(result);
            }
        }

        private static string HappyLadybugs(string b)
        {
            var fullHappy = true;
            var colourColl = new Dictionary<char, int>();
            int i = 0;
            for (; i < b.Length; i++)
            {
                if (!colourColl.ContainsKey(b[i]))
                {
                    colourColl[b[i]] = 1;
                }
                else
                {
                    colourColl[b[i]]++;
                }
                if (i >= 1 && fullHappy)
                {
                    if (colourColl[b[i - 1]] == 1)
                    {
                        fullHappy = false;
                    }
                }
            }
            if (fullHappy)
            {
                fullHappy = colourColl[b[i - 1]] > 1; // For last element in string if its different from second last.
            }

            if (!colourColl.ContainsKey('_')) // No empty space
            {
                if (fullHappy)
                {
                    return "YES"; // All happy
                }
                return "NO"; // All not happy and no empty space for swap hence not possible
            }

            // Below loop will handle cases with empty spaces.
            foreach (var item in colourColl)
            {
                if (item.Key != '_' && item.Value == 1) // For any string if frequency is 1 then it cannot be happy as cannot pair.
                {
                    return "NO";
                }

            }
            return "YES";
        }
    }
}
