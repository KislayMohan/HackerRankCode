using System;
using System.Collections.Generic;

namespace HackerRankCode
{
    public class QueueUsingTwoStacks
    {
        public static void QueueUsingStack()
        {
            Stack<int> stack1 = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();
            var queryCount = Convert.ToInt32(Console.ReadLine());
            var inputList = new List<string>();
            for (int i = 0; i < queryCount; i++)
            {
                inputList.Add(Console.ReadLine());
            }

            foreach (var input in inputList)
            {
                var splitInput = input.Split(' ');
                var command = splitInput[0];
                switch (command)
                {
                    case "1":
                        var data = Convert.ToInt32(splitInput[1]);
                        stack1.Push(data);
                        break;
                    default:
                        if (stack2.Count == 0)
                        {
                            while (stack1.Count > 0)
                            {
                                stack2.Push(stack1.Pop());
                            }
                        }
                        if (stack2.Count > 0)
                        {
                            if (command == "2")
                            {
                                stack2.Pop();
                            }
                            else
                            {
                                Console.WriteLine(stack2.Peek());
                            }
                        }
                        break;
                }
            }
        }
    }
}
