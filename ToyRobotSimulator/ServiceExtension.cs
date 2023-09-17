using Microsoft.Extensions.DependencyInjection;
using ToyRobotSimulator.Interfaces;
using ToyRobotSimulator.Models;
using ToyRobotSimulator.Services;

namespace ToyRobotSimulator
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddSingleton<ICommandService, CommandService>();
            services.AddSingleton<ITableService, TableService>();
            services.AddSingleton<IToyRobotService, ToyRobotService>();
            return services;
        }

        public static IServiceCollection AddToyRobot(this IServiceCollection services)
        {
            services.AddTransient<ToyRobot>();
            return services;
        }
    }
}
