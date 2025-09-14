using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    internal class BinaryTreeAncestor
    {
        private Dictionary<int, TreeNode> parentMap;
        public BinaryTreeAncestor()
        {
            parentMap = new Dictionary<int, TreeNode>();
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            BuildParentMap(root, p, q);
            HashSet<TreeNode> visit = new HashSet<TreeNode>();
            while (p != null)
            {
                visit.Add(p);
                p = parentMap[p.val];
            }
            while (!visit.Contains(q))
            {
                q = parentMap[q.val];
            }
            return q;
        }

        private void BuildParentMap(TreeNode root, TreeNode p, TreeNode q)
        {
            var treeStack = new Stack<TreeNode>();
            treeStack.Push(root);
            parentMap[root.val] = null;
            while (!parentMap.ContainsKey(p.val) || !parentMap.ContainsKey(q.val))
            {
                var currentNode = treeStack.Pop();
                if (currentNode.left != null)
                {
                    parentMap[currentNode.left.val] = currentNode;
                    treeStack.Push(currentNode.left);
                }
                if (currentNode.right != null)
                {
                    parentMap[currentNode.right.val] = currentNode;
                    treeStack.Push(currentNode.right);
                }
            }
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
    }
}
