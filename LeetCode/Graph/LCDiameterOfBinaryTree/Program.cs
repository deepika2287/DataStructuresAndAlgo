using System;

namespace LCDiameterOfBinaryTree
{
    class Program
    {
        public int maxSum = Int32.MinValue;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int DiameterOfBinaryTree(TreeNode root) {
            DFS(root);
            return maxSum;
        }
        public int DFS(TreeNode root)
        {
            if(root == null)
            return 0;
            int leftPath = DFS(root.left);
            int rightPath = DFS(root.right);
            
            maxSum = Math.Max(maxSum, leftPath + rightPath + root.val);

            return Math.Max(leftPath,rightPath) + root.val;
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
