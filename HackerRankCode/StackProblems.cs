using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankCode
{
    public class StackProblems
    {
        public static string BalancedBracket(string input)
        {
            var bracketStack = new Stack<char>();
            foreach (var item in input)
            {
                if (item == '{' || item == '(' || item == '[')
                {
                    bracketStack.Push(item);
                }
                else
                {
                    if (bracketStack.Count == 0)
                    {
                        return "NO";
                    }
                    var topEle = bracketStack.Pop();
                    if (item == '}' && topEle == '{')
                    {
                        continue;
                    }
                    if (item == ')' && topEle == '(')
                    {
                        continue;
                    }
                    if (item == ']' && topEle == '[')
                    {
                        continue;
                    }
                    return "NO";
                }
            }
            if (bracketStack.Count == 0)
            {
                return "YES";
            }
            return "NO";
        }

        /*
         * You have three stacks of cylinders where each cylinder has the same diameter, but they may vary in height. 
         * You can change the height of a stack by removing and discarding its topmost cylinder any number of times.
         * Find the maximum possible height of the stacks such that all of the stacks are exactly the same height. 
         * This means you must remove zero or more cylinders from the top of zero or more of the three stacks until they're all the same height, then print the height. The removals must be performed in such a way as to maximize the height.
         * Note: An empty stack is still a stack.
         */
        public static int EqualStacksUsingList(int[] h1, int[] h2, int[] h3)
        {
            if (h1.Length > 100000 || h2.Length > 100000 || h3.Length > 100000 || h1.Length < 0 || h2.Length < 0 || h3.Length < 0)
            {
                return 0;
            }
            var equalHeight = 0;
            var newArr1 = new List<int>(h1.Length);
            var newArr2 = new List<int>(h2.Length);
            var newArr3 = new List<int>(h3.Length);
            for (int i = h1.Length - 1; i >= 0; i--)
            {
                if (h1[i] > 100 || h1[i] < 0)
                {
                    return 0;
                }
                if (i == h1.Length - 1)
                {
                    newArr1.Add(h1[i]);
                }
                else
                {
                    newArr1.Add(h1[i] + newArr1[newArr1.Count - 1]);
                }
            }
            for (int i = h2.Length - 1; i >= 0; i--)
            {
                if (h2[i] > 100 || h2[i] < 0)
                {
                    return 0;
                }
                if (i == h2.Length - 1)
                {
                    newArr2.Add(h2[i]);
                }
                else
                {
                    newArr2.Add(h2[i] + newArr2[newArr2.Count - 1]);
                }
            }
            for (int i = h3.Length - 1; i >= 0; i--)
            {
                if (h3[i] > 100 || h3[i] < 0)
                {
                    return 0;
                }
                if (i == h3.Length - 1)
                {
                    newArr3.Add(h3[i]);
                }
                else
                {
                    newArr3.Add(h3[i] + newArr3[newArr3.Count - 1]);
                }
            }
            if (newArr1.Count > 0 && newArr2.Count > 0 && newArr3.Count > 0)
            {
                var commnonHeight = newArr1.Intersect(newArr2).Intersect(newArr3);
                if (commnonHeight.Count() > 0)
                {
                    equalHeight = commnonHeight.Max();
                }

            }

            return equalHeight;
        }

        public static int EqualStacksUsingStack(int[] h1, int[] h2, int[] h3)
        {
            var stack1 = new Stack<int>(h1.Length);
            var stack2 = new Stack<int>(h2.Length);
            var stack3 = new Stack<int>(h3.Length);
            int sum1 = 0, sum2 = 0, sum3 = 0;
            for (int i = h1.Length - 1; i >= 0; i--)
            {
                stack1.Push(h1[i]);
                sum1 += h1[i];
            }
            for (int i = h2.Length - 1; i >= 0; i--)
            {
                stack2.Push(h2[i]);
                sum2 += h2[i];
            }
            for (int i = h3.Length - 1; i >= 0; i--)
            {
                stack3.Push(h3[i]);
                sum3 += h3[i];
            }
            while (!(sum1 == sum2 && sum1 == sum3 && sum2 == sum3))
            {
                if (sum1 == 0 || sum2 == 0 || sum3 == 0)
                {
                    return 0;
                }
                if (stack1.Count == 0 || stack2.Count == 0 || stack3.Count == 0)
                {
                    return 0;
                }
                if (sum1 > sum2 && sum1 > sum3)
                {
                    sum1 -= stack1.Pop();
                }
                else if (sum2 > sum1 && sum2 > sum3)
                {
                    sum2 -= stack2.Pop();
                }
                else if (sum3 > sum1 && sum3 > sum2)
                {
                    sum3 -= stack3.Pop();
                }
            }
            return sum1;
        }

        /*
         * Alexa has two stacks of non-negative integers, stack A=[a0,a1,a2...an-1] and stack B=[b0,b1,b2....bn-1] where index denotes the top of the stack. 
         * Alexa challenges Nick to play the following game:
            In each move, Nick can remove one integer from the top of either stack A or stack B.
            Nick keeps a running sum of the integers he removes from the two stacks.
            Nick is disqualified from the game if, at any point, his running sum becomes greater than some integer "x" given at the beginning of the game.
            Nick's final score is the total number of integers he has removed from the two stacks.
            Given A, B, and "x" for  games, find the maximum possible score Nick can achieve (i.e., the maximum number of integers he can remove without being disqualified) during each game and print it on a new line.
         */
        public static int TwoStackGame(int x, int[] a, int[] b)
        {
            if (x < 1 || x > 1000000000)
            {
                return 0;
            }
            if (a.Length < 1 || a.Length > 100000)
            {
                return 0;
            }
            int movesCount = 0, sum = 0;
            var stack1 = new Stack<int>(a.Length);
            var stack2 = new Stack<int>(b.Length);
            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (a[i] < 0 || a[i] > 1000000)
                {
                    return 0;
                }
                stack1.Push(a[i]);
            }
            for (int i = b.Length - 1; i >= 0; i--)
            {
                if (b[i] < 0 || b[i] > 1000000)
                {
                    return 0;
                }
                stack2.Push(b[i]);
            }
            while (stack1.Count > 0 || stack2.Count > 0)
            {
                if (stack1.Count > 0 && stack2.Count == 0)
                {
                    sum += stack1.Pop();
                }
                else if (stack2.Count > 0 && stack1.Count == 0)
                {
                    sum += stack2.Pop();
                }
                else if (stack1.Peek() < stack2.Peek())
                {
                    sum += stack1.Pop();
                }
                else
                {
                    sum += stack2.Pop();
                }
                if (sum <= x)
                {
                    movesCount++;
                }
            }

            return movesCount;
        }

        public static int TwoStackGameNew(int x, int[] a, int[] b)
        {
            int movesCount = 0, sum = 0;
            int i = 0, j = 0;
            while (i < a.Length && sum + a[i] <= x)
            {
                sum += a[i];
                i++;
            }
            movesCount = i;
            while (j < b.Length && i >= 0)
            {
                sum += b[j];
                j++;
                while (sum > x && i > 0)
                {
                    i--;
                    sum -= a[i];
                }
                if (sum <= x && i + j > movesCount)
                    movesCount = i + j;
            }

            return movesCount;
        }

        /// <summary>
        /// Finding largest rectangle in historgram.
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public static long LargestRectangle(int[] h)
        {
            long largestRect = 0;
            int counter = 0;
            var positionStack = new Stack<int>();
            var heightStack = new Stack<int>();
            for (int i = 0; i < h.Length; i++)
            {
                if (heightStack.Count == 0 || heightStack.Peek() < h[i])
                {
                    heightStack.Push(h[i]);
                    positionStack.Push(i);
                }
                else
                {
                    var position = -1;
                    while (heightStack.Count > 0 && heightStack.Peek() >= h[i])
                    {
                        var height = heightStack.Pop();
                        position = positionStack.Pop();
                        var area = height * (counter - position);
                        if (area > largestRect)
                        {
                            largestRect = area;
                        }
                    }
                    heightStack.Push(h[i]);
                    positionStack.Push(position);
                }
                counter++;
            }
            while (positionStack.Count > 0)
            {
                var height = heightStack.Pop();
                var position = positionStack.Pop();
                var area = height * (counter - position);
                if (area > largestRect)
                {
                    largestRect = area;
                }
            }

            return largestRect;
        }

        /// <summary>
        /// In this challenge, you must implement a simple text editor. Initially, your editor contains an empty string, "S" .
        /// You must perform  operations of the following  types:
        /// 1. append(W) - Append string (W) to the end of.
        /// 2. delete(k) - Delete the last k characters of "S".
        /// 3. print(k) - Print the kth character of "S".
        /// 4. undo - Undo the last (not previously undone) operation of type 1 or 2, reverting "S" to the state it was in prior to that operation.
        /// Input format
        /// The first line contains an integer, Q, denoting the number of operations. 
        /// Each line i of the Q subsequent lines(where 0 is less or equal to i and i less than Q) defines an operation to be performed.
        /// Each operation starts with a single integer,t (where t is {1,2,3,4}), denoting a type of operation as defined in the Problem Statement above. 
        /// If the operation requires an argument, "t" is followed by its space-separated argument. 
        /// For example, if t = 1 and W="abcd", line will be "1 abcd".
        /// </summary>
        public static void SimpleTextEditor()
        {
            var text = string.Empty;
            var printText = new List<char>();
            var editorStack = new Stack<KeyValuePair<string, string>>();
            var inputCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < inputCount; i++)
            {
                var query = Console.ReadLine();
                var splitQuery = query.Split(' ');
                switch (Convert.ToInt32(splitQuery[0]))
                {
                    case 1:
                        text += splitQuery[1];
                        editorStack.Push(new KeyValuePair<string, string>("a", splitQuery[1]));
                        break;

                    case 2:
                        var index = Convert.ToInt32(splitQuery[1]);
                        var delString = text.Substring(text.Length - index, index);
                        text = text.Remove(text.Length - index, index);
                        editorStack.Push(new KeyValuePair<string, string>("d", delString));
                        break;

                    case 3:
                        printText.Add(text[Convert.ToInt32(splitQuery[1]) - 1]);
                        break;

                    case 4:
                        var operation = editorStack.Pop();
                        if (operation.Key == "a")
                        {
                            var subStringIndex = text.LastIndexOf(operation.Value);
                            text = text.Remove(subStringIndex, operation.Value.Count());
                        }
                        else
                        {
                            text += operation.Value;
                        }
                        break;

                    default:
                        break;
                }
            }

            foreach (var str in printText)
            {
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// You are a waiter at a party. There are "N" stacked plates on pile A0. Each plate has a number written on it. 
        /// Then there will be "Q" iterations. In i-th iteration, you start picking up the plates in Ai-1 from the top one by one 
        /// and check whether the number written on the plate is divisible by the i-th prime. 
        /// If the number is divisible, you stack that plate on pile Bi. Otherwise, you stack that plate on pile Ai. 
        /// After "Q" iterations, plates can only be on pile B1,B2,...,BQ, AQ. 
        /// Output numbers on these plates from top to bottom of each piles in order of B1,B2,...,BQ, AQ.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int[] Waiter(int[] number, int q)
        {
            var finalPlatesColl = new List<int>();
            var stackA0 = new Stack<int>(number);
            var stackA1 = new Stack<int>();
            var stackB = new Stack<int>();
            bool useFirstStackA = true;
            Stack<int> tempStack = null;

            for (int i = 1; i <= q; i++)
            {
                tempStack = useFirstStackA ? stackA0 : stackA1;
                while (tempStack.Count() > 0)
                {
                    var num = tempStack.Pop();
                    if (num % CommonFunction.primeList[i - 1] == 0)
                    {
                        stackB.Push(num);
                    }
                    else
                    {
                        if (useFirstStackA)
                        {
                            stackA1.Push(num);
                        }
                        else
                        {
                            stackA0.Push(num);
                        }
                    }
                }
                if (useFirstStackA)
                {
                    stackA0.Clear();
                }
                else
                {
                    stackA1.Clear();
                }
                useFirstStackA = !useFirstStackA;
                while (stackB.Count() > 0)
                {
                    finalPlatesColl.Add(stackB.Pop());
                }
            }
            tempStack = useFirstStackA ? stackA0 : stackA1;
            while (tempStack.Count() > 0)
            {
                finalPlatesColl.Add(tempStack.Pop());
            }

            return finalPlatesColl.ToArray();
        }

        public static int AndXorOr(int[] a)
        {
            var max = 0;
            var numStack = new Stack<int>();
            foreach (var num in a)
            {
                while (numStack.Count() > 0)
                {
                    var result = num ^ numStack.Peek();
                    if (result > max)
                    {
                        max = result;
                    }
                    if (num < numStack.Peek())
                    {
                        numStack.Pop();
                    }
                    else
                    {
                        break;
                    }
                }
                numStack.Push(num);
            }
            return max;
        }

        /// <summary>
        /// There are a number of plants in a garden. Each of these plants has been treated with some amount of pesticide. 
        /// After each day, if any plant has more pesticide than the plant on its left, being weaker than the left one, it dies.
        /// You are given the initial values of the pesticide in each of the plants.
        /// Print the number of days after which no plant dies, i.e.the time after which there are no plants with more pesticide content than the plant to their left.
        /// For example, pesticide levels p=[3,6,2,7,5]. Using a 1-indexed array, day 1 plants 2 and 4 die leaving p=[3,2,5].
        /// On day 2, plant 3 of the current array dies leaving p=[3,2].
        /// As there is no plant with a higher concentration of pesticide than the one to its left, plants stop dying after day 2.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int PoisonousPlant(int[] p)
        {
            /*
            int days = 0;
            var plantStack = new Stack<int>(p.Reverse());
            var plantList = new List<int>();
            while (plantStack.Count() > 0)
            {
                var planStackCount = plantStack.Count();
                var lastChecked = plantStack.Pop();
                plantList.Add(lastChecked);
                while (plantStack.Count() > 0)
                {
                    var currentPlant = plantStack.Pop();
                    if (lastChecked >= currentPlant)
                    {
                        plantList.Add(currentPlant);
                    }
                    lastChecked = currentPlant;
                }
                if (plantList.Count == planStackCount)
                {
                    break;
                }
                days++;
                plantList.Reverse();
                plantStack = new Stack<int>(plantList);
                plantList.Clear();
            }
            return days;
            */
            int days = 0;
            var plantStack = new Stack<int>(p);
            var plantList = new LinkedList<int>();
            while (plantStack.Count() > 0)
            {
                var planStackCount = plantStack.Count();
                var lastChecked = plantStack.Pop();
                while (plantStack.Count() > 0)
                {
                    var currentPlant = plantStack.Pop();
                    if (lastChecked < currentPlant)
                    {
                        plantList.AddFirst(lastChecked);
                    }
                    lastChecked = currentPlant;
                }
                if (plantList.Count > 0)
                {
                    plantList.AddFirst(lastChecked);
                }
                if (plantList.Count == 0 || plantList.Count == planStackCount)
                {
                    break;
                }
                days++;
                plantStack = new Stack<int>(plantList);
                plantList.Clear();
            }
            return days;
        }

        public static int PoisonousPlant2(int[] p)
        {
            int days = 0;
            var plantStackList = new LinkedList<Stack<int>>();
            var plantStack = new Stack<int>();
            plantStack.Push(p[0]);
            for (int i = 1; i < p.Length; i++)
            {
                if (plantStack.Peek() < p[i])
                {
                    plantStackList.AddLast(plantStack);
                    plantStack = new Stack<int>();
                }
                plantStack.Push(p[i]);
            }
            var initialCount = plantStackList.Count;
            while (plantStackList.Count > 0)
            {
                var tempPlantStackList = plantStackList;
                Stack<int> tempItem = null;
                foreach (var item in tempPlantStackList)
                {
                    if (item.Count == 1)
                    {
                        plantStackList.Remove(item);
                        tempItem = item;
                        continue;
                    }
                    if (tempItem != null && tempItem.Peek() < item.Last())
                    {

                    }
                    tempItem = item;
                }
            }
            return days;
        }

        public static int PoisonousPlantNew(int[] p)
        {
            int days = 0;
            var plantStackList = new LinkedList<Stack<int>>();
            var plantStack = new Stack<int>();
            var tempList = new List<int>
            {
                p[p.Length - 1]
            };
            for (int i = p.Length - 2; i >= 0; i--)
            {
                if (p[i] < p[i + 1])
                {
                    plantStackList.AddFirst(new LinkedListNode<Stack<int>>(new Stack<int>(tempList)));
                    //node = plantStackList.AddFirst(new Stack<int>(tempList));
                    tempList = new List<int>();
                }
                tempList.Add(p[i]);
            }
            if (tempList.Any())
            {
                plantStackList.AddFirst(new LinkedListNode<Stack<int>>(new Stack<int>(tempList)));
                //plantStackList.AddFirst(new Stack<int>(tempList));
            }
            while (plantStackList.Count > 1)
            {
                for (int i = 1; i < plantStackList.Count; i++)
                {
                    var tempPlant = -1;
                    while (plantStackList.ElementAt(i).Peek() > tempPlant)
                    {
                        tempPlant = plantStackList.ElementAt(i).Pop();
                    }
                    if (plantStackList.ElementAt(i - 1).Last() < plantStackList.ElementAt(i).Peek())
                    {

                    }
                }
                days++;
            }
            return days;
        }
    }
}
