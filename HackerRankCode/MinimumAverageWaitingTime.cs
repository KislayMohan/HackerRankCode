using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public static class MinimumAverageWaitingTime
    {
        public static void MinimumAverageWaitingTimeSol()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<List<int>> customers = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                customers.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(customersTemp => Convert.ToInt32(customersTemp)).ToList());
            }
            int result = MinimumAverage(customers);

            Console.WriteLine(result);
        }

        private static int MinimumAverage(List<List<int>> customers)
        {
            int totalTime = 0, waitingTime = 0;
            var sortedCustomers = customers.OrderBy(c => c[0]).ToList();
            var heap = new PriorityQueue<int>();
            foreach (var customer in sortedCustomers)
            {
                heap.Enqueue(customer[0], customer[1]);
            }

            return totalTime;
        }
    }
}
