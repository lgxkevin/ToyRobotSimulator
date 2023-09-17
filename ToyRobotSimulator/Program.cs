using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToyRobotSimulator;
using ToyRobotSimulator.Interfaces;

IServiceProvider services = Startup.ConfigureServices();
IConfiguration configuration = Startup.BuildConfiguration();

string filepath = Path.Combine(Directory.GetCurrentDirectory(), configuration["CommandsDataLocation:DirectoryName"]!, configuration["CommandsDataLocation:FileName"]!);

services.GetService<IToyRobotService>()!.Start(filepath);