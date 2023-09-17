using FluentAssertions;
using ToyRobotSimulator.Interfaces;
using ToyRobotSimulator.Models;
using ToyRobotSimulator.Services;

namespace ToyRobotSimulator.Tests
{
    public class ToyRobotServiceTest
    {
        private readonly ICommandService _commandService = new CommandService();
        private readonly ITableService _tableService = new TableService();

        [Fact]
        public void Start_WhenRobotReceivesCommand_ShouldBeInPosition()
        {
            ToyRobot robot = new ToyRobot(_tableService);
            IToyRobotService toyRobotService = new ToyRobotService(_commandService, robot);
            string testingCommandPath = Path.Combine(Directory.GetCurrentDirectory(), "ToyRobotCommandTest.txt");

            bool result = toyRobotService.Start(testingCommandPath);

            robot.Report().Should().Be("4,3,EAST");
            result.Should().BeTrue();
        }
        
        [Fact]
        public void Start_WhenRobotReceivesAllInvalidCommand_ShouldBeFalse()
        {
            // TODO
            ToyRobot robot = new ToyRobot(_tableService);
            IToyRobotService toyRobotService = new ToyRobotService(_commandService, robot);
            string testingCommandPath = Path.Combine(Directory.GetCurrentDirectory(), "ToyRobotNoValidCommandTest.txt");
            bool result = toyRobotService.Start(testingCommandPath);
            result.Should().BeFalse();
        }

        [Fact]
        public void ProcessCommands_WhenProcessInvalidCommand_ThrowsArgumentException()
        {
            ToyRobot robot = new ToyRobot(_tableService);
            IToyRobotService toyRobotService = new ToyRobotService(_commandService, robot);
            Action moveAction = () => toyRobotService.ProcessCommands("Test");
            moveAction.Should().Throw<ArgumentException>().WithMessage(Constants.ExceptionMessage.InvalidCommandMessage);
        }
    }
}
