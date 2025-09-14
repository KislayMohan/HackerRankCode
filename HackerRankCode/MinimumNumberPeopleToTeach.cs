using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class MinimumNumberPeopleToTeach
    {
        public int MinimumTeachings(int n, int[][] languages, int[][] friendships)
        {
            var languageMap = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < languages.Length; i++)
            {
                languageMap[i + 1] = new HashSet<int>(languages[i]);
            }
            var needToTeach = new HashSet<int>();
            foreach (var friendship in friendships)
            {
                var personA = friendship[0];
                var personB = friendship[1];
                var languagesA = languageMap[personA];
                var languagesB = languageMap[personB];
                if (!languagesA.Overlaps(languagesB))
                {
                    needToTeach.Add(personA);
                    needToTeach.Add(personB);
                }
            }
            if (needToTeach.Count == 0) return 0;
            var languageCount = new int[n + 1];
            int maxKnown = 0;
            foreach (var person in needToTeach)
            {
                foreach (var lang in languageMap[person])
                {
                    languageCount[lang]++;
                    maxKnown = Math.Max(maxKnown, languageCount[lang]);
                }
            }
            return needToTeach.Count - maxKnown;
        }
    }
}
