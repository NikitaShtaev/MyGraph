﻿
using GraphClassLibrary.Model;
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
            foreach (var edge in Edges)
            {
                matrix[edge.From.Number, edge.To.Number] = edge.Weight;
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
            if (CheckingEdge.To == CheckingVertex)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Returns List of edges that connected to current vertex.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        private List<Edge> GetConnectedEdges(Vertex vertex)
        {
            var result = new List<Edge>();
            foreach (var edge in Edges)
            {
                if (CheckVertexInEdge(edge, vertex))
                {
                    result.Add(edge);
                }
            }
            return result;
        }
        /// <summary>
        /// Returns maximum possible value for way length.
        /// </summary>
        /// <returns></returns>
        private decimal GetMaxLength()
        {
            decimal max = 0;
            foreach (var item in Edges)
            {
                max += item.Weight;
            }
            return max;
        }
        /// <summary>
        /// Changes numbers of vertexes in graph for search shortest way.
        /// </summary>
        /// <param name="number"></param>
        private void ChangeNumbers(int number)
        {
            foreach (var vertex in Vertexes)
            {
                if (vertex.Number - number >= 0)
                {
                    vertex.Number -= number;
                }
                else
                {
                    vertex.Number = CountVertexes - number;
                }
            }
        }
        /// <summary>
        /// Return numbers of vertexes back to initial values.
        /// </summary>
        private void ChangeNumbersBack()
        {
            foreach (var vertex in Vertexes)
            {
                vertex.Number = vertex.CopyNumber;
            }
        }
        /// <summary>
        /// Returns WAYINGRAPH CLASS for start and finish vertexes.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        private WayInGraph GetWay(Vertex start, Vertex finish)
        {
            var innerway = new WayInGraph(CountVertexes, GetMaxLength(), start, finish);
            ChangeNumbers(start.Number);
            foreach (var vertex in Vertexes)
            {
                foreach (var edge in GetConnectedEdges(vertex))
                {
                    if (innerway.MinWayWeights[edge.To.Number] > innerway.MinWayWeights[edge.From.Number] + edge.Weight)
                    {
                        innerway.MinWayWeights[edge.To.Number] = innerway.MinWayWeights[edge.From.Number] + edge.Weight;
                        innerway.PreviousVertexes[edge.To.Number] = edge.From;
                    }
                }
            }
            innerway.GetWayInGraph();
            ChangeNumbersBack();
            return innerway;
        }
        /// <summary>
        /// Returns WAY CLASS for user.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        private Way GetWayForUser(Vertex start, Vertex finish)
        {
            var innerway = new WayInGraph(CountVertexes, GetMaxLength(), start, finish);
            ChangeNumbers(start.Number);
            foreach (var vertex in Vertexes)
            {
                foreach (var edge in GetConnectedEdges(vertex))
                {
                    if (innerway.MinWayWeights[edge.To.Number] > innerway.MinWayWeights[edge.From.Number] + edge.Weight)
                    {
                        innerway.MinWayWeights[edge.To.Number] = innerway.MinWayWeights[edge.From.Number] + edge.Weight;
                        innerway.PreviousVertexes[edge.To.Number] = edge.From;
                    }
                }
            }
            var outway = innerway.GetWayForUser();
            ChangeNumbersBack();
            return outway;
        }
        /// <summary>
        /// Returns string with shortest way from start to finish if it exists.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public string GetWayFromToAsString(Vertex start, Vertex finish)
        {
            var outway = GetWayForUser(start, finish);
            return outway.ToString();
        }
        /// <summary>
        /// Returns shortest way from start to finish. Inside of way info about existance of way as bool.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public Way GetWayFromTo(Vertex start, Vertex finish)
        {
            var innerway = GetWay(start, finish);
            return innerway.GetWayForUser();
        }
        /// <summary>
        /// Override method ToString() for graph. Using private method GetGraphMatrix().
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// Adding edge to graph, if it still doesn't exist in graph. And adding vertexes FROM and TO if they still doesn't exist in graph. 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="weight"></param>
        public void AddEdge(Edge edge)
        {
            //TODO: check coming data to class MYGRAPH.
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
            for (var i = 0; i < CountVertexes; i++)
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
