using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class GroupAnagrams
    {
        public static IList<IList<string>> GroupAnagramsMethod(string[] strs)
        {
            if (strs.Length == 0)
            {
                return new List<IList<string>>();
            }
            
            var anagramMap = new Dictionary<string, IList<string>>();
            foreach (var str in strs) 
            {
                int[] fillMap = new int[26];
                foreach (var c in str)
                {
                    fillMap[c - 'a']++;
                }
                var sb = new StringBuilder();
                for (int i = 0; i < 26; i++)
                {
                    sb.Append('#');
                    sb.Append(fillMap[i]);
                }
                if (anagramMap.ContainsKey(sb.ToString()))
                {
                    anagramMap[sb.ToString()].Add(str);
                }
                else
                {
                    anagramMap[sb.ToString()] = new List<string> { str };
                }
            }

            return (IList<IList<string>>)anagramMap.Values.ToList();
        }
    }
}
