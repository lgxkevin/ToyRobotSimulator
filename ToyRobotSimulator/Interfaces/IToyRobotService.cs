namespace ToyRobotSimulator.Interfaces
{
    public interface IToyRobotService
    {
        bool Start(string filepath);
        bool ProcessCommands(string command);
    }
}
