using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class SubStringWithConcatenation
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            var wordCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (wordCount.ContainsKey(word))
                    wordCount[word]++;
                else
                    wordCount[word] = 1;
            }
            int wordLength = words[0].Length;
            int totalWords = words.Length;
            int substringLength = wordLength * totalWords;
            var result = new List<int>();
            for (int i = 0; i <= s.Length - substringLength; i++)
            {
                var seenWords = new Dictionary<string, int>();
                int j = 0;
                while (j < totalWords)
                {
                    int wordStart = i + j * wordLength;
                    string word = s.Substring(wordStart, wordLength);
                    if (!wordCount.ContainsKey(word))
                        break;
                    if (seenWords.ContainsKey(word))
                        seenWords[word]++;
                    else
                        seenWords[word] = 1;
                    if (seenWords[word] > wordCount[word])
                        break;
                    j++;
                }
                if (j == totalWords)
                    result.Add(i);
            }
            return result;
        }
    }
}
