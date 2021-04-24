using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class BreakingRecord
    {
        public static void BreakingRecordFlow()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp));
            int[] result = BreakingRecords(scores);
            Console.WriteLine(string.Join(" ", result));
        }

        private static int[] BreakingRecords(int[] scores)
        {
            var maxScore = scores[0];
            var minScore = scores[0];
            int maxScoreCount = 0, minScoreCount = 0;
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > maxScore)
                {
                    maxScoreCount++;
                    maxScore = scores[i];
                }
                else if(scores[i] < minScore)
                {
                    minScoreCount++;
                    minScore = scores[i];
                }
            }
            return new int[2] { maxScoreCount, minScoreCount };
        }
    }
}
