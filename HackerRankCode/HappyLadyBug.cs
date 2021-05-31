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
            var previousHappy = false;
            var colourChange = false;
            for (int i = 0; i < b.Length; i++)
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
                    if (b[i] == b[i - 1])
                    {
                        previousHappy = true;
                        colourChange = false;
                        continue;
                    }
                    else
                    {
                        colourChange = true;
                    }

                    if (!previousHappy && colourChange)
                    {
                        fullHappy = false;
                    }
                }
            }

            if (fullHappy)
            {
                fullHappy = !colourChange;
            }

            if (!colourColl.ContainsKey('_')) // No empty space
            {
                if (fullHappy)
                {
                    return "YES";
                }
                return "NO";
            }

            foreach (var item in colourColl)
            {
                if (item.Key != '_' && item.Value == 1)
                {
                    return "NO";
                }

            }
            return "YES";
        }
    }
}
