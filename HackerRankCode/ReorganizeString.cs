using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class ReorganizeString
    {
        public static string ReorganizeStringMethod(string s)
        {
            // Count the frequency of each character
            var charCount = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }
            }
            System.Collections.Generic.PriorityQueue<(char c, int count), int> maxHeap = new System.Collections.Generic.PriorityQueue<(char c, int count), int>(Comparer<int>.Create((a, b) => 
            { return b.CompareTo(a); }));

            foreach (var kvp in charCount)
            {
                maxHeap.Enqueue((kvp.Key, kvp.Value), kvp.Value);
            }
            var result = new StringBuilder();
            while (maxHeap.Count > 0)
            {
                var first = maxHeap.Dequeue();

                if (result.Length > 0 && result[result.Length - 1] == first.c)
                {
                    if (maxHeap.Count == 0) return ""; // Cannot reorganize
                    var second = maxHeap.Dequeue();

                    result.Append(second.c);
                    if (--second.count > 0)
                    {
                        maxHeap.Enqueue(second, second.count);
                    }

                    result.Append(first.c);
                    if (--first.count > 0)
                    {
                        maxHeap.Enqueue(first, first.count);
                    }
                }
                else
                {
                    result.Append(first.c);
                    if (--first.count > 0)
                    {
                        maxHeap.Enqueue(first, first.count);
                    }
                }
            }
            return result.ToString();
        }
    }
}
