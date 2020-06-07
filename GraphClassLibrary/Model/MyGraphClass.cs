
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
        /// Returns all shortest ways from current vertex till all others.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public WayInGraph GetWaysSpecial(Vertex start)
        {
            var way = new WayInGraph(CountVertexes, GetMaxLength());
            way.MinWayWeights[start.Number] = 0;
            for (int i = start.Number; i < CountVertexes; i++)
            {
                foreach (var edge in GetConnectedEdges(Vertexes[i], Edges))
                {
                    if (way.MinWayWeights[edge.To.Number] > way.MinWayWeights[edge.From.Number] + edge.Weight)
                    {
                        way.MinWayWeights[edge.To.Number] = way.MinWayWeights[edge.From.Number] + edge.Weight;
                    }
                }
            }
            return way;
        }
        /// <summary>
        /// Returns all shortest ways from head vertex till all others.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public WayInGraph GetWaysFromHead()
        {
            var way = new WayInGraph(CountVertexes, GetMaxLength());
            foreach (var vertex in Vertexes)
            {
                foreach (var edge in GetConnectedEdges(vertex, Edges))
                {
                    if (way.MinWayWeights[edge.To.Number] > way.MinWayWeights[edge.From.Number] + edge.Weight)
                    {
                        way.MinWayWeights[edge.To.Number] = way.MinWayWeights[edge.From.Number] + edge.Weight;
                    }
                }
            }
            return way;
        }
        /// <summary>
        /// Returns edge with min way from current list of edges.
        /// </summary>
        /// <param name="currentEdges"></param>
        /// <returns></returns>
        private Edge GetMinEdge(List<Edge> currentEdges)
        {
            var min = currentEdges[0];
            foreach (var edge in currentEdges)
            {
                if (edge.Weight < min.Weight)
                {
                    min = edge;
                }
            }
            return min;
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
                        //if (i == j)
                        //{
                        //    matrix[i, j] = i;
                        //}
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
        /// Returns List of vertexes that connected to current vertex.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        private List<Vertex> GetConnectedVertexes(Vertex vertex)
        {
            var result = new List<Vertex>();
            foreach (var edge in Edges)
            {
                if (CheckVertexInEdge(edge, vertex))
                {
                    result.Add(edge.To);
                }
            }
            return result;
        }
        /// <summary>
        /// Returns List of edges that connected to current vertex.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        private List<Edge> GetConnectedEdges(Vertex vertex, List<Edge> edges)
        {
            var result = new List<Edge>();
            foreach (var edge in edges)
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
    }
}
