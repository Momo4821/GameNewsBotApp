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
                {

                    builder.AddConsole();
                });

                _logger = loggerfactory.CreateLogger<Discord_Logger_service>();




            }

            public void Log_information(string message, EventId eventinfo)
            {

                _logger.LogInformation(eventinfo, message);


            }


            public void Log_Error(string message)
            {

                _logger.LogError(message);
            }


            public void Log_Critical(string message)
            {
                _logger.LogCritical(message);



            }


            public void Log_Warning(string message)

            {


                _logger.LogWarning(message);
            }


        }

    }







}
