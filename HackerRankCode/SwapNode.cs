using System.Collections.Generic;

namespace HackerRankCode
{
    public class SwapNode
    {
        static int[][] SwapNodes(int[][] indexes, int[] queries)
        {
            int[][] result = new int[queries.Length][];
            Queue<Tree> nodeQueue = new Queue<Tree>();
            var root = new Tree(1);
            nodeQueue.Enqueue(root);
            for (int i = 0; i < indexes.Length; i++)
            {
                var current = nodeQueue.Dequeue();
                if (indexes[i].Length != 2)
                {
                    return result;
                }

                if (indexes[i][0] != -1)
                {
                    var leftChild = new Tree(indexes[i][0]);
                    nodeQueue.Enqueue(leftChild);
                    current.LeftChild = leftChild;
                }
                if (indexes[i][1] != -1)
                {
                    var rightChild = new Tree(indexes[i][1]);
                    nodeQueue.Enqueue(rightChild);
                    current.RightChild = rightChild;
                }
            }

            for (int i = 0; i < queries.Length; i++)
            {
                var depth = queries[i];
                int[] inOrder = new int[indexes.Length];
                SwapNodeAtDepth(root, depth, 1);
                inOrder = InOrderTraversal(root);
                result[i] = inOrder;
            }
            return result;
        }

        static void SwapNodeAtDepth(Tree CurrentNode, int Depth, int CurrentDepth)
        {
            if (CurrentNode == null || (CurrentNode.LeftChild == null && CurrentNode.RightChild == null))
            {
                return;
            }
            if (CurrentDepth % Depth == 0)
            {
                var tempNode = CurrentNode.LeftChild;
                CurrentNode.LeftChild = CurrentNode.RightChild;
                CurrentNode.RightChild = tempNode;
            }
            SwapNodeAtDepth(CurrentNode.LeftChild, Depth, CurrentDepth + 1);
            SwapNodeAtDepth(CurrentNode.RightChild, Depth, CurrentDepth + 1);
        }

        static int[] InOrderTraversal(Tree Root)
        {
            List<int> inorderTraversal = new List<int>();
            if (Root != null)
            {
                inorderTraversal.AddRange(InOrderTraversal(Root.LeftChild));
                inorderTraversal.Add(Root.Node);
                inorderTraversal.AddRange(InOrderTraversal(Root.RightChild));
            }

            return inorderTraversal.ToArray();
        }

        class Tree
        {
            public int Node { get; set; }
            public Tree LeftChild { get; set; }
            public Tree RightChild { get; set; }

            public Tree(int value)
            {
                Node = value;
            }
        }
    }
}
