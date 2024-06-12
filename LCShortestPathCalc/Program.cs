public class Solution
{
    public static void Main(string[] args)
    {
        Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
        int idx = graph.Keys.ToList().IndexOf('c');
        
        string[] commands = ["Graph","shortestPath","shortestPath","shortestPath","shortestPath","addEdge","shortestPath","addEdge","shortestPath","shortestPath","addEdge","addEdge","shortestPath","addEdge","addEdge","addEdge","addEdge","shortestPath","shortestPath","addEdge","addEdge","shortestPath","addEdge","addEdge","addEdge","shortestPath","addEdge","shortestPath","shortestPath","shortestPath","shortestPath","addEdge","addEdge"];
        int numEdges = 6;
        int[][] edges = [[3,5,990551],[1,3,495721],[0,1,985797],[4,5,422863],[4,1,505663]];
        Graph g = new Graph(numEdges,edges);
        Console.WriteLine(g.ShortestPath(0,1));
        Console.WriteLine(g.ShortestPath(3,5));
        Console.WriteLine(g.ShortestPath(4,4));
        Console.WriteLine(g.ShortestPath(0,3));
        g.AddEdge(new int[]{5,0,250117});
        Console.WriteLine(g.ShortestPath(4,5));
        g.AddEdge(new int[]{3,1,142005});
        Console.WriteLine(g.ShortestPath(2,2));
        Console.WriteLine(g.ShortestPath(4,0));
        g.AddEdge(new int[]{2,0,124744});
        g.AddEdge(new int[]{5,1,74396});
        Console.WriteLine(g.ShortestPath(3,3));
        //[0,1],[3,5],[4,4],[0,3],[[5,0,250117]],[4,5],[[3,1,142005]],[2,2],[4,0],[[2,0,124744]],[[5,1,74396]],[3,3],[[3,2,571238]],[[1,4,3408]],[[0,4,832]],[[5,2,417]],[2,2],[2,4],[[2,3,80]],[[5,4,6]],[3,4],[[4,3,837171]],[[1,2,162278]],[[3,4,1]],[2,0],[[0,3,1]],[0,4],[3,5],[1,1],[3,4],[[4,2,1]],[[2,1,1]];
    }
}
public class Graph {
    int[][] graph;
    int N;
    public Graph(int n, int[][] edges) {
        N = n;
        graph = new int[n][];
        for(int i = 0;i<n;i++)
        {
            graph[i] = new int[n];
        }
        int numEdges = edges.Length;
        for(int i =0;i<numEdges;i++)
        {
            int src = edges[i][0];
            int dest = edges[i][1];
            int weight = edges[i][2];
            graph[src][dest] = weight;
        }
    }
    
    public void AddEdge(int[] edge) {
        int row = edge[0];
        int col = edge[1];
        int weight = edge[2];
        graph[row][col] = weight;
    }
    
    public int ShortestPath(int node1, int node2) {
        if(node1 == node2)
            return 0;
        bool[] visited = new bool[N];
        int[] dist = new int[N];
        for(int i = 0;i<N;i++)
        {
            dist[i] = int.MaxValue;
        }
        dist[node1] = 0;
        for(int i = 0;i<N-1;i++)
        {
            int src = FindMinDistNode(dist,visited);
            if(src != -1)
            {
            visited[src] = true;
            for(int j = 0;j<N;j++)
            {
                if(!visited[j] && graph[src][j] != 0 && dist[src]!=int.MaxValue &&
                            dist[src] + graph[src][j] < dist[j])
                            {
                                dist[j] = dist[src] + graph[src][j];
                            }
            }
            }
        }
        return dist[node2] == int.MaxValue ? -1 : dist[node2];
    }
    public int FindMinDistNode(int[] dist,bool[] visited)
    {
        int min = int.MaxValue;
        int minIdx = -1;
        for(int i = 0;i<N;i++)
        {
            if(!visited[i])
            {
                if(min>dist[i])
                {
                    min = dist[i];
                    minIdx = i;
                }
            }
        }
        return minIdx;
    }
}