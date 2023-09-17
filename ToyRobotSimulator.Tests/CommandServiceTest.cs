using FluentAssertions;
using ToyRobotSimulator.Interfaces;
using ToyRobotSimulator.Models;
using ToyRobotSimulator.Services;
using static ToyRobotSimulator.Enums;

namespace ToyRobotSimulator.Tests
{
    public class CommandServiceTest
    {
        private readonly ICommandService _commandService = new CommandService();

        [Fact]
        public void IsPlaceCommand_WhenWrongForwardInPlaceCommand_IsNotPlaceCommand()
        {
            string placeCommand = "PLACE 0,0,0 WRRR";
            bool result = _commandService.IsValidPlaceCommand(placeCommand);
            result.Should().BeFalse();
        }
        [Fact]
        public void IsPlaceCommand_WhenLowerCaseInPlaceCommand_IsNotPlaceCommand()
        {
            string placeCommand = "place 0, 0, north";
            bool result = _commandService.IsValidPlaceCommand(placeCommand);
            result.Should().BeFalse();
        }
        [Fact]
        public void IsPlaceCommand_WhenPlaceRobotOutOfTable_IsNotPlaceCommand()
        {
            string placeCommand = "PLACE 6, 6, SOUTH";
            bool result = _commandService.IsValidPlaceCommand(placeCommand);
            result.Should().BeFalse();
        }
        [Fact]
        public void ReadFile_WhenOtherCommandsComeBeforePlace_ShouldIgnoreUntilPlaceCommand()
        {
            List<string> testFileContent = new List<string>
            {
                "RIGHT", "REPORT", "MOVE", "PLACE 2, 1, SOUTH", "MOVE", "REPORT"
            };
            List<string> commands = _commandService.GetValidCommandsAfterPlace(testFileContent);
            List<string> expectedResult = new List<string>
            {
                "PLACE 2, 1, SOUTH", "MOVE", "REPORT"
            };
            commands.Should().Equal(expectedResult);
        }
        [Fact]
        public void GetPlacePosition_WhenRobotPlacedOnTable_ValidPositionShouldBeReturned()
        {
            string placeCommand = "PLACE 2, 3, WEST";
            PlaceCommandModel? result = _commandService.GetPlacePosition(placeCommand);
            result.Should().NotBeNull();
            result!.X.Should().Be(2);
            result.Y.Should().Be(3);
            result.Forward.Should().Be(ForwardDirectionClockWise.WEST);
        }
        [Fact]
        public void GetPlacePosition_WhenRobotPlacedOutOfTable_ShouldReturnNullPosition()
        {
            string placeCommand = "PLACE 6, 10, WEST";
            PlaceCommandModel? result = _commandService.GetPlacePosition(placeCommand);
            result.Should().BeNull();
        }
    }
}
