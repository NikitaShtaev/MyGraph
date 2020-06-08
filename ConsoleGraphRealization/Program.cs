using GraphClassLibrary;
using System;

namespace ConsoleGraphRealization
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new MyGraphClass();

            var v0 = new Vertex(0);
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);
            var v4 = new Vertex(4);
            var v5 = new Vertex(5);

            AddOneWayEdgeToGraph(graph, v0, v1, 4); //1
            AddOneWayEdgeToGraph(graph, v1, v0, 4); //2
            AddOneWayEdgeToGraph(graph, v0, v2, 3); //1
            AddOneWayEdgeToGraph(graph, v0, v3, 1); //3
            AddOneWayEdgeToGraph(graph, v1, v2, 6); //4
            AddOneWayEdgeToGraph(graph, v2, v4, 3); //5
            AddOneWayEdgeToGraph(graph, v2, v5, 1); //6
            AddOneWayEdgeToGraph(graph, v3, v4, 1); //7
            AddOneWayEdgeToGraph(graph, v4, v5, 1); //8
            AddOneWayEdgeToGraph(graph, v5, v4, 4); //9

            Console.WriteLine(graph.GetVertexesAsString());
            Console.WriteLine(graph.GetEdgesAsString());
            Console.WriteLine(graph);

            Console.WriteLine("=====================");
            Console.WriteLine(graph.GetWayFromTo(v0, v5));
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
    }
}
