using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace GameNewsBotApp.Logging
{
    public class LoggingData
    {
        private readonly LoggingLevelSwitch _levelSwitch;
        private LoggingData()
        {
      
            
      Log.Logger = new LoggerConfiguration()
          .MinimumLevel.Debug()
          .WriteTo.File("Logs/Logs.Txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
          .MinimumLevel.Information()
          .MinimumLevel.ControlledBy(_levelSwitch)
          .CreateLogger();
      
      
      
      
  }
        
        
        public void SetLogLevelInformation()
        {
            _levelSwitch.MinimumLevel = LogEventLevel.Information;
            Log.Information("Log Level set to Information.");
        }
        
        
        public void SetLogLevelDebug()
        {
            _levelSwitch.MinimumLevel = LogEventLevel.Debug;
            Log.Debug("Log Level set to Debug.");
        }
        
        
        
        public LogEventLevel GetLogLevel()
        {
            return _levelSwitch.MinimumLevel;
            
        }
}
}