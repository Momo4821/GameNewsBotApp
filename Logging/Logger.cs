using System;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;

namespace GameNewsBotApp.Logging
{
    public class Logger
    {
        public static void configurelogger()

        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                .WriteTo
                .File("log.txt", outputTemplate:"{Timestamp}, {message}, {member}, [{Level}] " ,rollingInterval: RollingInterval.Day, 
                    restrictedToMinimumLevel:LogEventLevel.Debug)
                .CreateLogger();
            
        }
        
        
        
         public static void configure_logger_Error()
         {
             
             
             
         }
        
     
        
    }
    
    
    
    
}