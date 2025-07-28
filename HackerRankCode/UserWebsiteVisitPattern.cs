using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class UserWebsiteVisitPattern
    {
        public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
        {
            var websiteColl = new List<(string website, string person, int time)>();
            var userWebsites = new Dictionary<string, List<string>>();
            for (int i = 0; i < username.Length; i++) {
                websiteColl.Add((website[i], username[i], timestamp[i]));
            }
            // Sort by time
            websiteColl.Sort((a, b) => a.time.CompareTo(b.time));
            foreach (var entry in websiteColl)
            {
                if (!userWebsites.ContainsKey(entry.person))
                {
                    userWebsites[entry.person] = new List<string>();
                }
                userWebsites[entry.person].Add(entry.website);
            }

            var patternUsers = new Dictionary<string, HashSet<string>>();
            foreach (var user in userWebsites)
            {
                var websites = user.Value;
                if (websites.Count < 3) continue; // Need at least 3 websites to form a pattern
                var patterns = new HashSet<string>();
                for (int i = 0; i < websites.Count - 2; i++)
                {
                    for (int j = i + 1; j < websites.Count - 1; j++)
                    {
                        for (int k = j + 1; k < websites.Count; k++)
                        {
                            var pattern = $"{websites[i]},{websites[j]},{websites[k]}";
                            patterns.Add(pattern);
                        }
                    }
                }
                foreach (var pattern in patterns)
                {
                    if (!patternUsers.ContainsKey(pattern))
                    {
                        patternUsers[pattern] = new HashSet<string>();
                    }
                    patternUsers[pattern].Add(user.Key);
                }
            }

            string bestPattern = "";
            int maxScore = 0;

            foreach (var kvp in patternUsers)
            {
                string pattern = kvp.Key;
                int score = kvp.Value.Count;

                if (score > maxScore || (score == maxScore && string.Compare(pattern, bestPattern) < 0))
                {
                    maxScore = score;
                    bestPattern = pattern;
                }
            }

            return bestPattern.Split(',');
        }
    }
}
