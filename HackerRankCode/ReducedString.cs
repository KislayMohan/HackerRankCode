using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public static class ReducedString
    {
        public static void ReducedStringSol()
        {
            string s = Console.ReadLine();
            string result = SuperReducedString(s);
            Console.WriteLine(result);
        }

        private static string SuperReducedString(string s)
        {

            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }
            var reducedStr = "Empty String";
            var charStack = new Stack<char>();
            charStack.Push(s[0]);
            for (int i = 1; i < s.Length; i++)
            {
                if (charStack.Count > 0)
                {
                    if (s[i] == charStack.Peek())
                    {
                        charStack.Pop();
                    }
                    else
                    {
                        charStack.Push(s[i]);
                    }
                }
                else
                {
                    charStack.Push(s[i]);
                }
            }
            if (charStack.Count > 0)
            {
                reducedStr = string.Join("", charStack.Reverse());
            }
            return reducedStr;
        }
    }
}
