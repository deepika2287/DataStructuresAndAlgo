using System;
using System.Collections.Generic;
namespace LCCourseSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[][] prerequisites = new int[2][];
            prerequisites[0] = new int[2]{1,0};
            prerequisites[1] = new int[2]{0,1};
            var res = new Program().CanFinish(2,prerequisites);
        }
        public bool CanFinish(int numCourses, int[][] prerequisites) {
            Dictionary<int,List<int>> graph = new Dictionary<int, List<int>>();
            for(int i = 0;i<numCourses;i++)
            {
                graph.Add(i,new List<int>());
            }
            for(int i = 0;i<prerequisites.Length;i++)
            {
                int course1 = prerequisites[i][0];
                int course2 = prerequisites[i][1];

                graph[course2].Add(course1);
            }
            for(int i = 0;i<numCourses;i++)
            {
                bool[] visited = new bool[numCourses];
                bool[] inStack = new bool[numCourses];

                if(DFS(graph,visited,inStack,i))
                    return false;
            }
            return true;
        }
                //bool[] visited = new bool[numCourses];
        public bool DFS(Dictionary<int,List<int>> graph,bool[] visited,bool[] inStack, int node)
        {
             if(inStack[node])
                return true;
            if(visited[node])
                return false;

            visited[node] = true;
            inStack[node] = true;
            List<int> neighbours = graph[node];
            foreach(var n in neighbours)
            {
                if(DFS(graph,visited,inStack,n))
                    return true;
            }
            //visited[node] = false;
            inStack[node] = false;

            return false;
        }
    }
}
