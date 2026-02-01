using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System.IO;
using System.Numerics;
namespace ExamProject;


internal class Program
{
   
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddSerilog();
        });

        var logger = loggerFactory.CreateLogger<Program>();
        var userManagerLogger = loggerFactory.CreateLogger<UserManager>();
        var menuLogger = loggerFactory.CreateLogger<Menu>();

        // для правильного виводу кирилиці
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        UserManager userManager = new UserManager(userManagerLogger);
        Menu menu = new Menu(userManager, menuLogger);
        logger.LogInformation("Лог пишется в файл и консоль");


        logger.LogInformation("The program is running");
        menu.Run();
        logger.LogInformation("The program is complete");
        



    }
}

