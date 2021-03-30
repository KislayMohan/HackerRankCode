﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankCode
{
    public class MedianUpdates
    {
        public static void MedianUpdateSol()
        {
            int N;
            N = Convert.ToInt32(Console.ReadLine());
            int[] x = new int[N];
            string[] s = new string[N];

            for (int i = 0; i < N; i++)
            {

                string tmp = Console.ReadLine();
                string[] split = tmp.Split(new Char[] { ' ', '\t', '\n' });

                s[i] = split[0].Trim();
                x[i] = Convert.ToInt32(split[1].Trim());

            }
            Console.WriteLine("--------------------------------");
            Median1(s, x);
        }

        private static void Median1(string[] a, int[] x)
        {
            var maxSortedData = new SortedDictionary<int, List<int>>(); // Read the max value from end on dictionary
            var minSortedData = new SortedDictionary<int, List<int>>(); // Read the min value from end of dictionary
            int maxSortedDataCount = 0, minSortedDataCount = 0;
            for (int i = 0; i < a.Count(); i++)
            {
                switch (a[i])
                {
                    case "a":
                        if (maxSortedDataCount == 0)
                        {
                            maxSortedData[x[i]] = new List<int> { x[i] };
                            maxSortedDataCount++;
                        }
                        else
                        {
                            if (minSortedDataCount > 0 && minSortedData.First().Key < x[i])
                            {
                                var movableData = minSortedData.First();
                                if (movableData.Value.Count > 1)
                                {
                                    minSortedData[movableData.Key].RemoveAt(minSortedData[movableData.Key].Count - 1);
                                }
                                else
                                {
                                    minSortedData.Remove(movableData.Key);
                                }
                                if (!maxSortedData.ContainsKey(movableData.Key))
                                {
                                    maxSortedData.Add(movableData.Key, new List<int> { movableData.Value.First() });
                                }
                                else
                                {
                                    maxSortedData[movableData.Key].Add(movableData.Value.First());
                                }

                                maxSortedDataCount++;


                                if (!minSortedData.ContainsKey(x[i]))
                                {
                                    minSortedData[x[i]] = new List<int> { x[i] };
                                }
                                else
                                {
                                    minSortedData[x[i]].Add(x[i]);
                                }
                            }
                            else
                            {
                                if (!maxSortedData.ContainsKey(x[i]))
                                {
                                    maxSortedData[x[i]] = new List<int> { x[i] };
                                }
                                else
                                {
                                    maxSortedData[x[i]].Add(x[i]);
                                }
                                maxSortedDataCount++;
                            }
                        }
                        break;

                    case "r":
                        if (maxSortedData.ContainsKey(x[i]))
                        {
                            if (maxSortedData[x[i]].Count == 1)
                            {
                                maxSortedData.Remove(x[i]);
                            }
                            else
                            {
                                maxSortedData[x[i]].RemoveAt(maxSortedData[x[i]].Count - 1);
                            }
                            maxSortedDataCount--;
                        }
                        else if (minSortedData.ContainsKey(x[i]))
                        {
                            if (minSortedData[x[i]].Count == 1)
                            {
                                minSortedData.Remove(x[i]);
                            }
                            else
                            {
                                minSortedData[x[i]].RemoveAt(minSortedData[x[i]].Count - 1);
                            }
                            minSortedDataCount--;
                        }
                        else
                        {
                            Console.WriteLine("Wrong!");
                            continue;
                        }
                        break;
                }

                if (maxSortedDataCount > minSortedDataCount && maxSortedDataCount - minSortedDataCount > 1)
                {
                    var data = maxSortedData.Last();
                    if (data.Value.Count > 1)
                    {
                        maxSortedData[data.Key].RemoveAt(maxSortedData[data.Key].Count - 1);
                    }
                    else
                    {
                        maxSortedData.Remove(data.Key);
                    }
                    if (!minSortedData.ContainsKey(data.Key))
                    {
                        minSortedData.Add(data.Key, new List<int> { data.Value.First() });
                    }
                    else
                    {
                        minSortedData[data.Key].Add(data.Value.First());
                    }
                    maxSortedDataCount--;
                    minSortedDataCount++;
                }
                else if (minSortedDataCount > maxSortedDataCount && minSortedDataCount - maxSortedDataCount > 1)
                {
                    var data = minSortedData.Last();
                    if (data.Value.Count > 1)
                    {
                        minSortedData[data.Key].RemoveAt(minSortedData[data.Key].Count - 1);
                    }
                    else
                    {
                        minSortedData.Remove(data.Key);
                    }
                    if (!maxSortedData.ContainsKey(data.Key))
                    {
                        maxSortedData.Add(data.Key, new List<int> { data.Value.First() });
                    }
                    else
                    {
                        maxSortedData[data.Key].Add(data.Value.First());
                    }

                    maxSortedDataCount++;
                    minSortedDataCount--;
                }

                if (minSortedDataCount <= 0 && maxSortedDataCount <= 0)
                {
                    Console.WriteLine("Wrong!");
                    continue;
                }

                if (minSortedDataCount == maxSortedDataCount && minSortedDataCount > 0)
                {
                    var minData = minSortedData.First().Value.First();
                    var maxData = maxSortedData.Last().Value.First();
                    Console.WriteLine(decimal.Divide((long)minData + (long)maxData, 2));
                }
                else
                {
                    if (maxSortedDataCount > minSortedDataCount && maxSortedDataCount > 0)
                    {
                        Console.WriteLine(maxSortedData.Last().Value.First());
                    }
                    else if(minSortedDataCount > 0)
                    {
                        Console.WriteLine(minSortedData.First().Value.First());
                    }
                }
            }
        }

        private static void Median(string[] a, int[] x)
        {
            var currentSize = 0;
            var NumList = new List<int>();
            IntNode root = null;
            Tuple<IntNode, bool> nodeResult = new Tuple<IntNode, bool>(root, true);
            for (int i = 0; i < a.Count(); i++)
            {
                switch (a[i])
                {
                    case "a":
                        if (root == null)
                        {
                            root = new IntNode(x[i]);
                        }
                        else
                        {
                            InsertNode(root, x[i]);
                        }
                        nodeResult = new Tuple<IntNode, bool>(root, true);
                        currentSize++;
                        break;

                    case "r":
                        if (i == 0 || root == null)
                        {
                            Console.WriteLine("Wrong!");
                            continue;
                        }
                        nodeResult = RemoveNode(root, x[i]);
                        root = nodeResult.Item1;
                        if (nodeResult.Item2)
                        {
                            currentSize--;
                        }
                        break;
                }
                if (currentSize == 0 || !nodeResult.Item2)
                {
                    Console.WriteLine("Wrong!");
                    continue;
                }
                var result1 = Traverse(root);
                var result = CustomTraverse(root, currentSize / 2 + 1);
                if (currentSize % 2 == 0)
                {
                    //Console.WriteLine(decimal.Divide((long)result[currentSize / 2 - 1] + (long)result[currentSize / 2], 2));
                    Console.WriteLine(decimal.Divide((long)result[result.Count - 1] + (long)result[result.Count - 2], 2));
                }
                else
                {
                    //Console.WriteLine(result[currentSize / 2]);
                    Console.WriteLine(result[result.Count - 1]);
                }
            }
        }

        private static List<int> Traverse(IntNode root)
        {
            List<int> inorderTraversal = new List<int>();
            if (root != null)
            {
                inorderTraversal.AddRange(Traverse(root.LeftChild));
                inorderTraversal.Add(root.Data);
                inorderTraversal.AddRange(Traverse(root.RightChild));
            }
            return inorderTraversal;
        }

        private static List<int> CustomTraverse(IntNode root, int count)
        {
            List<int> inorderTraversal = new List<int>();
            if (root != null)
            {
                if (count > 0)
                {
                    inorderTraversal.AddRange(CustomTraverse(root.LeftChild, count));
                }
                inorderTraversal.Add(root.Data);
                count = count - inorderTraversal.Count;
                if (count > 0)
                {
                    inorderTraversal.AddRange(CustomTraverse(root.RightChild, count));
                }
                count = count - inorderTraversal.Count;
            }
            return inorderTraversal;
        }

        private static void InsertNode(IntNode root, int value)
        {
            if (root.Data >= value)
            {
                if (root.LeftChild == null)
                {
                    var newNode = new IntNode(value);
                    root.LeftChild = newNode;
                }
                else
                {
                    InsertNode(root.LeftChild, value);
                }
            }
            else
            {
                if (root.RightChild == null)
                {
                    var newNode = new IntNode(value);
                    root.RightChild = newNode;
                }
                else
                {
                    InsertNode(root.RightChild, value);
                }
            }
        }

        private static Tuple<IntNode, bool> RemoveNode(IntNode currentNode, int value)
        {
            Tuple<IntNode, bool> result;
            if (currentNode == null)
            {
                //Console.WriteLine("Wrong!");
                return new Tuple<IntNode, bool>(currentNode, false);
            }
            if (currentNode.Data > value)
            {
                result = RemoveNode(currentNode.LeftChild, value);
                currentNode.LeftChild = result.Item1;
            }
            else if (currentNode.Data < value)
            {
                result = RemoveNode(currentNode.RightChild, value);
                currentNode.RightChild = result.Item1;
            }
            else // root of the tree
            {
                if (currentNode.RightChild == null) // has only left subtree
                {
                    return new Tuple<IntNode, bool>(currentNode.LeftChild, true);
                }
                else if (currentNode.LeftChild == null) // has only right subtree
                {
                    return new Tuple<IntNode, bool>(currentNode.RightChild, true);
                }
                else // has both left and right suubtree
                {
                    // Lets chose left subtree to be new root, so keep travelling to rightmost end of left subtree.
                    currentNode.Data = TreeMinVale(currentNode.RightChild);
                    result = RemoveNode(currentNode.RightChild, currentNode.Data);
                    currentNode.RightChild = result.Item1;
                }
            }

            return new Tuple<IntNode, bool>(currentNode, result.Item2);
        }

        private static int TreeMinVale(IntNode node)
        {
            var val = node.Data;
            while (node.LeftChild != null)
            {
                val = node.LeftChild.Data;
                node = node.LeftChild;
            }
            return val;
        }

        class IntNode
        {
            public int Data { get; set; }
            public IntNode LeftChild { get; set; }
            public IntNode RightChild { get; set; }
            public IntNode(int value)
            {
                Data = value;
            }
        }
    }
}
