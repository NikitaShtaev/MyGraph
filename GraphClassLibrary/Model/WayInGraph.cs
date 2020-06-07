
namespace GraphClassLibrary.Model
{
    public class WayInGraph
    {
        public decimal [] MinWayWeights { get; set; }
        public decimal MaxWayLength { get; set; }
        public WayInGraph(int size, decimal maxWayLength)
        {
            MaxWayLength = maxWayLength;
            MinWayWeights = new decimal[size];
            for (int i = 1; i < size; i++)
            {
                MinWayWeights[i] = maxWayLength;
            }
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
