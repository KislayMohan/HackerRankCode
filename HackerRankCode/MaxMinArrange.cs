using System;

namespace HackerRankCode
{
    public class MaxMinArrange
    {
        public static void MaxMinArrangeSol()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Array before min/max: ");
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i] + " ");
            Console.WriteLine();

            MaxMin(arr);

            Console.WriteLine("Array after min/max: ");
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i] + " ");
            Console.WriteLine();
        }

        public static void MaxMin(int[] arr)
        {
            int maxIdx = arr.Length - 1;
            int minIdx = 0;
            int maxElem = arr[maxIdx] + 1; // store any element that is greater than the maximum element in the array 
            for (int i = 0; i < arr.Length; i++)
            {
                // at even indices we will store maximum elements
                if (i % 2 == 0)
                {
                    //This will store current element and max element at same index. Current can be retrieved by arr[i] % maxElem and max element can be retrieved by arr[i] / maxElem
                    arr[i] += (arr[maxIdx] % maxElem) * maxElem;
                    maxIdx -= 1;
                }
                else
                { // at odd indices we will store minimum elements
                    //This will store current element and max element at same index. Current can be retrieved by arr[i] % maxElem and max element can be retrieved by arr[i] / maxElem
                    arr[i] += (arr[minIdx] % maxElem) * maxElem;
                    minIdx += 1;
                }
            }
            // dividing with maxElem to get original values.
            for (int i = 0; i < arr.Length; i++)
            {
                //This will retrieve the corresponding max element by arr[i] / maxElem done in above steps under loop.
                arr[i] = arr[i] / maxElem;
            }
        }
    }
}
