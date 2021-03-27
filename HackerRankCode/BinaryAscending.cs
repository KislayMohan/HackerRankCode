using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankCode
{
    public class BinaryAscending
    {
        public List<int> BinaryNumberAscending(List<int> elements)
        {
            if (elements.Count > 100000)
            {
                return new List<int>();
            }
            var sortedList = new List<int>();
            var coll = new SortedList<int, SortedList<int, int>>();
            foreach (var num in elements)
            {
                if (num < 1 || num > 1000000000)
                {
                    continue;
                }
                var binaryStr = Convert.ToString(num, 2);
                var countOfOne = binaryStr.Count(c => c == '1');
                if (coll.ContainsKey(countOfOne))
                {
                    if (coll[countOfOne].IndexOfKey(num) >= 0)
                    {
                        continue;
                    }
                    coll[countOfOne].Add(num, num);
                }
                else
                {
                    var temp = new SortedList<int, int>();
                    temp.Add(num, num);
                    coll.Add(countOfOne, temp);
                }
            }
            foreach (var item in coll)
            {
                foreach (var val in item.Value)
                {
                    sortedList.Add(val.Value);
                }
            }
            return sortedList;
        }
    }
}
