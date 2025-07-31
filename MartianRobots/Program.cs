namespace MartianRobots
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    class Program
    {
        static void Main()
        {
            var controller = new RobotController();
            controller.ProcessInput();
        }
    }
}