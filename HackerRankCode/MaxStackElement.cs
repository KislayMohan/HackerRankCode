using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class MaxStackElement
    {
        public static void GetMaxElementIOnStack()
        {
            var queryCount = Convert.ToInt32(Console.ReadLine());
            var stack = new Stack<int>();
            var inputList = new List<string>();
            for (int i = 0; i < queryCount; i++)
            {
                inputList.Add(Console.ReadLine());
            }
            var max = 0;
            foreach (var input in inputList)
            {
                var splitInput = input.Split(' ');
                var command = splitInput[0];
                switch (command)
                {
                    case "1":
                        var data = Convert.ToInt32(splitInput[1]);
                        if (stack.Count == 0)
                        {
                            max = data;
                            stack.Push(data);
                            break;
                        }
                        if (data < max)
                        {
                            stack.Push(data);
                        }
                        else
                        {
                            stack.Push(2 * data - max);
                            max = data;
                        }
                        break;

                    case "2":
                        if (stack.Count > 0)
                        {
                            var popData = stack.Pop();
                            if (popData > max)
                            {
                                max = 2 * max - popData;
                            }
                        }
                        break;

                    case "3":
                        Console.WriteLine(max);
                        break;
                }
            }
        }
    }
}
