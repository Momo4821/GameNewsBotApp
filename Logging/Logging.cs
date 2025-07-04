using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;
using log4net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.Reflection;

namespace GameNewsBotApp.Logging
{
    internal class Logging
    {
        public class Discord_Logger_service
        {
            private readonly ILogger _logger;
            public Discord_Logger_service()
            {
                var loggerfactory = LoggerFactory.Create(builder =>
                {   builder.AddConsole();
                    builder.SetMinimumLevel(LogLevel.Information);
                    builder.AddFilter("Information", LogLevel.Information);
                    builder.AddFilter("Debug", LogLevel.Debug);
                    builder.AddFilter("Critcal", LogLevel.Critical);
                    builder.AddFilter("Warning", LogLevel.Warning);
                    builder.AddFilter("Error", LogLevel.Error);

                });

                _logger = loggerfactory.CreateLogger<Discord_Logger_service>();




            }
            
            

            public void Log_information(string message, EventId eventinfo)
            {
                eventinfo = new EventId(10,"Starting");
                _logger.LogInformation(eventinfo, message);


            }


            public void Log_Error(string message, EventId eventinfo)
            {
                eventinfo = new EventId(40,"Error");
                _logger.LogError(message);
            }


            public void Log_Critical(string message, EventId eventinfo)
            {
                
                eventinfo = new EventId(50,"Critical");
                _logger.LogCritical(message);



            }


            public void Log_Warning(string message, EventId eventinfo)

            {
                eventinfo = new EventId(8,"Warning");

                _logger.LogWarning(message);
            }

            public void Log_Debug(string message, EventId eventinfo)
            {
                eventinfo = new EventId(5,"Debug");
                _logger.LogDebug(message,eventinfo);
                
                
            }


        }

    }







}
