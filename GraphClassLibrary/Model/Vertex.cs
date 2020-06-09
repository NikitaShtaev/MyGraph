
namespace GraphClassLibrary
{
    public class Vertex
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int CopyNumber { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Vertex(int number, string name)
        {
            //TODO: check coming data for class (VERTEX).
            Number = number;
            CopyNumber = number;
            Name = name;
        }
        public Vertex(int number)
        {
            //TODO: check coming data for class (VERTEX).
            Number = number;
            CopyNumber = number;
            Name = number.ToString();
        }
        public static bool operator ==(Vertex v1, Vertex v2) => v1.Number == v2.Number;
        public static bool operator !=(Vertex v1, Vertex v2) => !(v1.Number == v2.Number);
        public override string ToString()
        {
            return $"#{CopyNumber}:{Name}";
        }

        public override bool Equals(object obj)
        {
            return obj is Vertex vertex &&
                   Number == vertex.Number;
        }

        public override int GetHashCode()
        {
            return 187193536 + Number.GetHashCode();
        }
    }
}
