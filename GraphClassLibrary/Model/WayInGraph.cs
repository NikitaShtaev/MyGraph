
using System.Collections.Generic;

namespace GraphClassLibrary.Model
{
    public class WayInGraph
    {
        public Vertex [] PreviousVertexes { get; set; }
        public decimal [] MinWayWeights { get; set; }
        public decimal MaxWayLength { get; set; }
        public WayInGraph(int size, decimal maxWayLength)
        {
            MaxWayLength = maxWayLength;
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
        public override string ToString()
        {
            var result = "";
            for (int i = 0; i < MinWayWeights.Length; i++)
            {
                if (MinWayWeights[i] != 0 && MinWayWeights[i] != MaxWayLength)
                result += $"To[{i}]:{MinWayWeights[i]} ";
            }
            return result;
        }
    }
}
