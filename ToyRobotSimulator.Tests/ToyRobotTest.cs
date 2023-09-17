using FluentAssertions;
using ToyRobotSimulator.Interfaces;
using ToyRobotSimulator.Models;
using ToyRobotSimulator.Services;
using static ToyRobotSimulator.Enums;

namespace ToyRobotSimulator.Tests
{
    public class ToyRobotTest
    {
        private readonly ITableService _tableService = new TableService();

        [Fact]
        public void Move_WhenRobotMoveOnWest_MovesBackwardOnX()
        {
            ToyRobot robot = new ToyRobot(_tableService);
            robot.Place(2, 3, Enums.ForwardDirectionClockWise.WEST);
            robot.Move();
            robot.X.Should().Be(1);
            robot.Y.Should().Be(3);
            robot.Forward.Should().Be(Enums.ForwardDirectionClockWise.WEST);
        }
        [Fact]
        public void Move_WhenRobotMoveOnNorth_MovesForwardOnY()
        {
            ToyRobot robot = new ToyRobot(_tableService);
            robot.Place(2, 3, Enums.ForwardDirectionClockWise.NORTH);
            robot.Move();
            robot.X.Should().Be(2);
            robot.Y.Should().Be(4);
            robot.Forward.Should().Be(Enums.ForwardDirectionClockWise.NORTH);
        }
        [Fact]
        public void Move_WhenRobotMoveOnSouth_MovesBackwardOnY()
        {
            ToyRobot robot = new ToyRobot(_tableService);
            robot.Place(2, 3, Enums.ForwardDirectionClockWise.SOUTH);
            robot.Move();
            robot.X.Should().Be(2);
            robot.Y.Should().Be(2);
            robot.Forward.Should().Be(Enums.ForwardDirectionClockWise.SOUTH);
        }
        [Fact]
        public void Move_WhenRobotMoveOnEast_MovesForwardOnX()
        {
            ToyRobot robot = new ToyRobot(_tableService);
            robot.Place(2, 3, Enums.ForwardDirectionClockWise.EAST);
            robot.Move();
            robot.X.Should().Be(3);
            robot.Y.Should().Be(3);
            robot.Forward.Should().Be(Enums.ForwardDirectionClockWise.EAST);
        }
        [Fact]
        public void Move_WhenRobotMoveOutOfTable_StopAtTableBoundary()
        {
            ToyRobot robot = new ToyRobot(_tableService);
            robot.Place(4, 4, Enums.ForwardDirectionClockWise.EAST);
            robot.Move();
            robot.Move();
            robot.X.Should().Be(5);
            robot.Y.Should().Be(4);
            robot.TurnLeft();
            robot.Move();
            robot.Move();
            robot.X.Should().Be(5);
            robot.Y.Should().Be(5);
        }
        [Fact]
        public void Move_WhenRobotMoveToInvalidDirection_ThrowsArgumentException()
        {
            ToyRobot robot = new ToyRobot(_tableService);
            robot.Place(4, 4, (ForwardDirectionClockWise)999);
            Action moveAction = () => robot.Move();
            moveAction.Should().Throw<ArgumentException>().WithMessage(Constants.ExceptionMessage.InvalidForwardMessage);
        }
        [Fact]
        public void Place_WhenRobotPlacedOnTable_ReturnCorrectPosition()
        {
            ToyRobot robot = new ToyRobot(_tableService);
            robot.Place(2, 3, Enums.ForwardDirectionClockWise.EAST);
            robot.X.Should().Be(2);
            robot.Y.Should().Be(3);
            robot.Forward.Should().Be(Enums.ForwardDirectionClockWise.EAST);
        }

        [Fact]
        public void TurnLeft_WhenRobotTurnAround_ForwardShouldBeEqual()
        {
            ToyRobot robot = new ToyRobot(_tableService);
            robot.Place(2, 3, Enums.ForwardDirectionClockWise.EAST);
            robot.TurnLeft();
            robot.Forward.Should().Be(Enums.ForwardDirectionClockWise.NORTH);
            robot.TurnLeft();
            robot.Forward.Should().Be(Enums.ForwardDirectionClockWise.WEST);
            robot.TurnLeft();
            robot.Forward.Should().Be(Enums.ForwardDirectionClockWise.SOUTH);
            robot.TurnLeft();
            robot.Forward.Should().Be(Enums.ForwardDirectionClockWise.EAST);
            robot.X.Should().Be(2);
            robot.Y.Should().Be(3);
        }
        [Fact]
        public void TurnRight_WhenRobotTurnAround_ForwardShouldBeEqual()
        {
            ToyRobot robot = new ToyRobot(_tableService);
            robot.Place(2, 3, Enums.ForwardDirectionClockWise.EAST);
            robot.TurnRight();
            robot.Forward.Should().Be(Enums.ForwardDirectionClockWise.SOUTH);
            robot.TurnRight();
            robot.Forward.Should().Be(Enums.ForwardDirectionClockWise.WEST);
            robot.TurnRight();
            robot.Forward.Should().Be(Enums.ForwardDirectionClockWise.NORTH);
            robot.TurnRight();
            robot.Forward.Should().Be(Enums.ForwardDirectionClockWise.EAST);
            robot.X.Should().Be(2);
            robot.Y.Should().Be(3);
        }
        [Fact]
        public void Report_WhenRobotPlacedOnTable_ShouldReportPosition()
        {
            ToyRobot robot = new ToyRobot(_tableService);
            robot.Place(2, 3, Enums.ForwardDirectionClockWise.WEST);
            string reportPosition = robot.Report();
            reportPosition.Should().Be("2,3,WEST");
        }
        [Fact]
        public void Report_WhenRobotPlacedOutOfTable_RobotNotPlaced()
        {
            ToyRobot robot = new ToyRobot(_tableService);
            bool isPlaced = robot.Place(6, 6, Enums.ForwardDirectionClockWise.WEST);
            string reportPosition = robot.Report();
            isPlaced.Should().BeFalse();
            reportPosition.Should().Be(Constants.ConsoleFeedbackMessage.ToyRobotNotPlaced);
        }
    }
}
