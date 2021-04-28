using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class ClimbingLeaderboard
    {
        public static void ClimbingLeaderboardFlow()
        {
            int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();
            int playerCount = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();
            List<int> result = GetRank1(ranked, player);
            Console.WriteLine(string.Join("\n", result));
        }

        private static List<int> GetRank(List<int> ranked, List<int> player)
        {
            var rankList = new List<int>();
            var rankStack = new Stack<int>();
            
            foreach (var rank in ranked)
            {
                if (rankStack.Count == 0 || rankStack.Peek() != rank)
                {
                    rankStack.Push(rank);
                }
            }

            var tempStack = new Stack<int>();
            foreach (var item in player)
            {
                while (rankStack.Count > 0 || rankStack.Peek() < item)
                {
                    tempStack.Push(rankStack.Pop());
                }
                if (rankStack.Count == 0 || rankStack.Peek() != item)
                {
                    rankStack.Push(item);
                }
                rankList.Add(rankStack.Count);
                while (tempStack.Count > 0)
                {
                    rankStack.Push(tempStack.Pop());
                }
            }
            return rankList;
        }

        private static List<int> GetRank1(List<int> ranked, List<int> player)
        {
            var rankList = new List<int>();
            var distinctRank = new List<int>();
            foreach (var rank in ranked)
            {
                if (distinctRank.Count == 0 || distinctRank[distinctRank.Count - 1] != rank)
                {
                    distinctRank.Add(rank);
                }
            }
            foreach (var item in player)
            {
                var index = Search(distinctRank, item);
                if (index == distinctRank.Count)
                {
                    distinctRank.Insert(index, item);
                    rankList.Add(index + 1);
                }
                else if (distinctRank[index - 1] != item)
                {
                    distinctRank.Insert(index - 1, item);
                    rankList.Add(index);
                }
                else
                {
                    rankList.Add(index);
                }
            }
            return rankList;
        }

        private static int Search(List<int> distinctRank, int item)
        {
            if (distinctRank.Count == 1)
            {
                if (distinctRank[0] == item)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            int mid = distinctRank.Count / 2;
            if (distinctRank[mid - 1] == item)
            {
                return mid;
            }
            else if (distinctRank[mid - 1] < item)
            {
                return Search(distinctRank.Take(mid).ToList(), item);
            }
            else
            {
                return mid + Search(distinctRank.Skip(mid).ToList(), item);
            }
        }
    }
}
