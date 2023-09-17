using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ToyRobotSimulator.Interfaces;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Tests
{
    public class StartupTest
    {
        [Fact]
        public void ConfigureServices_WhenStartUp_ShouldRegisterExpectedServices()
        {
            var serviceProvider = Startup.ConfigureServices();

            var commandService = serviceProvider.GetService<ICommandService>();
            var toyRobot = serviceProvider.GetService<ToyRobot>();
            var tableService = serviceProvider.GetService<ITableService>();

            commandService.Should().NotBeNull();
            toyRobot.Should().NotBeNull();
            tableService.Should().NotBeNull();
        }

        [Fact]
        public void BuildConfiguration_WhenConfigurationIsInvalid_ShouldThrowInvalidOperationException()
        {
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(c => c["CommandsDataLocation:DirectoryName"]).Returns((string?)null);
            mockConfiguration.Setup(c => c["CommandsDataLocation:FileName"]).Returns((string?)null);

            Action act = () => Startup.ValidateConfiguration(mockConfiguration.Object);

            act.Should().Throw<InvalidOperationException>()
               .WithMessage(Constants.ConsoleFeedbackMessage.MissingInputCommandFile);
        }
    }
}
