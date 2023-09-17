using System.Text.RegularExpressions;
using ToyRobotSimulator.Interfaces;
using ToyRobotSimulator.Models;
using static ToyRobotSimulator.Constants;
using static ToyRobotSimulator.Enums;

namespace ToyRobotSimulator.Services
{
    public class CommandService : ICommandService
    {
        private readonly string _placeCommandRegex;
        private readonly List<string> _validCommands;

        public CommandService()
        {
            var direction = $"{ForwardList.North}|{ForwardList.South}|{ForwardList.East}|{ForwardList.West}";
            _placeCommandRegex = $@"^{CommandList.PlaceCommand}\s+[{TableBoundary.XLowerBoundary}-{TableBoundary.XUpperBoundary}],\s*[{TableBoundary.YLowerBoundary}-{TableBoundary.YUpperBoundary}],\s*({direction})$";
            _validCommands = new List<string>
            {
                CommandList.LeftCommand,
                CommandList.RightCommand,
                CommandList.MoveCommand,
                CommandList.ReportCommand
            };
        }

        public List<string> GetValidCommandsAfterPlace(List<string> commands)
        {
            List<string> validCommands = new List<string>();
            int startIndex = commands.FindIndex(x => Regex.Match(x, _placeCommandRegex).Success);
            if (startIndex == -1) return validCommands;

            validCommands = commands.Skip(startIndex).ToList();
            return validCommands;
        }

        public PlaceCommandModel? GetPlacePosition(string command)
        {
            const string regexForPullingData = @"PLACE\s+(\d+),\s*(\d+),\s*(NORTH|SOUTH|EAST|WEST)";
            Match match = Regex.Match(command, regexForPullingData);
            if (!match.Success || !IsValidPlaceCommand(command)) return null;

            PlaceCommandModel reCommandModel = new PlaceCommandModel();

            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);
            ForwardDirectionClockWise direction = (ForwardDirectionClockWise)Enum.Parse(typeof(ForwardDirectionClockWise), match.Groups[3].Value, false);
            reCommandModel.X = x;
            reCommandModel.Y = y;
            reCommandModel.Forward = direction;

            return reCommandModel;
        }

        public bool IsCommandValid(string command)
        {
            return Regex.Match(command, _placeCommandRegex).Success || _validCommands.Contains(command);
        }

        public bool IsValidPlaceCommand(string command)
        {
            return Regex.Match(command, _placeCommandRegex).Success;
        }
    }
}
