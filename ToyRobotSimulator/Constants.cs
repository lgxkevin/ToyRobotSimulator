namespace ToyRobotSimulator
{
    public class Constants
    {
        public class CommandList
        {
            public const string PlaceCommand = "PLACE";
            public const string MoveCommand = "MOVE";
            public const string LeftCommand = "LEFT";
            public const string RightCommand = "RIGHT";
            public const string ReportCommand = "REPORT";
        }

        public class ForwardList
        {
            public const string North = "NORTH";
            public const string South = "SOUTH";
            public const string West = "WEST";
            public const string East = "EAST";
        }

        public class TableBoundary
        {
            public const int XLowerBoundary = 0;
            public const int XUpperBoundary = 5;
            public const int YLowerBoundary = 0;
            public const int YUpperBoundary = 5;
        }

        public class Environment
        {
            public const string Development = "Development";
            public const string Production = "Production";
        }

        public class ConsoleFeedbackMessage
        {
            public const string MissingInputCommandFile = "Missing ToyRobot command file";
            public const string FileHasNoValidCommand = "No valid command";
            public const string ToyRobotNotPlaced = "Toy Robot hasn't been placed yet";
        }

        public class ExceptionMessage
        {
            public const string InvalidForwardMessage = "Invalid direction";
            public const string InvalidCommandMessage = "Invalid command";
        }
    }
}
