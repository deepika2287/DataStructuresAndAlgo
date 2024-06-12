using System;
using System.Collections;
using System.Collections.Generic;

namespace LCInvertTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TreeNode t1 = new TreeNode(1);
            TreeNode t2 = new TreeNode(2);
            TreeNode t3 = new TreeNode(3);
            TreeNode t4 = new TreeNode(4);
            TreeNode t5 = new TreeNode(5);
            TreeNode t6 = new TreeNode(6);
            TreeNode t7 = new TreeNode(7);

            t1.left = t2;
            t1.right = t3;

            t2.left = t4;
            t2.right = t5;

            t3.left = t6;
            t3.right = t7;

            TreeNode root= new Program().InvertTree(t1);
        }
        public TreeNode InvertTree(TreeNode root) {
            if(root == null)
                return null;
                
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode temp = root;
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                TreeNode t = queue.Dequeue();
                TreeNode t1 = t.left;
                t.left = t.right;
                t.right = t1;
                if(t.left !=null)
                queue.Enqueue(t.left);
                if(t.right!=null)
                queue.Enqueue(t.right);
            }
            return root;
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
