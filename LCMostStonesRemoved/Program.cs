// See https://aka.ms/new-console-template for more information
public class Solution {
    public static void Main(string[] args)
    {
        int[][] stones = [[0,0],[0,1],[1,0],[1,2],[2,1],[2,2]];
        int res = new Solution().RemoveStones(stones);
    }
    public int RemoveStones(int[][] stones) {
        List<Node> graph = new List<Node>();
        for(int i = 0;i<stones.Length;i++)
        {
            int[] arr = stones[i];
            Node node = new Node(arr[0],arr[1]);
            graph.Add(node);
            foreach(Node n in graph)
            {
                if(n.x != node.x || n.y != node.y)
                {
                    if(n.x == node.x || n.y == node.y)
                    {
                        n.neighbours.Add(node);
                        node.neighbours.Add(n);
                    }
                }
            }
        }
        List<Node> visited = new List<Node>();
        int componentCount = 0;
        for(int i = 0;i<stones.Length;i++)
        {
            int[] arr = stones[i];
            Node n = graph.Where(a=>a.x==arr[0] && a.y==arr[1]).First();
            if(!visited.Contains(n))
            {
                componentCount++;
                DFS(graph,visited,n);
            }
        }
        return stones.Length - componentCount;
    }
    public void DFS(List<Node> graph,List<Node> visited, Node root)
    {
        visited.Add(root);
        foreach(Node n in root.neighbours)
        {
            if(!visited.Contains(n))
            {
                DFS(graph,visited,n);
            }
        }
    }
    public class Node
    {
        public int x;
        public int y;
        public List<Node> neighbours;
        public Node(int a, int b)
        {
            x = a;
            y = b;
            neighbours = new List<Node>();
        }
    }
}
