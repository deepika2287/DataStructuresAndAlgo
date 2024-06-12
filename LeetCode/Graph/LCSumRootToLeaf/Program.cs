using System;
using System.Collections.Generic;

namespace LCSumRootToLeaf
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
            int sum = new Program().SumNumbers(n1);
        }
        public int SumNumbers(TreeNode root) {
            int sum = 0;
            List<string> nums = new List<string>();
            DFS(root,nums,root.val.ToString());
            foreach(string s in nums)
            {
                sum = sum + Convert.ToInt32(s);
            }
            return sum;
        }
        public void DFS(TreeNode root,List<string> nums,string s)
        {
            if(root.left == null & root.right == null)
            {
                nums.Add(s);
                return;
            }
            if(root.left != null)
            {
                DFS(root.left,nums,s+root.left.val.ToString());
            }
            if(root.right != null)
            {
                DFS(root.right,nums,s+root.right.val.ToString());
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
}
