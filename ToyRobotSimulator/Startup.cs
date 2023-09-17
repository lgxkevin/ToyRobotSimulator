using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ToyRobotSimulator
{
    public class Startup
    {
        public static IServiceProvider ConfigureServices()
        {

            IServiceProvider services = new ServiceCollection()
                                        .AddApplicationService()
                                        .AddToyRobot()
                                        .BuildServiceProvider();
            return services;
        }

        public static IConfiguration BuildConfiguration()
        {
            string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Constants.Environment.Development;
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder = builder.SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{environmentName}.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            ValidateConfiguration(configuration);
            return configuration;
        }

        public static void ValidateConfiguration(IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration["CommandsDataLocation:DirectoryName"]) ||
                    string.IsNullOrEmpty(configuration["CommandsDataLocation:FileName"]))
            {
                throw new InvalidOperationException(Constants.ConsoleFeedbackMessage.MissingInputCommandFile);
            }
        }
    }
}
