using ToyRobotSimulator.Interfaces;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Services
{
    public class ToyRobotService : IToyRobotService
    {
        private readonly ICommandService _commandService;
        private readonly ToyRobot _robot;
        public ToyRobotService(ICommandService commandService,
            ToyRobot robot)
        {
            _commandService = commandService;
            _robot = robot;
        }
        public bool Start(string filepath)
        {
            List<string> rawCommands = File.ReadAllLines(filepath).ToList();

            var validCommands = _commandService.GetValidCommandsAfterPlace(rawCommands).Where(x => _commandService.IsCommandValid(x)).ToList();
            if (!validCommands.Any())
            {
                Console.WriteLine(Constants.ConsoleFeedbackMessage.FileHasNoValidCommand);
                return false;
            }

            foreach (var command in validCommands)
            {
                ProcessCommands(command);
            }

            return true;
        }

        public bool ProcessCommands(string command)
        {
            switch (command)
            {
                case var cmd when _commandService.IsValidPlaceCommand(cmd):
                    var data = _commandService.GetPlacePosition(cmd);
                    _robot.Place(data!.X, data.Y, data.Forward);
                    break;
                case Constants.CommandList.LeftCommand:
                    _robot.TurnLeft();
                    break;
                case Constants.CommandList.RightCommand:
                    _robot.TurnRight();
                    break;
                case Constants.CommandList.MoveCommand:
                    _robot.Move();
                    break;
                case Constants.CommandList.ReportCommand:
                    _robot.Report();
                    break;
                default:
                    throw new ArgumentException(Constants.ExceptionMessage.InvalidCommandMessage);
            }

            return true;
        }
    }
}
