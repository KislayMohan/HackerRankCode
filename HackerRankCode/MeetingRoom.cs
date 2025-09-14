using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class MeetingRoom
    {
        public static int MinMeetingRooms(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return 0;
            // Create a list of start and end times
            List<int> startTimes = new List<int>();
            List<int> endTimes = new List<int>();
            foreach (var interval in intervals)
            {
                startTimes.Add(interval[0]);
                endTimes.Add(interval[1]);
            }
            // Sort the start and end times
            startTimes.Sort();
            endTimes.Sort();
            int rooms = 0, endIndex = 0;
            for (int i = 0; i < startTimes.Count; i++)
            {
                // If the meeting starts after the last meeting ends, we can reuse a room
                if (startTimes[i] >= endTimes[endIndex])
                {
                    endIndex++;
                }
                else
                {
                    rooms++;
                }
            }
            return rooms;
        }
    }
}
