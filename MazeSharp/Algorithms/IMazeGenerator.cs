namespace MazeSharp.Algorithms
{
    public interface IMazeGenerator
    {
        Cell CurrentCell { get; }

        void Step();

        bool MazeComplete { get; }
    }
}
