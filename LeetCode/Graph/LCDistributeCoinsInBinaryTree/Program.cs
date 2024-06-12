namespace LCDistributeCoinsInBinaryTree;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
    int maxMoves = 0;
    public int DistributeCoins(TreeNode root) {
        DFS(root);
        return maxMoves;
    }

    public int DFS(TreeNode root)
    {        
        if(root == null)
        {
            return 0;
        }

        int leftCoins = DFS(root.left);
        int rightCoins = DFS(root.right);

        maxMoves = maxMoves + Math.Abs(leftCoins) + Math.Abs(rightCoins);

        return (root.val-1) + leftCoins + rightCoins;
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
