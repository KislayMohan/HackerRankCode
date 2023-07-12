using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankCode
{
    public class LinklistCycleDetection
    {
        static bool hasCycle(SinglyLinkedListNode head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }
            var fastNode = head;
            var slowNode = head;
            while (fastNode != null && fastNode.next != null)
            {
                slowNode = slowNode.next;
                fastNode = fastNode.next.next;
                if (slowNode == fastNode)
                {
                    return true;
                }
            }
            return false;
        }

        public class SinglyLinkedListNode
        {
            public int data { get; set; }
            public SinglyLinkedListNode next { get; set; }
        }

        public static void GraphIntersection()
        {
            var dag = new List<List<string>>();
            var paths= new List<List<string>>();
            var input = Console.ReadLine();
            while (input != null && !string.IsNullOrEmpty(input))
            {
                if (input.Contains("->"))
                {
                    var data = input.Split("->");
                    dag.Add(new List<string> { data[0], data[1] });
                }
                else if (input.Contains(","))
                {
                    var route = input.Split(",");
                    paths.Add(route.ToList());
                }
                input = Console.ReadLine();
            }

            var graph = GetGraph(dag);

            foreach (var path in paths)
            {
                DoLinkListIntersect(graph, path);
            }
        }

        private static List<List<string>> GetGraph(List<List<string>> dag)
        {
            var graphs = new List<List<string>>();
            foreach (var link in dag)
            {
                if (graphs.Count == 0)
                {
                    graphs.Add(new List<string> { link[0], link[1] });
                }
                else
                {
                    for (int i = 0; i < graphs.Count(); i++)
                    {
                        if (graphs[i][graphs[i].Count() - 1] == link[0])
                        {
                            if (graphs[i].Contains(link[1]))
                            {
                                throw new Exception("Error Thrown");
                            }
                            var tempGraph = new List<string>(graphs[i]).Append(link[1]).ToList();
                            graphs[i] = tempGraph;
                        }
                        else
                        {
                            graphs.Add(new List<string> { link[0], link[1] });
                        }
                    }
                }
            }

            return graphs;
        }

        private static bool DoLinkListIntersect(List<List<string>> graphs, List<string> path)
        {
            
            var routes = new List<List<string>>();
            var totalLength = 0;
            foreach (var node in path)
            {
                for (int i = 0; i < graphs.Count(); i++)
                {
                    if (graphs[i][0] == node)
                    {
                        routes.Add(graphs[i]);
                        totalLength += graphs[i].Count();
                    }
                }
            }
            var finalPath = new List<string>();
            foreach (var route in routes)
            {
                finalPath.Union(route);
            }
            return finalPath.Count() == totalLength;
        }
    }
}
