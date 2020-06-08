﻿using GraphClassLibrary;
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
            var v6 = new Vertex(6);
            var v7 = new Vertex(7);
            var v8 = new Vertex(8);

            //AddTwoWayEdgeToGraph(graph, v0, v1, 7); //1
            //AddTwoWayEdgeToGraph(graph, v0, v2, 1); //2
            //AddTwoWayEdgeToGraph(graph, v0, v3, 4); //3
            //AddTwoWayEdgeToGraph(graph, v1, v4, 8); //4
            //AddTwoWayEdgeToGraph(graph, v1, v2, 1); //5
            //AddTwoWayEdgeToGraph(graph, v2, v4, 7); //6
            //AddTwoWayEdgeToGraph(graph, v2, v5, 6); //7
            //AddTwoWayEdgeToGraph(graph, v3, v6, 5); //8
            //AddTwoWayEdgeToGraph(graph, v4, v7, 3); //9
            //AddTwoWayEdgeToGraph(graph, v4, v5, 2); //10
            //AddTwoWayEdgeToGraph(graph, v5, v6, 4); //11
            //AddTwoWayEdgeToGraph(graph, v6, v8, 7); //12
            //AddTwoWayEdgeToGraph(graph, v5, v3, 3); //13
            //AddTwoWayEdgeToGraph(graph, v5, v7, 1); //14
            //AddTwoWayEdgeToGraph(graph, v2, v6, 2); //15

            AddOneWayEdgeToGraph(graph, v0, v1, 7); //1
            AddOneWayEdgeToGraph(graph, v0, v2, 1); //2
            AddOneWayEdgeToGraph(graph, v0, v3, 4); //3
            AddOneWayEdgeToGraph(graph, v1, v4, 8); //4
            AddOneWayEdgeToGraph(graph, v1, v2, 1); //5
            AddOneWayEdgeToGraph(graph, v2, v4, 7); //6
            AddOneWayEdgeToGraph(graph, v2, v5, 6); //7
            AddOneWayEdgeToGraph(graph, v3, v6, 5); //8
            AddOneWayEdgeToGraph(graph, v4, v7, 3); //9
            AddOneWayEdgeToGraph(graph, v4, v5, 2); //10
            AddOneWayEdgeToGraph(graph, v5, v6, 4); //11
            AddOneWayEdgeToGraph(graph, v6, v8, 7); //12
            AddOneWayEdgeToGraph(graph, v5, v3, 3); //13
            AddOneWayEdgeToGraph(graph, v5, v7, 1); //14
            AddOneWayEdgeToGraph(graph, v2, v6, 2); //15

            Console.WriteLine(graph.GetVertexesAsString());
            Console.WriteLine(graph.GetEdgesAsString());
            Console.WriteLine(graph);

            Console.WriteLine(graph.GetWaysFromHead());
            Console.WriteLine(graph.GetWayFromTo(v1, v7));
            Console.WriteLine(graph.GetWaysSpecial(v1));
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
