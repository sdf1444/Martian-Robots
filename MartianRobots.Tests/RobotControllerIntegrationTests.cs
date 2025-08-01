namespace MartianRobots.Tests
{
    [TestFixture]
    public class RobotControllerIntegrationTests
    {
        [Test]
        public void SampleInput_ProducesExpectedOutput()
        {
            // Processes sample input and verifies exact output
            string input =
                "5 3\n" +
                "1 1 E\n" +
                "RFRFRFRF\n" +
                "3 2 N\n" +
                "FRRFLLFFRRFLL\n" +
                "0 3 W\n" +
                "LLFFFLFLFL\n";

            string expectedOutput =
                "1 1 E\n" +
                "3 3 N LOST\n" +
                "2 3 S\n";

            var inputReader = new StringReader(input);
            var outputWriter = new StringWriter();

            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);

            new RobotController().ProcessInput();

            Assert.That(outputWriter.ToString().Replace("\r\n", "\n"), Is.EqualTo(expectedOutput));
        }

        [Test]
        public void LostRobotLeavesScent_PreventsNextRobotLoss()
        {
            // First robot lost and leaves scent, second robot avoids loss
            string input =
                "5 3\n" +
                "5 3 N\n" +
                "F\n" +
                "5 3 N\n" +
                "F\n";

            string expectedOutput =
                "5 3 N LOST\n" +
                "5 3 N\n";

            var inputReader = new StringReader(input);
            var outputWriter = new StringWriter();

            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);

            new RobotController().ProcessInput();

            Assert.That(outputWriter.ToString().Replace("\r\n", "\n"), Is.EqualTo(expectedOutput));
        }

        [Test]
        public void MultipleRobots_SequentialExecution()
        {
            // Input simulates three robots; two get lost, one prevented by scent
            string input =
                "5 3\n" +
                "0 0 N\n" +
                "FFFFF\n" +    // Robot 1 lost moving north off grid
                "5 0 E\n" +
                "F\n" +       // Robot 2 lost moving east off grid
                "5 0 E\n" +
                "F\n\n";      // Robot 3 blocked by scent from getting lost

            string expectedOutput =
                "0 3 N LOST\n" +
                "5 0 E LOST\n" +
                "5 0 E\n";

            Console.SetIn(new StringReader(input));
            var outputWriter = new StringWriter();
            Console.SetOut(outputWriter);

            var controller = new RobotController();
            controller.ProcessInput();

            var actualOutput = outputWriter.ToString().Replace("\r\n", "\n").Trim();
            var expected = expectedOutput.Trim();

            Assert.That(actualOutput, Is.EqualTo(expected));
        }

        [Test]
        public void RobotIgnoringForwardCommandDueToScent_DoesNotChangePosition()
        {
            // Robot facing loss ignores forward command because of scent
            string input =
                "2 2\n" +
                "2 2 N\n" +
                "F\n" +
                "2 2 N\n" +
                "F\n";

            string expectedOutput =
                "2 2 N LOST\n" +
                "2 2 N\n";

            var inputReader = new StringReader(input);
            var outputWriter = new StringWriter();

            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);

            new RobotController().ProcessInput();

            Assert.That(outputWriter.ToString().Replace("\r\n", "\n"), Is.EqualTo(expectedOutput));
        }
    }
}
