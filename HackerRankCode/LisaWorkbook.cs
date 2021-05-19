using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class LisaWorkbook
    {
        public static void LisaWorkbookFlow()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int k = Convert.ToInt32(firstMultipleInput[1]);
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            int result = Workbook(n, k, arr);
            Console.WriteLine(result);
        }

        private static int Workbook(int n, int k, List<int> arr)
        {
            var specialPageCount = 0;
            int currentPage = 1;
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 1; j <= arr[i]; j += k)
                {
                    var startPage = j;
                    var endPage = j + k - 1 <= arr[i] ? j + k - 1 : arr[i];
                    if (startPage <= currentPage && endPage >= currentPage)
                    {
                        specialPageCount++;
                    }
                    currentPage++;
                }
            }

            return specialPageCount;
        }
    }
}
