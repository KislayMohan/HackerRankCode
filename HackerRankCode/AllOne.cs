using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class AllOne
    {
        Dictionary<String, int> data;
        String maxKey;
        int maxCount;
        String minKey;
        int minCount;

        public AllOne()
        {
            data = new Dictionary<String, int>();
            maxKey = "";
            minKey = "";
            int maxCount = 0;
            int minCount = 0;
        }

        public void Inc(string key)
        {
            if (data.ContainsKey(key))
            {
                data[key]++;
                if (data[key] > maxCount)
                {
                    maxCount = data[key];
                    maxKey = key;
                }
                if (key == minKey && data.Count > 1)
                {
                    int tempMinCount = -1;
                    foreach (var item in data)
                    {
                        if (tempMinCount == -1 || item.Value < minCount)
                        {
                            minCount = item.Value;
                            minKey = item.Key;
                            tempMinCount++;
                        }
                    }
                }
            }
            else
            {
                data[key] = 1;
                if (data[key] > maxCount)
                {
                    maxCount = data[key];
                    maxKey = key;
                }
                minCount = data[key];
                minKey = key;
            }
        }

        public void Dec(string key)
        {
            if (data.ContainsKey(key))
            {
                bool isCurrMax = data[key] == maxCount;
                bool isCurrMin = data[key] == minCount;
                int tempCount = data[key];
                if (data[key] == 1)
                {
                    data.Remove(key);
                }
                else
                {
                    data[key]--;
                }

                if (data.Count <= 0)
                {
                    maxCount = 0;
                    minCount=0;
                    maxKey = "";
                    minKey = "";
                    return;
                }

                if (isCurrMax)
                {
                    foreach (var item in data)
                    {
                        if (item.Value <= tempCount)
                        {
                            maxCount = item.Value;
                            maxKey = item.Key;
                            break;
                        }
                    }
                }
                if (isCurrMin && tempCount == 1)
                {
                    int tempMinCount = -1;
                    foreach (var item in data)
                    {
                        if (tempMinCount == -1 || item.Value < minCount)
                        {
                            minCount = item.Value;
                            minKey = item.Key;
                            tempMinCount++;
                        }
                    }
                }
            }
        }

        public string GetMaxKey()
        {
            return maxKey;
        }

        public string GetMinKey()
        {
            return minKey;
        }
    }
}
