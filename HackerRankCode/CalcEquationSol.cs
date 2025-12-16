using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankCode
{
    internal class CalcEquationSol
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            Dictionary<string, Dictionary<string, double>> graph = new Dictionary<string, Dictionary<string, double>>();
            for (int i = 0; i < equations.Count; i++)
            {
                string a = equations[i][0];
                string b = equations[i][1];
                double value = values[i];
                if (!graph.ContainsKey(a))
                    graph[a] = new Dictionary<string, double>();
                if (!graph.ContainsKey(b))
                    graph[b] = new Dictionary<string, double>();
                graph[a][b] = value;
                graph[b][a] = 1.0 / value;
            }
            double[] results = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                string start = queries[i][0];
                string end = queries[i][1];
                HashSet<string> visited = new HashSet<string>();
                results[i] = Dfs(graph, start, end, visited);
            }
            return results;
        }

        private double Dfs(Dictionary<string, Dictionary<string, double>> graph, string start, string end, HashSet<string> visited)
        {
            if (!graph.ContainsKey(start) || !graph.ContainsKey(end))
                return -1.0;
            if (start == end)
                return 1.0;
            visited.Add(start);
            foreach (var neighbor in graph[start])
            {
                if (!visited.Contains(neighbor.Key))
                {
                    double product = Dfs(graph, neighbor.Key, end, visited);
                    if (product != -1.0)
                    {
                        return neighbor.Value * product;
                    }
                }
            }
            return -1.0;
        }
    }
}
