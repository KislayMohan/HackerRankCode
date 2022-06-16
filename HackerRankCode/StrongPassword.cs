using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class StrongPassword
    {
        public static void StrongPasswordSol()
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            string password = Console.ReadLine();
            int answer = MinimumNumber(n, password);
            Console.WriteLine(answer);
        }

        private static int MinimumNumber(int n, string password)
        {
            var minLen = password.Length < 6 ? 6 - password.Length : 0;
            var specialCharsAscii = Encoding.ASCII.GetBytes("!@#$%^&*()-+").Select(a => Convert.ToInt32(a));
            var mandateCount = 0;
            bool hasNum = false, hasUpperCase = false, hasLowerCase = false, hasSpecialChar = false;
            foreach (var item in password)
            {
                var num = -1;
                if (int.TryParse(item.ToString(), out num))
                {
                    hasNum = true;
                    continue;
                }
                var ascii = (int)item;
                if (ascii >= 65 && ascii <= 90)
                {
                    hasUpperCase = true;
                }
                else if (ascii >= 97 && ascii <= 122)
                {
                    hasLowerCase = true;
                }
                else if (specialCharsAscii.Contains(ascii))
                {
                    hasSpecialChar = true;
                }
            }
            if (!hasNum)
            {
                mandateCount++;
            }
            if (!hasUpperCase)
            {
                mandateCount++;
            }
            if (!hasLowerCase)
            {
                mandateCount++;
            }
            if (!hasSpecialChar)
            {
                mandateCount++;
            }

            return minLen > mandateCount ? minLen : mandateCount;
        }
    }
}
