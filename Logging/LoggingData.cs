using System;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using ILogger = Serilog.ILogger;

namespace GameNewsBotApp.Logging
{
    public class LoggingData
    {
        private static LoggingLevelSwitch _loggingLevelSwitch;
        public static LoggingData LoggingDataInstance { get; } = new LoggingData();

        private LoggingData ()
        {
           
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("AppSettings/appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            
            _loggingLevelSwitch = new LoggingLevelSwitch();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
            
            /*Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(loggingLevelSwitch)
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();*/
        }
     
        public static void Setloglevelinformation()
        {
            _loggingLevelSwitch.MinimumLevel = LogEventLevel.Information;
            Log.Information("Log Level Switched To Information");
        }
        
        
        public static void Setlogleveldebug()
        {
            _loggingLevelSwitch.MinimumLevel = LogEventLevel.Debug;
            Log.Information("Log Level Switched To Debug");
        }
        
        
        
        public static LogEventLevel GetLogLevel()
        {
            Log.Information("Current Log Level: {CurrentLogLevel}", _loggingLevelSwitch.MinimumLevel);
            return _loggingLevelSwitch.MinimumLevel;
            
            
        }
        
        
      
        
    }
        
}