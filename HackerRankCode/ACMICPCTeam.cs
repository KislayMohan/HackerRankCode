using System;
using System.Collections.Generic;

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
            int maxTopicCount = 0, maxTeamCount = 0;
            var topicCount = topic[0].Length;
            for (int i = 0; i < topic.Count - 1; i++)
            {
                for (int j =  i + 1; j < topic.Count; j++)
                {
                    var tempTopicMax = 0;
                    for (int k = 0; k < topicCount; k++)
                    {
                        if (topic[i][k] == '1' || topic[j][k] == '1')
                        {
                            tempTopicMax++;
                        }
                    }
                    if (maxTopicCount < tempTopicMax)
                    {
                        maxTopicCount = tempTopicMax;
                        maxTeamCount = 1;
                    }
                    else if(maxTopicCount == tempTopicMax)
                    {
                        maxTeamCount++;
                    }
                }
            }
            result.Add(maxTopicCount);
            result.Add(maxTeamCount);
            return result;
        }
    }
}
