using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeSharp.Algorithms
{
    public class Cell : IEquatable<Cell>
    {
        static Random _rand = new Random();

        public int X { get; }
        public int Y { get; }

        public Cell North { get; set; }
        public Cell South { get; set; }
        public Cell East { get; set; }
        public Cell West { get; set; }

        IEnumerable<Cell> Neighbors
        {
            get
            {
                if (North != null) yield return North;
                if (South != null) yield return South;
                if (East != null) yield return East;
                if (West != null) yield return West;
            }
        }

        public bool HasUnvisitedNeighbors =>
            Neighbors.Any(c => c.Visited == false);

        public Cell RandomNeighbor
        {
            get
            {
                var unvisited = Neighbors.Where(c => c.Visited == false).ToArray();
                var r = _rand.Next(0, unvisited.Length);
                return unvisited[r];
            }
        }

        public bool Visited { get; set; }

        IList<Cell> Links { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
            Links = new List<Cell>();
        }

        public void Link(Cell cell, bool bidi = true)
        {
            if (cell == null) return;

            if (!Linked(cell))
                Links.Add(cell);

            if (bidi)
                cell.Link(this, false);
        }

        public void Unlink(Cell cell, bool bidi = true)
        {
            if (cell == null) return;

            Links.Remove(cell);

            if (bidi)
                cell.Unlink(this, false);
        }

        public bool Linked(Cell cell) =>
            cell != null && Links.Any(c => c.Equals(cell));

        public bool Equals(Cell other) =>
            other != null && other.X == X && other.Y == Y;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as Cell);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash *= 23 + X.GetHashCode();
                hash *= 23 + Y.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }
    }
}
