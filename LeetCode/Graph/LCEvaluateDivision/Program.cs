using System;
using System.Collections.Generic;
using System.Linq;

namespace LCEvaluateDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IList<IList<string>> equations = new List<IList<string>>();//(["a","b"],["b","c"]);
            equations.Add(new List<string>(){"a","b"});
            equations.Add(new List<string>(){"b","c"});
            double[] values = new double[2]{2.0,3.0};
            IList<IList<string>> queries = new List<IList<string>>();
            //[["a","c"],["b","a"],["a","e"],["a","a"],["x","x"]];
            queries.Add(new List<string>(){"a","c"});
            queries.Add(new List<string>(){"b","a"});
            queries.Add(new List<string>(){"a","e"});
            queries.Add(new List<string>(){"a","a"});
            queries.Add(new List<string>(){"x","x"});
            var res = new Program().CalcEquation(equations,values,queries);
        }
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
            double[] result = new double[queries.Count];
            //create graph
            Dictionary<string,GraphNode> graph = new Dictionary<string,GraphNode>();
            for(int i = 0;i<equations.Count;i++)
            {
                IList<string> equation = equations[i];
                string dividend = equation[0];
                string divisor = equation[1];
                double quotient = values[i];
                GraphNode n1;
                GraphNode n2;
                if(!graph.ContainsKey(dividend))
                {
                    n1 = new GraphNode();
                    n1.value = dividend;
                    n1.adjacencyList = new List<(GraphNode,double)>();
                    graph.Add(n1.value,n1);
                }
                else
                {
                    n1 = graph[dividend];
                }
                if(!graph.ContainsKey(divisor))
                {
                    n2 = new GraphNode();
                    n2.value = divisor;
                    n2.adjacencyList = new List<(GraphNode, double)>();
                    graph.Add(n2.value,n2);
                }
                else
                {
                    n2 = graph[divisor];
                }
                n1.adjacencyList.Add((n2,quotient));
                n2.adjacencyList.Add((n1,1/quotient));
            }
            //traverse graph
            for(int i = 0;i<queries.Count;i++)
            {
                IList<string> query = queries[i];
                string source = query[0];
                string destination = query[1];
                double res;
                if(!graph.ContainsKey(source) || !graph.ContainsKey(destination))
                {
                    res = -1.0;
                }
                else if(source == destination)
                {
                    res = 1.0;
                }
                else
                {
                    Dictionary<string,bool> visited = new Dictionary<string, bool>();
                    foreach(var n in graph)
                    {
                        visited.Add(n.Key,false);
                    }
                    res = DFS(graph,source,destination,1,visited);
                }
                result[i] = res;
            }
            return result;
        }
        public double DFS(Dictionary<string,GraphNode> graph,string source,string dest,double multiplier,Dictionary<string,bool> visited)
        {
            if(source == dest)
            {
                return multiplier;
            }
            double ret = -1.0;
            visited[source] = true;
            List<(GraphNode,double)> adj = graph[source].adjacencyList;
            
            for(int i = 0;i<adj.Count;i++)
            {
                if(!visited[adj[i].Item1.value])
                    ret = DFS(graph,adj[i].Item1.value,dest,multiplier*adj[i].Item2,visited);
                if(ret != -1)
                    break;
            }
            visited[source] = false;
            return ret;
        }

        public class GraphNode
        {
            public List<(GraphNode,double)> adjacencyList;
            public string value;
        }
    }
}
