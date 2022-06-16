using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class DesginerPdf
    {
        public static void DesginerPdfSol()
        {
            List<int> h = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(hTemp => Convert.ToInt32(hTemp)).ToList();
            string word = Console.ReadLine();
            int result = DesignerPdfViewer(h, word);
            Console.WriteLine(result);
        }

        private static int DesignerPdfViewer(List<int> h, string word)
        {
            Dictionary<int, int> lookup = new Dictionary<int, int>();
            for (int i = 0; i < h.Count(); i++)
            {
                lookup[97 + i] = h[i];
            }
            var max = 0;
            foreach (var item in word)
            {
                var ascii = lookup[(int)item];
                if (ascii > max)
                {
                    max = ascii;
                }
            }
            return max * word.Length;
        }
    }
}
