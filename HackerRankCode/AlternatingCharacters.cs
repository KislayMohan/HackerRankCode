using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class AlternatingCharacters
    {
        public static void AlternatingCharactersSol()
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());
            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();
                int result = AlternatingCharacter(s);
                Console.WriteLine(result);
            }
        }

        private static int AlternatingCharacter(string s)
        {
            var deletionCount = 0;
            var innerDeletionCount = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i-1])
                {
                    innerDeletionCount++;
                }
                else
                {
                    deletionCount += innerDeletionCount;
                    innerDeletionCount = 0;
                }
            }
            deletionCount += innerDeletionCount;
            return deletionCount;
        }
    }
}
