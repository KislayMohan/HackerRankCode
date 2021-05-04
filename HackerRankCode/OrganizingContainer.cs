using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class OrganizingContainer
    {
        public static void OrganizingContainerFlow()
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());
            for (int qItr = 0; qItr < q; qItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());
                List<List<int>> container = new List<List<int>>();
                for (int i = 0; i < n; i++)
                {
                    container.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(containerTemp => Convert.ToInt32(containerTemp)).ToList());
                }
                string result = OrganizingContainers(container);
                Console.WriteLine(result);
            }
        }

        private static string OrganizingContainers(List<List<int>> container)
        {
            var containerCapacityList = new int[container.Count];
            var ballquantityList = new int[container.Count];

            for (int i = 0; i < container.Count; i++)
            {
                for (int j = 0; j < container[i].Count; j++)
                {
                    containerCapacityList[i] += container[i][j];
                    ballquantityList[j] += container[i][j];
                }
            }

            Array.Sort(containerCapacityList);
            Array.Sort(ballquantityList);

            for (int i = 0; i < containerCapacityList.Length; i++)
            {
                if (containerCapacityList[i] != ballquantityList[i])
                {
                    return "Impossible";
                }
            }
            return "Possible";
        }
    }
}
