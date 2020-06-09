
using GraphClassLibrary.Model;
using System.Collections.Generic;

namespace GraphClassLibrary
{
    public class MyGraphClass
    {
        /// <summary>
        /// Collection of vertexes in graph.
        /// </summary>
        private List<Vertex> Vertexes { get; }
        /// <summary>
        /// Collection of edges on graph.
        /// </summary>
        private List<Edge> Edges { get; }
        /// <summary>
        /// Quantity of vertexes in graph.
        /// </summary>
        private int CountVertexes => Vertexes.Count;
        /// <summary>
        /// Quantity of edges in graph.
        /// </summary>
        private int CountEdges => Edges.Count;
        private decimal MaxLength { get; set; }
        public AllShortestWaysInGraph AllShortestWays { get; set; }
        /// <summary>
        /// Constructor with initialization of collections of vertexes and edges as new Lists.
        /// </summary>
        public MyGraphClass()
        {
            Vertexes = new List<Vertex>();
            Edges = new List<Edge>();
            MaxLength = 0;
        }
        /// <summary>
        /// Constructor with parameter [List of edges].
        /// </summary>
        /// <param name="edges"></param>
        public MyGraphClass(List<Edge> edges)
        {
            Vertexes = new List<Vertex>();
            Edges = new List<Edge>();
            foreach (var edge in edges)
            {
                if (!Edges.Contains(edge))
                {
                    Edges.Add(edge);
                }
                AddVertex(edge.From);
                AddVertex(edge.To);
                MaxLength += edge.Weight;
            }
            AllShortestWays = HelpGetAllShortestWays(); 
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
            if (CheckingEdge.To == CheckingVertex || CheckingEdge.From == CheckingVertex)
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
        /// Changes numbers of vertexes in graph for search shortest way.
        /// </summary>
        /// <param name="number"></param>
        private void ChangeNumbers(int number)
        {
            //foreach (var vertex in Vertexes)
            //{
            //    if (vertex.Number - number >= 0)
            //    {
            //        vertex.Number -= number;
            //    }
            //    else
            //    {
            //        vertex.Number = CountVertexes - number;
            //        //vertex.Number = Math.Abs(vertex.Number - number);
            //    }
            //}
            Vertexes[number].Number = 0;
            Vertexes[0].Number = number;
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
        /// Returns all shortest ways in graph.
        /// </summary>
        /// <returns></returns>
        private AllShortestWaysInGraph HelpGetAllShortestWays()
        {
            var allWays = new AllShortestWaysInGraph(CountVertexes);
            for (int i = 0; i < CountVertexes; i++)
            {
                for (int j = 0; j < CountVertexes; j++)
                {
                    if (i != j)
                    {
                        allWays.AddWay(HelpGetWay(Vertexes[i], Vertexes[j]), i, j);
                    }
                }
            }
            return allWays;
        }
        /// <summary>
        /// Returns WAY CLASS for start and finish vertexes.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        private Way HelpGetWay(Vertex start, Vertex finish)
        {
            var innerway = new WayInGraph(CountVertexes, MaxLength, start, finish);
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
        /// Returns shortest way from start to finish through needed vertex.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <param name="trough"></param>
        /// <returns></returns>        
        public Way GetWayFromToThrough(Vertex start, Vertex finish, Vertex trough)
        {
            var outway = AllShortestWays.AllWays[start.Number, trough.Number];
            outway.IncludeWay(AllShortestWays.AllWays[trough.Number, finish.Number]);
            return outway;
        }
        /// <summary>
        /// Returns all shortest ways in graph.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public Way GetWay(Vertex start, Vertex finish)
        {
            return AllShortestWays.AllWays[start.Number, finish.Number];
        }
        public AllShortestWaysInGraph GetAllShortestWays()
        {
            return AllShortestWays;
        }
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
            MaxLength += edge.Weight;
            AllShortestWays = HelpGetAllShortestWays();
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
