
using System.Collections.Generic;

namespace GraphClassLibrary.Model
{
    public class WayInGraph
    {
        public Queue<Vertex> Way { get; set; }
        public decimal WayLength { get; set; }
        public WayInGraph()
        {
            Way = new Queue<Vertex>();
        }
        private void AddVertex (Vertex vertex)
        {
            if (!Way.Contains(vertex))
            {
                Way.Enqueue(vertex);
            }
        }
        public void IncreaseWay(Edge edge)
        {
            AddVertex(edge.From);
            AddVertex(edge.To);
            //Way.Add(edge.To);
            WayLength += edge.Weight;
        }
        public override string ToString()
        {
            var result = "";
            foreach (var vertex in Way)
            {
                result += $"{vertex} ";
            }
            return result;
        }
    }
}
