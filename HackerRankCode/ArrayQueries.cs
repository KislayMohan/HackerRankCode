using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class ArrayQueries
    {
        public static void ArrayQuerySol()
        {
            var inputData = Console.ReadLine().Split(' ');
            var numCount = Convert.ToInt32(inputData[0]);
            var queryCount = Convert.ToInt32(inputData[1]);
            var numList = Array.ConvertAll(Console.ReadLine().Split(' '), a => Convert.ToInt32(a)).Take(numCount).ToList();

            for (int i = 0; i < queryCount; i++)
            {
                var query = Console.ReadLine().Split(' ');
                var startIndex = Convert.ToInt32(query[1]);
                var endIndex = Convert.ToInt32(query[2]);
                var counter = 0;
                var dataQueue = new Queue<int>();
                switch (query[0])
                {
                    case "1":
                        counter = startIndex - 2;
                        for (int j = endIndex - 1; j >= 0; j--)
                        {
                            if (counter >= 0)
                            {
                                dataQueue.Enqueue(numList[j]);
                                numList[j] = numList[counter--];
                            }
                            else if (j > startIndex - 2)
                            {
                                dataQueue.Enqueue(numList[j]);
                                numList[j] = dataQueue.Dequeue();
                            }
                            else if(dataQueue.Count > 0)
                            {
                                numList[j] = dataQueue.Dequeue();
                            }
                        }
                        break;

                    case "2":
                        counter = endIndex;
                        for (int j = startIndex - 1; j < numList.Count; j++)
                        {
                            if (counter < numList.Count)
                            {
                                dataQueue.Enqueue(numList[j]);
                                numList[j] = numList[counter++];
                            }
                            else if (j > endIndex)
                            {
                                dataQueue.Enqueue(numList[j]);
                                numList[j] = dataQueue.Dequeue();
                            }
                            else if (dataQueue.Count > 0)
                            {
                                numList[j] = dataQueue.Dequeue();
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(Math.Abs(numList[0] - numList[numList.Count - 1]));
            Console.WriteLine(string.Join(" ", numList));
        }
    }
}
