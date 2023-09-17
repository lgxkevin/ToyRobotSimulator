using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ToyRobotSimulator.Interfaces;
using ToyRobotSimulator.Models;

namespace ToyRobotSimulator.Tests
{
    public class ServiceExtensionTest
    {
        [Fact]
        public void AddApplicationService_WhenProgramStarts_RegistersExpectedServices()
        {
            var services = new ServiceCollection();
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(c => c.GetSection("Environment").Value).Returns("Development");

            services.AddApplicationService();

            services.Should().Contain(s => s.ServiceType == typeof(ICommandService) && s.Lifetime == ServiceLifetime.Singleton);
            services.Should().Contain(s => s.ServiceType == typeof(ITableService) && s.Lifetime == ServiceLifetime.Singleton);
            services.Should().Contain(s => s.ServiceType == typeof(IToyRobotService) && s.Lifetime == ServiceLifetime.Singleton);
        }

        [Fact]
        public void AddToyRobot_WhenProgramStarts_RegistersToyRobot()
        {
            var services = new ServiceCollection();

            services.AddToyRobot();

            services.Should().Contain(s => s.ServiceType == typeof(ToyRobot) && s.Lifetime == ServiceLifetime.Transient);
        }
    }
}

