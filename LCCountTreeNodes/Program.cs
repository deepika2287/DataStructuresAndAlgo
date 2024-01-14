using System;
using System.Collections.Generic;
namespace LCCountTreeNodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TreeNode n1 = new TreeNode(5);
            TreeNode n2 = new TreeNode(4);
            TreeNode n3 = new TreeNode(8);
            TreeNode n4 = new TreeNode(11);
            TreeNode n5 = new TreeNode(13);
            TreeNode n6 = new TreeNode(4);
            TreeNode n7 = new TreeNode(7);
            TreeNode n8 = new TreeNode(2);
            TreeNode n9 = new TreeNode(1);

            n1.left = n2;
            n1.right = n3;

            n2.left = n4;

            n3.left = n5;
            n3.right = n6;

            n4.left = n7;
            n4.right = n8;

            n6.right = n9;

            bool res = new Program().HasPathSum(n1,26);

        }
        public bool HasPathSum(TreeNode root, int targetSum) {
            bool result = DFS(root,targetSum,root.val);
            return result;
        }
        public bool DFS(TreeNode root, int targetSum,int sum)
        {
            if(sum == targetSum && root.left == null && root.right == null)
            {
                return true;
            }
            
            bool res = false;
            if(root.left != null)
            res = DFS(root.left,targetSum,root.left.val+sum);

            if(!res && root.right!=null)
                res = DFS(root.right,targetSum,root.right.val+sum);

            return res;
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
}
