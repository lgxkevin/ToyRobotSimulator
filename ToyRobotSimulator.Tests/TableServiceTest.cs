using FluentAssertions;
using ToyRobotSimulator.Interfaces;
using ToyRobotSimulator.Services;

namespace ToyRobotSimulator.Tests
{
    public class TableServiceTest
    {
        private readonly ITableService _tableService = new TableService();

        [Fact]
        public void IsOnTable_WhenPositivePositionOutOfTable_ShouldBeFalse()
        {
            bool result = _tableService.IsOnTable(6, 6);
            result.Should().BeFalse();
        }
        [Fact]
        public void IsOnTable_WhenNegativePositionOutOfTable_ShouldBeFalse()
        {
            bool result = _tableService.IsOnTable(-1, -3);
            result.Should().BeFalse();
        }
    }
}