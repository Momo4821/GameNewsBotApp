using System;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Configuration;
using Serilog.Settings.Configuration;
namespace GameNewsBotApp.Logging
{
    public class Logger
    {
        
        
        public static void configurelogger()
        {

           Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        
     
         
            
            /*Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
                .WriteTo
                .File("log.json", outputTemplate:"{Timestamp}, {message}, {member}, [{Level}] " ,fileSizeLimitBytes:null,rollingInterval: RollingInterval.Day, 
                    restrictedToMinimumLevel:LogEventLevel.Debug)
                .CreateLogger();*/
            
        }
        
        
        
         public static void configure_logger_Error()
         {
             
             
             
         }
        
     
        
    }
    
    
    
    
}