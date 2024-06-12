using System;

namespace LCMaxDepthOfBTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TreeNode n1 = new TreeNode(3);
            TreeNode n2 = new TreeNode(9);
            TreeNode n3 = new TreeNode(20);
            TreeNode n4 = new TreeNode(15);
            TreeNode n5 = new TreeNode(7);
            //TreeNode n6 = new TreeNode(3);
            n1.left = n2;
            n1.right = n3;
            n3.left = n4;
            //n3.right = n5;
            int dep = new Program().MaxDepth(n1);
        }
        public int MaxDepth(TreeNode root) {
            if(root == null)
            return 0;

            return FindDepth(root,1);
        }

        public int FindDepth(TreeNode root, int dep)
        {
            int leftdepth=dep;
            int rightdepth=dep;
            if(root.left != null)
            {
                leftdepth = FindDepth(root.left,dep+1);
            }
            if(root.right != null)
            {
                rightdepth = FindDepth(root.right,dep+1);
            }

            return Math.Max(leftdepth,rightdepth);
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
