namespace MartianRobots.Tests
{
    [TestFixture]
    public class GridTests
    {
        [Test]
        public void IsInsideGrid_ReturnsTrueForValidPositions()
        {
            // Valid coordinates are inside the grid
            var grid = new Grid(5, 3);
            Assert.That(grid.IsInside(0, 0), Is.True);
            Assert.That(grid.IsInside(5, 3), Is.True);
            Assert.That(grid.IsInside(3, 2), Is.True);
        }

        [Test]
        public void IsInsideGrid_ReturnsFalseForInvalidPositions()
        {
            // Coordinates outside grid boundaries are invalid
            var grid = new Grid(5, 3);
            Assert.That(grid.IsInside(-1, 0), Is.False);
            Assert.That(grid.IsInside(6, 3), Is.False);
            Assert.That(grid.IsInside(0, 4), Is.False);
        }
    }
}
