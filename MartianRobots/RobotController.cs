using MartianRobots.Commands;
using MartianRobots.Models;

namespace MartianRobots
{
    /// <summary>
    /// Orchestrates parsing input, executing robot instructions, and tracking scents.
    /// </summary>
    public class RobotController
    {
        private Grid grid;
        private readonly HashSet<(int x, int y)> scentPositions = new();

        /// <summary>
        /// Reads input, processes robots sequentially, and outputs results.
        /// </summary>
        public void ProcessInput()
        {
            // Read grid upper-right coordinates
            var gridCoords = Console.ReadLine()?.Split(' ');
            if (gridCoords == null || gridCoords.Length != 2) return;

            int maxX = int.Parse(gridCoords[0]);
            int maxY = int.Parse(gridCoords[1]);
            grid = new Grid(maxX, maxY);

            string? line;
            while ((line = Console.ReadLine()) != null && line != string.Empty)
            {
                // Parse robot initial position
                var parts = line.Split(' ');
                if (parts.Length != 3) break;

                int x = int.Parse(parts[0]);
                int y = int.Parse(parts[1]);
                Direction direction = Enum.Parse<Direction>(parts[2]);

                var robot = new Robot(x, y, direction);

                // Read instruction string
                var instructions = Console.ReadLine();
                if (instructions == null) break;

                ExecuteInstructions(robot, instructions);

                // Output result
                Console.WriteLine($"{robot.X} {robot.Y} {robot.Direction}{(robot.IsLost ? " LOST" : "")}");
            }
        }

        private void ExecuteInstructions(Robot robot, string instructions)
        {
            var commandsMap = new Dictionary<char, ICommand>
            {
                ['L'] = new LeftCommand(),
                ['R'] = new RightCommand(),
                ['F'] = new ForwardCommand()
            };

            foreach (var c in instructions)
            {
                if (commandsMap.TryGetValue(c, out var command))
                {
                    command.Execute(robot, grid, scentPositions);
                    if (robot.IsLost)
                        break;
                }
            }
        }
    }
}