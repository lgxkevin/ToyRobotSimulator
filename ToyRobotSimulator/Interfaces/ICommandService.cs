using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Interfaces
{
    public interface ICommandService
    {
        List<string> GetValidCommandsAfterPlace(List<string> commands);
        PlaceCommandModel? GetPlacePosition(string command);
        bool IsCommandValid(string command);
        bool IsValidPlaceCommand(string command);
    }
}
