
namespace GraphClassLibrary
{
    public class Vertex
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsVisited { get; set; }
        public Vertex(int number, string name)
        {
            //TODO: check coming data for class (VERTEX).
            Number = number;
            Name = name;
            IsVisited = false;
        }
        public Vertex(int number)
        {
            //TODO: check coming data for class (VERTEX).
            Number = number;
            Name = number.ToString();
            IsVisited = false;
        }
        public static bool operator ==(Vertex v1, Vertex v2) => v1.Number == v2.Number;
        public static bool operator !=(Vertex v1, Vertex v2) => !(v1.Number == v2.Number);
        public override string ToString()
        {
            return $"No({Number}):{Name}";
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
