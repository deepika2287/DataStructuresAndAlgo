// See https://aka.ms/new-console-template for more information
 
public class Solution {
    public static void Main(string[] args)
    {
        TreeNode n1 = new TreeNode(1);
        TreeNode n2 = new TreeNode(2);
        TreeNode n3 = new TreeNode(3);
        TreeNode n4 = new TreeNode(4);
        TreeNode n5 = new TreeNode(5);
        TreeNode n6 = new TreeNode(6);
        n1.left = n2;
        n1.right = n3;
        n2.left = n4;
        n2.right = n5;
        n3.left = n6;
        int res = new Solution().CountNodes(n1);
    }
    public int CountNodes(TreeNode root) {
        int h = FindHeight(root);
        int left = 0;
        int right = (int)Math.Pow(2,h-1)-1;
        int pivot;
        while(left<=right)
        {
            pivot = left + (right-left)/2;
            if(Exists(pivot,h,root))
                left = pivot+1;
            else
                right = pivot-1;
        }
        return (int)Math.Pow(2,h-1)-1+left;
    }
    public bool Exists(int idx,int h, TreeNode root)
    {
        int left = 0;
        int right = (int)Math.Pow(2,h-1)-1;
        int pivot = left + (right-left)/2;
        for(int i = 0;i<h-1;i++)
        {
            if(idx<=pivot)
            {
                root = root.left;
                right = pivot;
            }
            else
            {
                root = root.right;
                left = pivot+1;
            }
        }
        return root!=null;
    }
    public int FindHeight(TreeNode root)
    {
        if(root ==  null) return 0;
        int h = 0;
        while(root!=null)
        {
            root = root.left;
            h++;
        }
        return h;
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