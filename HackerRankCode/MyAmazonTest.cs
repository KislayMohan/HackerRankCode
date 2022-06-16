using System;
using System.Collections.Generic;

namespace HackerRankCode
{
    public static class MyAmazonTest
    {
        public static void CountDecreasingRatingsSol()
        {
            var ratings = new List<int> { 4, 3, 5, 4, 3 };
            var cnt = CountDecreasingRatings(ratings);
            Console.WriteLine(cnt);
        }

        private static long CountDecreasingRatings(List<int> ratings)
        {
            if (ratings == null || ratings.Count == 0)
            {
                return 0;
            }
            int[] tempRatings = new int[ratings.Count];
            tempRatings[0] = 1;
            for (int i = 1; i < ratings.Count; i++)
            {
                if (ratings[i] == ratings[i - 1] - 1)
                {
                    tempRatings[i] = tempRatings[i - 1] + 1;
                }
                else
                {
                    tempRatings[i] = 1;
                }
            }

            int result = 0;
            foreach (var item in tempRatings)
            {
                result += item;
            }
            return result;
        }

        private static long CountDecreasingRatings1(List<int> ratings)
        {
            var cnt = 0;
            if (ratings.Count <= 1)
            {
                Console.WriteLine(ratings.Count);
                return ratings.Count;
            }
            var groupCount = ratings.Count;
            int leftLen = groupCount, start = 0;
            var subs = new List<List<int>>();
            for (int i = 0; i < groupCount; i++)
            {
                if (i == groupCount - 1 || ratings[i] - ratings[i + 1] != 1)
                {
                    var subList = ratings.GetRange(start, i - start + 1);
                    subs.Add(subList);
                    start = i + 1;
                }
            }

            var tempRatings = new int[groupCount + 1];
            tempRatings[1] = 1;
            tempRatings[2] = 3;

            for (int j = 0; j < subs.Count; j++)
            {
                var current = subs[j];
                leftLen -= current.Count;
                if (tempRatings[current.Count] != 0)
                {
                    cnt += tempRatings[current.Count];
                }
                else
                {
                    var k = 3;
                    for (; k <= current.Count; k++)
                    {
                        tempRatings[k] = tempRatings[k - 1] + k;
                    }
                    cnt += tempRatings[k - 1];
                }
            }

            return cnt;
        }

        public static void MinimumMoves()
        {
            var arr = new List<int> { 0, 1, 0, 1, 1, 1 };
            var zeroAtLeftCount = ArrangeZeroAtLeft(arr);
            var oneAtLeftCount = ArrangeOneAtLeft(arr);
            var minCount = Math.Min(zeroAtLeftCount, oneAtLeftCount);
            Console.WriteLine(minCount);
        }

        private static int ArrangeZeroAtLeft(List<int> arr)
        {
            var count = 0;
            var incorrectZero = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] == 1)
                {
                    incorrectZero++;
                }
                else
                {
                    count += incorrectZero;
                }
            }
            return count;
        }

        private static int ArrangeOneAtLeft(List<int> arr)
        {
            var count = 0;
            var incorrectOne = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] == 0)
                {
                    incorrectOne++;
                }
                else
                {
                    count += incorrectOne;
                }
            }
            return count;
        }
    }
}
