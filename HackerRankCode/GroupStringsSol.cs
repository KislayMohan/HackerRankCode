using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankCode
{
    internal class GroupStringsSol
    {
        public IList<IList<string>> GroupStrings(string[] strings)
        {
            Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
            foreach (var str in strings)
            {
                StringBuilder keyBuilder = new StringBuilder();
                for (int i = 1; i < str.Length; i++)
                {
                    int diff = (str[i] - str[i - 1] + 26) % 26;
                    keyBuilder.Append(diff).Append(',');
                }
                string key = keyBuilder.ToString();
                if (!groups.ContainsKey(key))
                {
                    groups[key] = new List<string>();
                }
                groups[key].Add(str);
            }
            IList<IList<string>> result = new List<IList<string>>();
            foreach (var group in groups.Values)
            {
                result.Add(group);
            }
            return result;
        }
    }
}
