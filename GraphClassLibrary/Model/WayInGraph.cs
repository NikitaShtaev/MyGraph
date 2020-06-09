
using System.Collections.Generic;

namespace GraphClassLibrary.Model
{
    public class WayInGraph
    {
        /// <summary>
        /// Previous vertexes for MinWayWeights for creation shortest way as List.
        /// </summary>
        public Vertex [] PreviousVertexes { get; set; }
        /// <summary>
        /// Algoritm of Deikstra array of MinWayWeights.
        /// </summary>
        public decimal [] MinWayWeights { get; set; }
        /// <summary>
        /// Maximum length for compare weights of graph. As sum of all existing weights.
        /// </summary>
        public decimal MaxWayLength { get; set; }
        /// <summary>
        /// Vertex where way started from.
        /// </summary>
        public Vertex Start { get; set; }
        /// <summary>
        /// Vertex where way finishes.
        /// </summary>
        public Vertex Finish { get; set; }
        /// <summary>
        /// Length of way in graph.
        /// </summary>
        public decimal WayLength { get; set; }
        /// <summary>
        /// List of vertexes that contains shortest way.
        /// </summary>
        public List<Vertex> ShortestWay { get; set; }
        /// <summary>
        /// Separately WAY class for user.
        /// </summary>
        private Way NewWay { get; set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="maxWayLength"></param>
        public WayInGraph(int size, decimal maxWayLength, Vertex start, Vertex finish)
        {
            //TODO: check coming data to class WAYINGRAPH.
            MaxWayLength = maxWayLength;
            Start = start;
            Finish = finish;
            MinWayWeights = new decimal[size];
            PreviousVertexes = new Vertex[size];
            ShortestWay = new List<Vertex>();
            NewWay = new Way();
            var v1 = new Vertex(0);
            PreviousVertexes[0] = v1;
            MinWayWeights[0] = 0;
            for (int i = 1; i < size; i++)
            {
                MinWayWeights[i] = maxWayLength;
                PreviousVertexes[i] = v1;
            }
        }
        /// <summary>
        /// Returns shortest way for user.
        /// </summary>
        /// <returns></returns>
        public Way GetWayForUser()
        {
            if (MinWayWeights[Finish.Number] == MaxWayLength)
            {
                NewWay.IsWay = false;
                NewWay.Vertexes = new List<Vertex>();
                NewWay.Length = MaxWayLength;
            }
            else
            {
                NewWay.IsWay = true;
                var currentVertex = Finish;
                while (currentVertex != Start)
                {
                    NewWay.Vertexes.Add(currentVertex);
                    currentVertex = PreviousVertexes[currentVertex.Number];
                }
                NewWay.Vertexes.Add(Start);
                NewWay.Vertexes.Reverse();
                NewWay.Length = MinWayWeights[Finish.Number];
            }
            return NewWay;
        }
        /// <summary>
        /// Arrange shortest way.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public void GetWayInGraph()
        {
            var currentVertex = Finish;
            while (currentVertex != Start)
            {
                ShortestWay.Add(currentVertex);
                currentVertex = PreviousVertexes[currentVertex.Number];
            }
            ShortestWay.Add(Start);
            ShortestWay.Reverse();
            WayLength = MinWayWeights[Finish.Number];
        }
        /// <summary>
        /// Override to string. Array of min weights.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //TODO: reapir [ToString()] for WAYINGRAPH class. (ChangeNumbersBack problem).
            var result = $"From[{Start.CopyNumber}] - ";
            for (int i = 0; i < MinWayWeights.Length; i++)
            {
                if (MinWayWeights[i] != 0 && MinWayWeights[i] != MaxWayLength)
                result += $"To[{i}]:{MinWayWeights[i]} ";
            }
            return result;
        }
    }
}
