
using System.Collections.Generic;

namespace GraphClassLibrary.Model
{
    public class Way
    {
        public List<Vertex> Vertexes { get; set; }
        public decimal Length { get; set; }
        public bool IsWay { get; set; }
        public Way(decimal Length, List<Vertex> vertexes)
        {
            this.Length = Length;
            if (vertexes.Count == 0)
            {
                IsWay = false;
                Vertexes = new List<Vertex>();
            }
            else
            {
                Vertexes = vertexes;
                IsWay = true;
            }
        }
        public Way()
        {
            Vertexes = new List<Vertex>();
        }
        public void IncludeWay(Way includingWay)
        {
            if (includingWay.IsWay)
            {
                Length += includingWay.Length;
                Vertexes.Remove(Vertexes[Vertexes.Count - 1]);
                Vertexes.AddRange(includingWay.Vertexes);
            }
            else
            {
                IsWay = false;
                Vertexes = new List<Vertex>();
            }
        }
        public override string ToString()
        {
            var result = "";
            if (IsWay)
            {
                result += $"From[{Vertexes[0]}] - To[{Vertexes[Vertexes.Count-1]}]: ";
                result += $"Length:{Length}; ";
                foreach (var vertex in Vertexes)
                {
                    result += $"-{vertex}-";
                }
            }
            else
            {
                result += $"No way";
            }
            return result;
        }
    }
}
