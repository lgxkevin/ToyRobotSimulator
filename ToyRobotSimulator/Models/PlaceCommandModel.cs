using static ToyRobotSimulator.Enums;

namespace ToyRobotSimulator.Models
{
    public class PlaceCommandModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ForwardDirectionClockWise Forward { get; set; }
    }
}
