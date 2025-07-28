using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class CourseSchedule
    {
        public static int[] CanFinish(int numCourses, int[][] prerequisites)
        {
            // Create an adjacency list for the graph
            var graph = new Dictionary<int, List<int>>();
            var inDegree = new int[numCourses];
            foreach (var pair in prerequisites)
            {
                int course = pair[0];
                int prerequisite = pair[1];
                if (!graph.ContainsKey(prerequisite))
                {
                    graph[prerequisite] = new List<int>();
                }
                graph[prerequisite].Add(course);
                inDegree[course]++;
            }
            // Use a queue to perform BFS
            var queue = new Queue<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (inDegree[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }
            var result = new List<int>();
            while (queue.Count > 0)
            {
                int currentCourse = queue.Dequeue();
                result.Add(currentCourse);
                if (graph.ContainsKey(currentCourse))
                {
                    foreach (var nextCourse in graph[currentCourse])
                    {
                        inDegree[nextCourse]--;
                        if (inDegree[nextCourse] == 0)
                        {
                            queue.Enqueue(nextCourse);
                        }
                    }
                }
            }
            return result.Count == numCourses ? result.ToArray() : new int[0];
        }
    }
}
