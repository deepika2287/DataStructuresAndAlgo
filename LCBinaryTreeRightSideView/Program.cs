using System;
using System.Collections.Generic;

namespace LCBinaryTreeRightSideView
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TreeNode n1 = new TreeNode(4);
            TreeNode n2 = new TreeNode(9);
            TreeNode n3 = new TreeNode(0);
            TreeNode n4 = new TreeNode(5);
            TreeNode n5 = new TreeNode(1);
            n1.left = n2;
            n1.right = n3;
            n2.left = n4;
            n2.right = n5;
            var res = new Program().RightSideView(n1);
        }
        public IList<int> RightSideView(TreeNode root) {
            IList<int> result = new List<int>();
            Queue<(TreeNode,int)> queue = new Queue<(TreeNode, int)>();
            queue.Enqueue((root,1));
            while(queue.Count>0)
            {
                var node = queue.Dequeue();
                if(node.Item2 == 1)
                {
                    result.Add(node.Item1.val);
                }
                else
                {
                    if(queue.Count > 0)
                    {
                        var temp = queue.Peek();
                        if(temp.Item2 > node.Item2)
                        {
                            result.Add(node.Item1.val);
                        }
                    }
                    else
                    {
                        result.Add(node.Item1.val);
                    }
                }
                if(node.Item1.left != null)
                {
                    queue.Enqueue((node.Item1.left,node.Item2+1));
                }
                if(node.Item1.right != null)
                {
                    queue.Enqueue((node.Item1.right,node.Item2+1));
                }
            }
            return result;
        }
    }
    public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
}
