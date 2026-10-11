using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace GameNewsBotApp.Logging
{
    public class LoggingData
    {
        private static LoggingLevelSwitch loggingLevelSwitch;
        public static LoggingData LoggingDataInstance { get; } = new LoggingData();

        private LoggingData ()
        {
           
            loggingLevelSwitch = new LoggingLevelSwitch();
            
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(loggingLevelSwitch)
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }
     
        public static void Setloglevelinformation()
        {
            loggingLevelSwitch.MinimumLevel = LogEventLevel.Information;
        }
        
        
        public static void Setlogleveldebug()
        {
            loggingLevelSwitch.MinimumLevel = LogEventLevel.Debug;
        }
        
        
        
        public static LogEventLevel GetLogLevel()
        {
            
            return loggingLevelSwitch.MinimumLevel;
            
            
        }
        
        
    }
        
}