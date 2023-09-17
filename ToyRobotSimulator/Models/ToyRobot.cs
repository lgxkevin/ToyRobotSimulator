using ToyRobotSimulator.Interfaces;
using static ToyRobotSimulator.Enums;

namespace ToyRobotSimulator.Models
{
    public class ToyRobot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public ForwardDirectionClockWise Forward { get; private set; }
        private bool IsPlaced { get; set; }

        private const int MoveUnit = 1;
        private readonly ITableService _tableService;

        public ToyRobot(ITableService tableService)
        {
            _tableService = tableService;
        }
        private T PerformMovementCheck<T>(Func<T> moveAction, T failedResult)
        {
            return !IsPlaced ? failedResult : moveAction();
        }

        public bool Move()
        {
            return PerformMovementCheck(() => {
                int newX = X, newY = Y;

                switch (Forward)
                {
                    case ForwardDirectionClockWise.NORTH:
                        newY += MoveUnit;
                        break;
                    case ForwardDirectionClockWise.SOUTH:
                        newY -= MoveUnit;
                        break;
                    case ForwardDirectionClockWise.WEST:
                        newX -= MoveUnit;
                        break;
                    case ForwardDirectionClockWise.EAST:
                        newX += MoveUnit;
                        break;
                    default:
                        throw new ArgumentException(Constants.ExceptionMessage.InvalidForwardMessage);
                }

                if (!_tableService.IsOnTable(newX, newY)) return false;
                X = newX;
                Y = newY;

                return true;
            }, false);
        }

        public bool Place(int newX, int newY, ForwardDirectionClockWise forward)
        {
            if (!_tableService.IsOnTable(newX, newY)) return false;
            X = newX;
            Y = newY;
            Forward = forward;
            IsPlaced = true;
            return true;
        }

        public bool TurnLeft()
        {
            return PerformMovementCheck(() => {
                int newForward = Convert.ToInt32(Forward) - 1;
                if (newForward < Convert.ToInt32(ForwardDirectionClockWise.NORTH))
                {
                    Forward = ForwardDirectionClockWise.WEST;
                }
                else
                {
                    Forward = (ForwardDirectionClockWise)newForward;
                }

                return true;
            }, false);
        }

        public bool TurnRight()
        {
            return PerformMovementCheck(() => {
                int newForward = Convert.ToInt32(Forward) + 1;
                if (newForward > Convert.ToInt32(ForwardDirectionClockWise.WEST))
                {
                    Forward = ForwardDirectionClockWise.NORTH;
                }
                else
                {
                    Forward = (ForwardDirectionClockWise)newForward;
                }

                return true;
            }, false);
        }

        public string Report()
        {
            return PerformMovementCheck(() => {
                string result = $"{X},{Y},{Forward}";
                Console.WriteLine(result);
                return $"{X},{Y},{Forward}";
            }, Constants.ConsoleFeedbackMessage.ToyRobotNotPlaced);
        }
    }
}
