using GraphClassLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleGraphRealization
{
    class Program
    {
        static void Main(string[] args)
        {
            var v0 = new Vertex(0);
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);

            var lst = new List<Edge>();

            AddToEdgeList(lst, v0, v1, 1); //1
            AddToEdgeList(lst, v0, v2, 2); //2
            AddToEdgeList(lst, v1, v3, 1); //3
            AddToEdgeList(lst, v1, v2, 4); //4
            AddToEdgeList(lst, v2, v3, 2); //5
            AddToEdgeList(lst, v3, v2, 2); //6

            var graph = new MyGraphClass(lst);
            Console.WriteLine(graph.GetWay(v1, v3));
            Console.WriteLine(graph.GetEdgesAsString());
            //graph.WriteGraph("TestGraph.json");
            var graph2 = new MyGraphClass();
            graph2 = graph2.ReadGraph("TestGraph.json");
            Console.WriteLine(graph2.GetEdgesAsString());
            Console.WriteLine(graph2.GetWay(v1, v3));
            Console.ReadLine();
        }
        static void AddTwoWayEdgeToGraph(MyGraphClass graph, Vertex v1, Vertex v2, int weight)
        {
            graph.AddEdge(new Edge(v1, v2, weight));
            graph.AddEdge(new Edge(v2, v1, weight));
        }
        static void AddOneWayEdgeToGraph(MyGraphClass graph, Vertex v1, Vertex v2, int weight)
        {
            graph.AddEdge(new Edge(v1, v2, weight));
        }
        static void AddToEdgeList(List<Edge> lst, Vertex v1, Vertex v2, int weight)
        {
            lst.Add(new Edge(v1, v2, weight));
        }
    }
}
