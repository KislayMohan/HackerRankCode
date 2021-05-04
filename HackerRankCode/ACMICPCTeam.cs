using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class ACMICPCTeam
    {
        public static void ACMICPCTeamFlow()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int m = Convert.ToInt32(firstMultipleInput[1]);
            List<string> topic = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string topicItem = Console.ReadLine();
                topic.Add(topicItem);
            }
            List<int> result = AcmTeam(topic);
            Console.WriteLine(String.Join("\n", result));
        }

        private static List<int> AcmTeam(List<string> topic)
        {
            var result = new List<int>();
            int maxSubCount = 0, maxTeamCount = 0;
            for (int i = 0; i < topic.Count - 1; i++)
            {
                for (int j =  i + 1; j < topic.Count; j++)
                {

                }
            }
            return result;
        }
    }
}
