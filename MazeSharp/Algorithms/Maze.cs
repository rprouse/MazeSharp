using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeSharp.Algorithms
{
    public class Maze
    {
        static Random _rand = new Random();

        public int Rows { get; }
        public int Columns { get; }

        Cell[,] _grid;

        public Maze(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            CreateGrid();
            ConfigureCells();
        }

        public Cell this[int x, int y] => _grid[x, y];

        public int Size => Rows * Columns;

        public IEnumerable<Cell> AllCells
        {
            get
            {
                for (int y = 0; y < Rows; y++)
                {
                    for (int x = 0; x < Columns; x++)
                    {
                        yield return this[x, y];
                    }
                }
            }
        }

        public bool HasUnvisitedCells => AllCells.Any(c => c.Visited == false);

        public Cell RandomCell =>
            this[_rand.Next(0, Columns), _rand.Next(0, Rows)];

        private void CreateGrid()
        {
            _grid = new Cell[Columns, Rows];
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    _grid[x, y] = new Cell(x, y);
                }
            }
        }

        private void ConfigureCells()
        {
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    var cell = this[x, y];
                    if (y > 0) cell.North = this[x, y - 1];
                    if (y < Rows - 1) cell.South = this[x, y + 1];
                    if (x > 0) cell.West = this[x - 1, y];
                    if (x < Columns - 1) cell.East = this[x + 1, y];
                }
            }
        }
    }
}
