using System;
using System.Collections.Generic;

namespace ConstructBinaryTree
{
    class Program
    {
        public int postIdx;
        public Dictionary<int,int> dict;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] inorder = new int[]{9,3,15,20,7};
            int[] postorder = new int[]{9,15,7,20,3};
            var root = new Program().BuildTree(inorder,postorder);
        }
        public TreeNode BuildTree(int[] inorder, int[] postorder) {
            TreeNode root;
            postIdx = postorder.Length-1;
            //root.val = postorder[postIdx];
            dict = new Dictionary<int, int>();
            for(int i = 0;i<inorder.Length;i++)
            {
                dict.Add(inorder[i],i);
            }
            
            root = ConstructBinaryTree(inorder,postorder,0,postIdx);
            return root;
        }
        public TreeNode ConstructBinaryTree(int[] inorder,int[] postorder,int startIdx, int endIdx)
        {
            if(startIdx>endIdx)
                return null;

            int rootVal = postorder[postIdx];
            TreeNode root = new TreeNode(rootVal);
            int idx = dict[rootVal];
            postIdx--;
            
            root.right = ConstructBinaryTree(inorder,postorder,idx+1,endIdx);
            root.left = ConstructBinaryTree(inorder,postorder,startIdx,idx-1);

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
