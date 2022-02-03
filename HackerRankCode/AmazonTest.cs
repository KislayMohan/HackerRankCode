using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankCode
{
    public class AmazonTest
    {
        public static void AmazonTestFlow()
        {
            var transactions = new List<string> { "notebook", "mouse", "keyboard", "notebook", "mouse" };
            var groupTransaction = transactions.GroupBy(t => t)
                .OrderByDescending(n => n.Count())
                .ThenBy(n => n.Key)
                .Select(n => n.Key + " " + n.Count()).ToList();
        }

        public static void Meeting()
        {
            //var arrival = new List<int> { 3, 1, 5 };
            //var duration = new List<int> { 2, 1, 2 };

            var arrival = new List<int> { 1, 3, 3,5, 7 };
            var duration = new List<int> { 2, 2, 1, 2, 1 };
            
            var events = new List<Event>();
            for (int i = 0; i < arrival.Count(); i++)
            {
                events.Add(new Event (arrival[i], duration[i]));
            }
            events.Sort();

            //int currPos = 0, timeSpent = 0, meetingCount = 0;
            //for (int i = 0; i < arrival.Count(); i++)
            //{
            //    timeSpent = arrival[i] + duration[i];
            //    var innerMax = 0;
            //    while (i + currPos + 1  < arrival.Count() && arrival[i + currPos + 1] <= timeSpent)
            //    {
            //        if (innerMax < duration[i + currPos + 1])
            //        {
            //            innerMax = duration[i + currPos + 1];
            //        }
            //        currPos++;
            //    }
            //    if (currPos > 1)
            //    {
            //        i += currPos;
            //        meetingCount++;
            //    }
            //    currPos = 0;
            //    meetingCount++;
            //}


            int currPos = 0, timeSpent = 0, meetingCount = 0;
            for (int i = 0; i < arrival.Count(); i++)
            {
                timeSpent = events[i].Arrival + events[i].Duration;
                var innerMax = 0;
                while (i + currPos + 1 < arrival.Count() && events[i + currPos + 1].Arrival <= timeSpent)
                {
                    if (innerMax < events[i + currPos + 1].Duration)
                    {
                        innerMax = events[i + currPos + 1].Duration;
                    }
                    currPos++;
                }
                if (currPos > 1)
                {
                    i += currPos;
                    meetingCount++;
                }
                currPos = 0;
                meetingCount++;
            }

            Console.WriteLine(meetingCount);
        }

        public class Event : IComparable<Event>
        {
            public int Arrival { get; set; }
            public int Duration { get; set; }

            public Event(int start, int end)
            {
                this.Arrival = start;
                this.Duration = end;
            }

            public int CompareTo(Event other)
            {
                if (this.Arrival < other.Arrival)
                {
                    return -1;
                }
                else if (this.Arrival > other.Arrival)
                    return 1;

                return 0;
            }
        }
    }
}
