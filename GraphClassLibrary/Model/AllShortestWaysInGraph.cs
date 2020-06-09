

namespace GraphClassLibrary.Model
{
    public class AllShortestWaysInGraph
    {
        public Way[,] AllWays { get; set; }
        public int Size { get; set; }
        public AllShortestWaysInGraph(int size)
        {
            //TODO: check coming data for class ALL_SHORTEST_WAYS_IN_GRAPH.
            Size = size;
            AllWays = new Way[size, size];
        }
        public void AddWay(Way way, int i, int j)
        {
            //TODO: check coming data for class ALL_SHORTEST_WAYS_IN_GRAPH.
            AllWays[i, j] = way;
        }
        public override string ToString()
        {
            var result = "";
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i != j && AllWays[i, j].IsWay)
                    {
                        result += $"\n{AllWays[i, j]}";
                    }
                }
            }
            return result;
        }
    }
}
