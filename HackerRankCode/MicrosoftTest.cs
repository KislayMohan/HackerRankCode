using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class MicrosoftTest
    {
        public static void ProblemStmnt()
        {
            //var result = Question1("bbbab");
            var N = 4;
            int[] A = new int[5] { 1, 2, 4, 4, 3 };
            int[] B = new int[5] { 2, 3, 1, 3, 1 };
            var result = Question2(N, A, B);
            Console.WriteLine(result);
        }

        private static int Question1(string input)
        {
            var blockCount = new List<int>();
            var maxblock = 1;
            var currBlock = 1;
            for (int i = 1; i <= input.Length; i++)
            {
                if (i < input.Length && input[i] == input[i - 1])
                {
                    currBlock++;
                }
                else
                {
                    if (maxblock < currBlock)
                    {
                        maxblock = currBlock;
                    }
                    blockCount.Add(currBlock);
                    currBlock = 1;
                }
            }

            var count = 0;
            foreach (var item in blockCount)
            {
                count += maxblock - item;
            }

            return count;
        }

        private static bool Question2(int N, int[] A, int[] B)
        {
            var lengthA = A.Length;
            var lengthB = B.Length;
            bool[] visited = new bool[N + 1];
            if (lengthA != lengthB)
            {
                return false;
            }
            for (int i = 0; i < lengthA; i++)
            {
                if (Math.Abs(A[i] - B[i]) != 1)
                {
                    continue;
                }
                visited[A[i]] = true;
                visited[B[i]] = true;
            }
            for (int i = 1; i <= N; i++)
            {
                if (!visited[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static bool Solution(int N, int[] A, int[] B)
        {
            var coordinateColl = new List<Coordinate>();
            var lengthA = A.Length;
            var lengthB = B.Length;
            if (lengthA != lengthB)
            {
                return false;
            }
            for (int i = 0; i < lengthA; i++)
            {
                var coordinate = new Coordinate(A[i], B[i]);
                coordinateColl.Add(coordinate);
            }
            coordinateColl.Sort();

            var index = 1;
            bool useA = true;
            for (int i = 0; i < coordinateColl.Count; i++)
            {
                var coordinate = coordinateColl[i];
                if (i == 0)
                {
                    useA = coordinate.A == index;
                }
                if ((useA && coordinate.A != index) || (!useA && coordinate.B != index))
                {
                    continue;
                }
                else
                {
                    index++;
                }
            }

            return index == N;
        }

        private static int Question3(int[] nums)
        {
            int[] prefixArr = new int[nums.Length + 1];
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int maxKey = 1;

            prefixArr[0] = 0;
            for (int i = 0; i < nums.Length; i++)
                prefixArr[i + 1] = nums[i];

            for (int i = 0; i < nums.Length - 1; i++)
            {
                var sum = nums[i] + nums[i + 1];
                if (prefixArr[i] == nums[i + 1]) continue;
                if (dict.ContainsKey(sum))
                {
                    dict[sum] = dict[sum] + 1;
                    maxKey = Math.Max(dict[sum], maxKey);
                }
                else dict[sum] = 1;

            }
            return maxKey;
        }

        private class Coordinate : IComparable<Coordinate>
        {
            public int A { get; set; }
            public int B { get; set; }

            public Coordinate(int a, int b)
            {
                A = a;
                B = b;
            }

            public int CompareTo(Coordinate other)
            {
                if (this.A < other.A)
                {
                    return -1;
                }
                else if (this.A > other.A)
                    return 1;

                return 0;
            }
        }
    }
}
