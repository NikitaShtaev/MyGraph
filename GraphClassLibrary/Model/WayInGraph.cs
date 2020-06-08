
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
        public Vertex From { get; set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="maxWayLength"></param>
        public WayInGraph(int size, decimal maxWayLength, Vertex from)
        {
            MaxWayLength = maxWayLength;
            From = from;
            MinWayWeights = new decimal[size];
            PreviousVertexes = new Vertex[size];
            var v1 = new Vertex(0);
            PreviousVertexes[0] = v1;
            for (int i = 1; i < size; i++)
            {
                MinWayWeights[i] = maxWayLength;
                PreviousVertexes[i] = v1;
            }
        }
        /// <summary>
        /// Returns shortest way as List of vertexes.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <returns></returns>
        public List<Vertex> GetWayFromPreviousVertexes(Vertex start, Vertex finish)
        {
            var result = new List<Vertex>();
            var currentVertex = finish;
            while (currentVertex != start)
            {
                result.Add(currentVertex);
                currentVertex = PreviousVertexes[currentVertex.Number];
            }
            result.Add(start);
            result.Reverse();
            return result;
        }
        /// <summary>
        /// Override to string. Array of min weights.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = $"From[{From.CopyNumber}] - ";
            for (int i = 0; i < MinWayWeights.Length; i++)
            {
                if (MinWayWeights[i] != 0 && MinWayWeights[i] != MaxWayLength)
                result += $"To[{i}]:{MinWayWeights[i]} ";
            }
            return result;
        }
    }
}
