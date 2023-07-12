using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class RazerTest
    {
        public static void PairSumSol()
        {
            int[] arr = { 1, 1, 5, 3, 4, 2 };
            int n = arr.Length;
            int k = 3;

            Console.WriteLine("Count of pairs with"
                              + " given diff is "
                              + CountPairsWithDiffK(arr, n, k));
        }

        private static int CountPairsWithDiffK(int[] arr, int n, int k)
        {
            var count = 0;
            var distinctArr = arr.Distinct();
            var pairDict = new Dictionary<int, int>();
            foreach (var pair in distinctArr)
            {
                if (pairDict.ContainsKey(pair + k) || pairDict.ContainsKey(pair - k))
                {
                    count++;
                }
                else
                {
                    pairDict.Add(pair, pair);
                }
            }

            return count;
        }

        public class MeetingPair : IComparable<MeetingPair>
        {
            public int StartDay { get; set; }
            public int EndDay { get; set; }
            public MeetingPair(int startDay, int endDay)
            {
                StartDay = startDay;
                EndDay = endDay;
            }

            public int CompareTo(MeetingPair? other)
            {
                if (this.EndDay < other.EndDay)
                {
                    return -1;
                }
                else if (this.EndDay > other.EndDay)
                    return 1;

                return 0;
            }
        }

        public static void MeetupSchedule()
        {
            var start = Console.ReadLine().Split(' ').Select(a => Convert.ToInt32(a)).ToList();

            var finish = Console.ReadLine().Split(' ').Select(a => Convert.ToInt32(a)).ToList();

            int N = start.Count;

            var count = MaxMeetings(start, finish, N);
            Console.WriteLine(count);
        }

        private static int MaxMeetings(List<int> start, List<int> finish, int n)
        {
            var meetingPairList = new List<MeetingPair>();
            for (int i = 0; i < n; i++)
            {
                var meetingPair = new MeetingPair(start[i], finish[i]);
                meetingPairList.Add(meetingPair);
            }
            meetingPairList.Sort();

            var count = 1;
            /*var daysSpent = meetingPairList[0].EndDay;
            for (int i = 1; i < n; i++)
            {
                if (meetingPairList[i].StartDay >= daysSpent)
                {
                    count++;
                    daysSpent = meetingPairList[i].EndDay;
                }
            }*/
            var daysSpent = meetingPairList[0].StartDay + 1;
            for (int i = 1; i < n; i++)
            {
                if (meetingPairList[i].EndDay >= daysSpent)
                {
                    count++;
                    daysSpent++;
                }
            }
            return count;
        }

        private static List<string> NearestCity(List<string> Points, List<int> XCoord, List<int> YCoord, List<string> QueryPoint) 
        {
            var pointsDict = new Dictionary<string, Tuple<int, int>>();
            var xCoorDict=new Dictionary<int, SortedList<string, string>>();
            var yCoorDict = new Dictionary<int, SortedList<string, string>>();
            var sortedList = new SortedList<string, string>();

            for (int i = 0; i < Points.Count; i++)
            {
                if (!pointsDict.ContainsKey(Points[i]))
                {
                    pointsDict.Add(Points[i], new Tuple<int, int>(XCoord[i], YCoord[i]));
                }

                if (xCoorDict.ContainsKey(XCoord[i]))
                {
                    xCoorDict[XCoord[i]].Add(Points[i], Points[i]);
                }
                else
                {
                    sortedList = new SortedList<string, string>();
                    sortedList.Add(Points[i], Points[i]);
                    xCoorDict.Add(XCoord[i], sortedList);
                }

                if (yCoorDict.ContainsKey(YCoord[i]))
                {
                    yCoorDict[YCoord[i]].Add(Points[i], Points[i]);
                }
                else
                {
                    sortedList = new SortedList<string, string>();
                    sortedList.Add(Points[i], Points[i]);
                    yCoorDict.Add(YCoord[i], sortedList);
                }
            }
            var result=new List<string>();
            for (int i = 0; i < QueryPoint.Count; i++)
            {
                var queryCoord = pointsDict[QueryPoint[i]];
                var nearest = string.Empty;
                if (xCoorDict.ContainsKey(queryCoord.Item1))
                {
                    var points = xCoorDict[queryCoord.Item1];
                    foreach (var item in points)
                    {
                        if (item.Key == QueryPoint[i])
                        {
                            continue;
                        }
                        nearest = item.Key;
                        break;
                    }
                }
                if (yCoorDict.ContainsKey(queryCoord.Item2))
                {
                    var points = yCoorDict[queryCoord.Item2];
                    foreach (var item in points)
                    {
                        if (item.Key == QueryPoint[i])
                        {
                            continue;
                        }
                        if (string.IsNullOrEmpty(nearest) || string.Compare(nearest, QueryPoint[i]) == 1)
                        {
                            nearest = item.Key;
                        }
                        break;
                    }
                }
                if (nearest == string.Empty)
                {
                    nearest = "NONE";
                }
                result.Add(nearest);
            }
            return result;
        }
    }
}
