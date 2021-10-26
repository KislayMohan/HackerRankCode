using System;

namespace HackerRankCode
{
    public class SherlockAndSquares
    {
        public static void SherlockAndSquaresSol()
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());
            for (int qItr = 0; qItr < q; qItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
                int a = Convert.ToInt32(firstMultipleInput[0]);
                int b = Convert.ToInt32(firstMultipleInput[1]);
                int result = Squares(a, b);
                Console.WriteLine(result);
            }
        }

        private static int Squares(int a, int b)
        {
            int count = 0;
            var sqrt = Math.Ceiling(Math.Sqrt(a));
            var start = Math.Pow(sqrt, 2);
            while (start >= a && start <= b)
            {
                count++;
                sqrt++;
                start = Math.Pow(sqrt, 2);
            }
            return count;
        }
    }
}
