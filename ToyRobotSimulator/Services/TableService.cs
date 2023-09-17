using ToyRobotSimulator.Interfaces;
using static ToyRobotSimulator.Constants;

namespace ToyRobotSimulator.Services
{
    public class TableService : ITableService
    {
        public bool IsOnTable(int x, int y)
        {
            return x >= TableBoundary.XLowerBoundary &&
                   x <= TableBoundary.XUpperBoundary &&
                   y >= TableBoundary.YLowerBoundary &&
                   y <= TableBoundary.YUpperBoundary;
        }
    }
}
