using System;
using System.Collections.Generic;
using System.Text;

namespace MazeSharp.Algorithms
{
    public class RecursiveBacktracker : IMazeGenerator
    {
        Maze _maze;
        Stack<Cell> _stack = new Stack<Cell>();
        bool _maze_complete;

        public RecursiveBacktracker(Maze maze)
        {
            _maze = maze;
            CurrentCell = _maze[0, 0];
            CurrentCell.Visited = true;
        }

        public Cell CurrentCell { get; private set; }

        public bool MazeComplete
        {
            get
            {
                // Cache for efficiency
                if (_maze_complete) return true;

                if (_maze.HasUnvisitedCells) return false;

                _maze_complete = true;
                return true;
            }
        }

        public void Step()
        {
            if(CurrentCell.HasUnvisitedNeighbors)
            {
                var next = CurrentCell.RandomNeighbor;
                _stack.Push(CurrentCell);
                CurrentCell.Link(next);
                CurrentCell = next;
                CurrentCell.Visited = true;
            }
            else if(_stack.Count > 0)
            {
                CurrentCell = _stack.Pop();
            }
        }
    }
}
