namespace MartianRobots
{
    /// <summary>
    /// Represents the Mars surface grid boundaries.
    /// </summary>
    public class Grid
    {
        public int MaxX { get; }
        public int MaxY { get; }

        public Grid(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }

        /// <summary>
        /// Checks if given coordinates are inside the grid.
        /// </summary>
        public bool IsInside(int x, int y)
        {
            return x >= 0 && x <= MaxX && y >= 0 && y <= MaxY;
        }
    }
}
