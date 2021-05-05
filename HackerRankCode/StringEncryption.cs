using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class StringEncryption
    {
        public static void StringEncryptionFlow()
        {
            string s = Console.ReadLine();
            string result = Encryption(s);
            Console.WriteLine(result);
        }

        private static string Encryption(string s)
        {
            s = s.Replace(" ", "");
            var numsqrt = Math.Sqrt(s.Length);
            var row = Convert.ToInt32(Math.Floor(numsqrt));
            var column = Convert.ToInt32(Math.Ceiling(numsqrt));
            while (row * column < s.Length)
            {
                if (row < column)
                {
                    row++;
                }
                else
                {
                    column++;
                }
            }
            var strBud = new StringBuilder();
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (i + j * column >= s.Length)
                    {
                        continue;
                    }
                    strBud.Append(s[i + j * column]);
                }
                if (i < column - 1)
                {
                    strBud.Append(" ");
                }
            }
            return strBud.ToString();
        }
    }
}
