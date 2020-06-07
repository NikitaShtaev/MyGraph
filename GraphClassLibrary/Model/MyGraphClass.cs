
using GraphClassLibrary.Model;
using System;
using System.Collections.Generic;

namespace GraphClassLibrary
{
    public class MyGraphClass
    {
        /// <summary>
        /// Collection of vertexes in graph.
        /// </summary>
        private List<Vertex> Vertexes { get; set; }
        /// <summary>
        /// Collection of edges on graph.
        /// </summary>
        private List<Edge> Edges { get; set; }
        /// <summary>
        /// Quantity of vertexes in graph.
        /// </summary>
        private int CountVertexes => Vertexes.Count;
        /// <summary>
        /// Quantity of edges in graph.
        /// </summary>
        private int CountEdges => Edges.Count;
        /// <summary>
        /// Constructor with initialization of collections of vertexes and edges as new Lists.
        /// </summary>
        public MyGraphClass()
        {
            Vertexes = new List<Vertex>();
            Edges = new List<Edge>();
        }
        /// <summary>
        /// Generate graph as matrix.
        /// </summary>
        /// <returns></returns>
        private decimal[,] GetGraphMatrix()
        {
            var matrix = new decimal[CountVertexes, CountVertexes];
            for (int i = 0; i < CountVertexes; i++)
            {
                for (int j = 0; j < CountVertexes; j++)
                {
                    var checkVertex1 = new Vertex(i);
                    var checkVertex2 = new Vertex(j);
                    foreach (var edge in Edges)
                    {
                        if (edge.From == checkVertex1 && edge.To == checkVertex2)
                        {
                            matrix[i, j] = edge.Weight;
                        }
                        if (i == j)
                        {
                            matrix[i, j] = i;
                        }
                    }
                }
            }
            return matrix;
        }
        /// <summary>
        /// Adding new vertex if it still doesn't exist in graph. 
        /// </summary>
        /// <param name="newVertex"></param>
        private void AddVertex(Vertex newVertex)
        {
            if (!Vertexes.Contains(newVertex))
            {
                Vertexes.Add(newVertex);
            }
        }
        /// <summary>
        /// Checking if there is edge with vertex as vertex[edge.from].
        /// </summary>
        /// <param name="CheckingEdge"></param>
        /// <param name="CheckingVertex"></param>
        /// <returns></returns>
        private bool CheckVertexInEdge(Edge CheckingEdge, Vertex CheckingVertex)
        {
            if (CheckingEdge.From == CheckingVertex)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Returns Queue of vertexes that connected to current vertex.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        private Queue<Vertex> GetConnectedVertexes(Vertex vertex)
        {
            var result = new Queue<Vertex>();
            foreach (var edge in Edges)
            {
                if (CheckVertexInEdge(edge, vertex))
                {
                    result.Enqueue(edge.To);
                }
            }
            return result;
        }
        /// <summary>
        /// Returns Queue of edges that connected to current vertex.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        private Queue<Edge> GetConnectedEdges(Vertex vertex)
        {
            var result = new Queue<Edge>();
            foreach (var edge in Edges)
            {
                if (CheckVertexInEdge(edge, vertex))
                {
                    result.Enqueue(edge);
                }
            }
            return result;
        }
        /// <summary>
        /// Adding edge to graph, if it still doesn't exist in graph. And adding vertexes FROM and TO if they still doesn't exist in graph. 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="weight"></param>
        public void AddEdge(Edge edge)
        {
            if (!Edges.Contains(edge))
            {
                Edges.Add(edge);
            }
            AddVertex(edge.From);
            AddVertex(edge.To);
        }
        /// <summary>
        /// Return string with all vertexes in graph.
        /// </summary>
        /// <returns></returns>
        public string GetVertexesAsString()
        {
            var result = "";
            for(var i =0; i < CountVertexes; i++)
            {
                result += $"[{i}]:{Vertexes[i]}\n";
            }
            return result;
        }
        /// <summary>
        /// Return string with all edges in graph.
        /// </summary>
        /// <returns></returns>
        public string GetEdgesAsString()
        {
            var result = "";
            for (var i = 0; i < CountEdges; i++)
            {
                result += $"[{i}]:{Edges[i]}\n";
            }
            return result;
        }
        /// <summary>
        /// Override method ToString() for graph. Using private method GetGraphMatrix().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = "";
            var matrix = GetGraphMatrix();
            for (int i = 0; i < CountVertexes; i++)
            {
                for (int j = 0; j < CountVertexes; j++)
                {
                    result += $"{matrix[i, j]} ";
                }
                result += $"\n";
            }
            return result;
        }

    }
}
