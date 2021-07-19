using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class ArrayPairs
    {
        public static void ArrayPairsInput()
        {
            int arrCount = Convert.ToInt32(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            long result = solve(arr.ToList());
            Console.WriteLine(result);
        }

        private static long Solve_Old(int[] arr)
        {
            long pairCount = 0;
            for (int i = 0; i < arr.Count() - 1; ++i)
            {
                int max = arr[i];
                for (int j = i + 1; j < arr.Count(); ++j)
                {
                    if (arr[j] > max)
                    {
                        max = arr[j];
                    }
                    if ((long)arr[i] * (long)arr[j] <= max)
                    {
                        ++pairCount;
                    }
                }
            }
            return pairCount;
        }

        private static long SolveNew(List<int> arr)
        {
            long pairCount = 0;
            var leftSubArray = new List<int>();
            var rightSubArray = new List<int>();
            var holder = new List<Tuple<int, int>>();
            for (int i = 0; i < arr.Count; i++)
            {
                while (holder.Count > 0 && holder.Last().Item1 < arr[i])
                {
                    holder.RemoveAt(holder.Count - 1);
                }
                if (holder.Count == 0)
                {
                    leftSubArray[i] = 0;
                }
                else
                {
                    leftSubArray[i] = holder.Last().Item2 + 1;
                }
                holder.Add(new Tuple<int, int>(arr[i], i));
            }
            holder.Clear();
            for (int i = arr.Count - 1; i > 0; i--)
            {
                while (holder.Count > 0 && holder.Last().Item1 <= arr[i])
                {
                    holder.RemoveAt(holder.Count - 1);
                }
                if (holder.Count == 0)
                {
                    rightSubArray[i] = arr.Count - 1;
                }
                else
                {
                    rightSubArray[i] = holder.Last().Item2 - 1;
                }
                holder.Add(new Tuple<int, int>(arr[i], i));
            }
            return pairCount;
        }

        private static long solve(List<int> arr)
        {
            var len = arr.Count;
            var max = -1;
            if (len == 1 || len == 0)
            {
                return 0;
            }
            else if (len == 2)
            {
                max = arr[0];
                if (max < arr[1])
                {
                    max = arr[1];
                }
                if ((long)arr[0] * (long)arr[1] <= max)
                {
                    return 1;
                }
                return 0;
            }
            long pairCount = 0;
            var maxIndex = -1;
            for (int i = 0; i < len; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }
            var leftSubArray = arr.Take(maxIndex).ToList();
            var rightSubArray = arr.Skip(maxIndex + 1).ToList();
            var leftSubArraySorted = leftSubArray.OrderBy(a => a).ToList();
            var rightSubArraySorted = rightSubArray.OrderBy(a => a).ToList();
            for (int i = 0; i < leftSubArraySorted.Count; i++)
            {
                var tempPairCount = pairCount;
                for (int j = 0; j < rightSubArraySorted.Count; j++)
                {
                    if ((long)leftSubArraySorted[i] * (long)rightSubArraySorted[j] <= max)
                    {
                        pairCount++;
                    }
                    if (max * (long)rightSubArraySorted[j] <= max)
                    {
                        pairCount++;
                    }
                    if (tempPairCount == pairCount)
                    {
                        break;
                    }
                }
                if (max * (long)leftSubArraySorted[i] <= max)
                {
                    pairCount++;
                }
                if (tempPairCount == pairCount)
                {
                    break;
                }
            }

            pairCount += solve(leftSubArray);
            pairCount += solve(rightSubArray);

            return pairCount;
        }

        private static long solve_1(int[] arr)
        {
            var len = arr.Length;
            var max = -1;
            if (len == 1 || len == 0)
            {
                return 0;
            }
            else if (len == 2)
            {
                max = arr[0];
                if (max < arr[1])
                {
                    max = arr[1];
                }
                if ((long)arr[0] * (long)arr[1] <= max)
                {
                    return 1;
                }
                return 0;
            }
            long pairCount = 0;

            var maxIndex = -1;
            for (int i = 0; i < len; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }
            var navigate = len - 1 - maxIndex > maxIndex ? len - 1 - maxIndex : maxIndex;
            var countOfOneside1 = 0;
            var countOfOneside2 = 0;
            for (int j = 1; j <= navigate; j++)
            {
                if (maxIndex - j >= 0 && arr[maxIndex - j] == 1)
                {
                    pairCount += len - maxIndex;
                    countOfOneside1++;
                }

                if (maxIndex + j < len && arr[maxIndex + j] == 1)
                {
                    pairCount += maxIndex + 1;
                    countOfOneside2++;
                }

                if (navigate == maxIndex)
                {
                    for (int k = maxIndex + 1; k < len && arr[k] != 1 && arr[maxIndex - j] != 1; k++)
                    {
                        if ((long)arr[maxIndex - j] * (long)arr[k] <= max)
                        {
                            pairCount++;
                        }
                    }
                }
                else
                {
                    for (int k = 0; k < maxIndex && arr[k] != 1 && arr[maxIndex + j] != 1; k++)
                    {
                        if ((long)arr[maxIndex + j] * (long)arr[k] <= max)
                        {
                            pairCount++;
                        }
                    }
                }
            }
            pairCount -= countOfOneside1 * countOfOneside2;
            pairCount += solve_1(arr.Take(maxIndex).ToArray());
            pairCount += solve_1(arr.Skip(maxIndex + 1).ToArray());

            return pairCount;
        }
    }
}
