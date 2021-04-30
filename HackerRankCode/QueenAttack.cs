using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class QueenAttack
    {
        public static void QueenAttackFlow()
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int k = Convert.ToInt32(firstMultipleInput[1]);
            string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int r_q = Convert.ToInt32(secondMultipleInput[0]);
            int c_q = Convert.ToInt32(secondMultipleInput[1]);
            List<List<int>> obstacles = new List<List<int>>();
            for (int i = 0; i < k; i++)
            {
                obstacles.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp)).ToList());
            }
            int result = QueensAttack(n, k, r_q, c_q, obstacles);
            Console.WriteLine(result);
        }

        private static int QueensAttack1(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
        {
            var count = 0;

            var rowRtObs = -1;
            var colRtObs = -1;
            var rowTopRtObs = -1;
            var colTopRtObs = -1;
            var rowTopObs = -1;
            var colTopObs = -1;
            var rowTopLtObs = -1;
            var colTopLtObs = -1;
            var rowLtObs = -1;
            var colLtObs = -1;
            var rowBtmLtObs = -1;
            var colBtmLtObs = -1;
            var rowBtmObs = -1;
            var colBtmObs = -1;
            var rowBtmRtObs = -1;
            var colBtmRtObs = -1;

            foreach (var obsCoord in obstacles)
            {
                //Right traversal
                if ((obsCoord[1] < colRtObs || rowRtObs == -1) && obsCoord[1] > c_q && obsCoord[0] == r_q)
                {
                    rowRtObs = obsCoord[0];
                    colRtObs = obsCoord[1];
                }
                //Top right traversal
                if (obsCoord[0] - r_q == obsCoord[1] - c_q && obsCoord[0] > r_q && obsCoord[1] > c_q && ((obsCoord[0] < rowTopRtObs && obsCoord[1] < colTopRtObs) || rowTopRtObs == -1))
                {
                    rowTopRtObs = obsCoord[0];
                    colTopRtObs = obsCoord[1];
                }
                //Top traversal
                if ((obsCoord[0] < rowTopObs || colTopObs == -1) && obsCoord[0] > r_q && obsCoord[1] == c_q)
                {
                    rowTopObs = obsCoord[0];
                    colTopObs = obsCoord[1];
                }
                //Top left traversal
                if (obsCoord[0] - r_q == c_q - obsCoord[1] && obsCoord[0] > r_q && obsCoord[1] < c_q && ((obsCoord[0] < rowTopLtObs && obsCoord[1] > colTopLtObs) || rowTopLtObs == -1))
                {
                    rowTopLtObs = obsCoord[0];
                    colTopLtObs = obsCoord[1];
                }
                //Left Traversal
                if (obsCoord[1] > colLtObs && obsCoord[1] < c_q && obsCoord[0] == r_q)
                {
                    rowLtObs = obsCoord[0];
                    colLtObs = obsCoord[1];
                }
                //Bottom left traversal
                if (r_q - obsCoord[0] == c_q - obsCoord[1] && obsCoord[0] < r_q && obsCoord[1] < c_q && (obsCoord[0] > rowBtmLtObs && obsCoord[1] > colBtmLtObs))
                {
                    rowBtmLtObs = obsCoord[0];
                    colBtmLtObs = obsCoord[1];
                }
                //Bottom Traversal
                if (obsCoord[0] > rowBtmObs && obsCoord[0] < r_q && obsCoord[1] == c_q)
                {
                    rowBtmObs = obsCoord[0];
                    colBtmObs = obsCoord[1];
                }
                //Bottom right traversal
                if (r_q - obsCoord[0] == obsCoord[1] - c_q && obsCoord[0] < r_q && obsCoord[1] > c_q && ((obsCoord[0] > rowBtmRtObs && obsCoord[1] < colBtmRtObs) || rowBtmRtObs == -1))
                {
                    rowBtmRtObs = obsCoord[0];
                    colBtmRtObs = obsCoord[1];
                }
            }

            //Right traversal count
            count += colRtObs != -1 ? colRtObs - c_q - 1 : n - c_q;
            //Left traversal count
            count += colLtObs != -1 ? c_q - colLtObs - 1 : c_q - 1;
            //Top traversal count
            count += rowTopObs != -1 ? rowTopObs - r_q - 1 : n - r_q;
            //Bottom traversal count
            count += rowBtmObs != -1 ? r_q - rowBtmObs - 1 : r_q - 1;

            //Top right traversal count
            count += rowTopRtObs != -1 ? colTopRtObs - c_q -1 : Math.Min(n - r_q, n - c_q);
            //Top left traversal count
            count += rowTopLtObs != -1 ? rowTopLtObs - r_q - 1 : Math.Min(c_q - 1, n - r_q);
            //Bottom left traversal colunt
            count += rowBtmLtObs != -1 ? c_q - colBtmLtObs - 1 : Math.Min(r_q - 1, c_q - 1);
            //Bottom right traversal count
            count += rowBtmRtObs != -1 ? colBtmRtObs - c_q - 1 : Math.Min(r_q - 1, n - c_q);

            return count;
        }

        private static int QueensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
        {
            var chess = new int[n, n];
            foreach (var item in obstacles)
            {
                chess[item[0] - 1, item[1] - 1] = -1;
            }
            var count = QueenTraverse(n, r_q - 1, c_q - 1, chess);
            return count;
        }

        private static int QueenTraverse(int n, int r_q, int c_q, int[,] chess)
        {
            var count = 0;
            if (n == 1)
            {
                return count;
            }

            //Travel upward
            for (int temp_r_q = r_q + 1; temp_r_q < n; temp_r_q++)
            {
                if (chess[temp_r_q, c_q] != -1)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            //Travel downward
            for (int temp_r_q = r_q - 1; temp_r_q >= 0; temp_r_q--)
            {
                if (chess[temp_r_q, c_q] != -1)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            //Travel to right
            for (int temp_c_q = c_q + 1; temp_c_q < n; temp_c_q++)
            {
                if (chess[r_q, temp_c_q] != -1)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            //Travel to left
            for (int temp_c_q = c_q - 1; temp_c_q >= 0; temp_c_q--)
            {
                if (chess[r_q, temp_c_q] != -1)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            // both row and col increase hence in 1st quadrant of graph.
            for (int temp_r_q = r_q + 1, temp_c_q = c_q + 1; temp_r_q < n && temp_c_q < n; temp_r_q++, temp_c_q++)
            {
                if (chess[temp_r_q, temp_c_q] != -1)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            // row increase and col decrease hence in 2nd quadrant of graph.
            for (int temp_r_q = r_q + 1, temp_c_q = c_q - 1; temp_r_q < n && temp_c_q >= 0; temp_r_q++, temp_c_q--)
            {
                if (chess[temp_r_q, temp_c_q] != -1)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            // both row and col decrease hence in 3rd quadrant of graph.
            for (int temp_r_q = r_q - 1, temp_c_q = c_q - 1; temp_r_q >= 0 && temp_c_q >= 0; temp_r_q--, temp_c_q--)
            {
                if (chess[temp_r_q, temp_c_q] != -1)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            // row decrease and col increase hence in 4th quadrant of graph.
            for (int temp_r_q = r_q - 1, temp_c_q = c_q + 1; temp_r_q >= 0 && temp_c_q < n; temp_r_q--, temp_c_q++)
            {
                if (chess[temp_r_q, temp_c_q] != -1)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }
    }
}
