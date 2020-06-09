
namespace GraphClassLibrary
{
    public class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }
        public decimal Weight { get; set; }
        public Edge(Vertex from, Vertex to, decimal weight)
        {
            //TODO: check coming data for class (EDGE).
            From = from;
            To = to;
            Weight = weight;
        }
        public Edge(Vertex from, decimal weight)
        {
            //TODO: check coming data for class (EDGE).
            From = from;
            To = null;
            Weight = weight;
        }
        public Edge(Vertex from, Vertex to)
        {
            //TODO: check coming data for class (EDGE).
            From = from;
            To = to;
            Weight = 0;
        }
        public Edge()
        {
        }
        public override string ToString()
        {
            return $"From[{From}] - To[{To}] Weight:{Weight}";
        }
    }
}
