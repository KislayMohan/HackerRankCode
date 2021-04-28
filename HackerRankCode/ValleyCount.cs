using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class ValleyCount
    {
        public static void ValleyCountFlow()
        {
            int steps = Convert.ToInt32(Console.ReadLine().Trim());
            string path = Console.ReadLine();
            int result = CountingValleys(steps, path);
            Console.WriteLine(result);
        }

        private static int CountingValleys(int steps, string path)
        {
            var valleyCount = 0;
            var level = 0;
            for (int i = 0; i < steps; i++)
            {
                if (path[i] == 'D')
                {
                    level--;
                }
                else if (path[i] == 'U')
                {
                    level++;
                }
                if (level==0 && path[i] == 'U')
                {
                    valleyCount++;
                }
            }

            return valleyCount;
        }
    }
}
