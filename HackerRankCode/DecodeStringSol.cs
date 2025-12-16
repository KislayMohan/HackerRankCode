using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankCode
{
    internal class DecodeStringSol
    {
        public string DecodeString(string s)
        {
            Stack<int> countStack = new Stack<int>();
            Stack<StringBuilder> stringStack = new Stack<StringBuilder>();
            StringBuilder currentString = new StringBuilder();
            int k = 0;
            foreach (char ch in s)
            {
                if (char.IsDigit(ch))
                {
                    k = k * 10 + (ch - '0');
                }
                else if (ch == '[')
                {
                    countStack.Push(k);
                    stringStack.Push(currentString);
                    currentString = new StringBuilder();
                    k = 0;
                }
                else if (ch == ']')
                {
                    StringBuilder decodedString = stringStack.Pop();
                    int currentK = countStack.Pop();
                    for (int i = 0; i < currentK; i++)
                    {
                        decodedString.Append(currentString);
                    }
                    currentString = decodedString;
                }
                else
                {
                    currentString.Append(ch);
                }
            }
            return currentString.ToString();
        }
    }
}
