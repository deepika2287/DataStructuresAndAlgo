// See https://aka.ms/new-console-template for more informpublic class
public class Solution
{
    public static void Main(string[] args)
    {
        int[][] maze = [[0,0,1,0,0],[0,0,0,0,0],[0,0,0,1,0],[1,1,0,1,1],[0,0,0,0,0]];
        int[] start = new int[]{0,4};
        int[] destination = new int[]{4,4};
        int res = new Solution().ShortestDistance(maze,start,destination);
    }
    public int ShortestDistance(int[][] maze, int[] start, int[] destination) {
        int m = maze.Length;
        int n = maze[0].Length;

        int[][] visited = new int[m][];
        for(int i = 0;i<m;i++)
        {
            visited[i] = new int[n];
            for(int j = 0;j<n;j++)
            {
                visited[i][j] = int.MaxValue;
            }
        }

        Queue<Point> queue = new Queue<Point>();
        queue.Enqueue(new Point(start[0],start[1]));
        visited[start[0]][start[1]] = 0;
        while(queue.Count>0)
        {
            Point temp = queue.Dequeue();
            if(temp.x == destination[0] && temp.y == destination[1])
                return visited[temp.x][temp.y];

            int x = temp.x; int y = temp.y;
            int d = 0;
            //move up
            while(x>=0 && maze[x][y] != 1)
            {
                x--;
                d++;
            }    
            if(x+1>=0 && maze[x+1][y] == 0 && visited[temp.x][temp.y]+(d-1)<visited[x+1][y])
            {
                visited[x+1][y] = visited[temp.x][temp.y]+(d-1);
                queue.Enqueue(new Point(x+1,y));
            }
            //move down
            x = temp.x;
            d = 0;
            while(x<m && maze[x][y]!=1)
            {
                x++;
                d++;
            }
            if(x-1<m && maze[x-1][y] == 0 && visited[x-1][y]>visited[temp.x][temp.y]+(d-1))
            {
               visited[x-1][y] = visited[temp.x][temp.y]+(d-1);
                queue.Enqueue(new Point(x-1,y));
            }
            //move left
            x = temp.x; y = temp.y; d = 0;
            while(y>=0 && maze[x][y]!=1)
            {
                y--;
                d++;
            }
            if(y+1>=0 && maze[x][y+1] == 0 && visited[x][y+1]>visited[temp.x][temp.y]+(d-1))
            {
                visited[x][y+1] = visited[temp.x][temp.y]+(d-1);
                queue.Enqueue(new Point(x,y+1));
            }
            //move right
            y = temp.y; d = 0;
            while(y<n && maze[x][y]!=1)
            {
                y++;
                d++;
            }
            if(y-1<n && maze[x][y-1] == 0 && visited[x][y-1]>visited[temp.x][temp.y]+(d-1))
            {
                visited[x][y-1] = visited[temp.x][temp.y]+(d-1);
                queue.Enqueue(new Point(x,y-1));
            }
        }

        return -1;
    }
    public class Point
    {
        public int x;
        public int y;
        
        public Point(int i, int j)
        {
            x = i;
            y = j;
        }
    }
}