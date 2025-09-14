using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class LetterCombination
    {
        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits))
                return new List<string>();
            var phoneMap = new Dictionary<char, string>
            {
                {'2', "abc"},
                {'3', "def"},
                {'4', "ghi"},
                {'5', "jkl"},
                {'6', "mno"},
                {'7', "pqrs"},
                {'8', "tuv"},
                {'9', "wxyz"}
            };
            var result = new List<string>();
            Backtrack(result, phoneMap, digits, 0, new StringBuilder());
            return result;
        }

        private void Backtrack(List<string> result, Dictionary<char, string> phoneMap, string digits, int v, StringBuilder stringBuilder)
        {
            if (v == digits.Length)
            {
                result.Add(stringBuilder.ToString());
            }
            else
            {
                var digit = digits[v];
                var letters = phoneMap[digit];
                var length = stringBuilder.Length;
                foreach (var letter in letters)
                {
                    stringBuilder.Append(letter);
                    Backtrack(result, phoneMap, digits, v + 1, stringBuilder);
                    stringBuilder.Length = length;
                }
            }
        }
    }
}
