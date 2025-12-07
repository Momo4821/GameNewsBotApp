using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using GameNewsBotApp.Commands;
using GameNewsBotApp.config;
//using GameNewsBotApp.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;
using  GameNewsBotApp.Logging;
using Serilog;
using GameNewsBotApp.Logging;
using GameNewsBotApp.Slash_Commands;

namespace GameNewsBotApp
{


    internal class Program
    {
        
        
        private static DiscordClient Client { get; set; }


        private static CommandsNextExtension commands { get; set; }

        
        static async Task Main(string[] args)
        {
           


            var Tokenprovider = new Get_Token();
            var token = Tokenprovider?.token;
            var todelete = new Get_Token().delete;
            Environment.SetEnvironmentVariable("BOT_TOKEN", "Token"); //Bot Token set for security
            if (string.IsNullOrEmpty(token))
            {

          

                return; 

            }
            
            var discordconifig = new DiscordConfiguration()
            {

                Intents = DiscordIntents.All,
                Token = token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
              //  MinimumLogLevel = LogLevel.Information,
               // LogTimestampFormat = "yyyy-MM-dd HH:mm:ss",
                MessageCacheSize = 1000,
              
            };
            Client = new DiscordClient(discordconifig);
            Logger.configurelogger();
            Log.Logger.Information("Bot is starting up at {Time}", DateTime.Now.ToString(")u"));

         //   Client.Ready += Client_Ready;
            
            //setup commands
            var Discord_Bot_Commands = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { "!" },
                CaseSensitive = false,
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false,
                DmHelp = true,
                
            };

            commands = Client.UseCommandsNext(Discord_Bot_Commands);
            //Basic Commands
            commands.RegisterCommands<Basic_Commands.Ping_command>();
            commands.RegisterCommands<Basic_Commands.Greet_Command>();
            
        
            //Admin Commnands
            commands.RegisterCommands<Administrator_Commands.Kick_Command>();
            commands.RegisterCommands<Administrator_Commands.Kick_Rules>();
            commands.RegisterCommands<Administrator_Commands.Ban_Command>();
            commands.RegisterCommands<Administrator_Commands._timeout_Command>();
            
            //News Commands
            commands.RegisterCommands<News_Command.TF2_command>();
            commands.RegisterCommands<News_Command.Marvel_rivals>();
            
          
          //log command
          commands.RegisterCommands<Administrator_Commands.Unban_Command>();
          
            
          
          
            //Slash Comands -db
            
            //commands to be added later
            
            
            
            
            
            //test Emb
            /*commands.RegisterCommands<HelpCommandButton.InteractionComponents>();*/
           

            await Client.ConnectAsync(); // Connect the client to Discord
            await Task.Delay(-1);  // Wait indefinitely to keep the application running

        }
        
        
        
        
        /*private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            
          var serilog_config = new LoggerConfiguration();
          serilog_config.
          
            var time_stamp = DateTime.Now.ToString("u"); 
            Log.Logger.Information("server started at ", time_stamp);
            /*Discord_Logger_service.Log_information($"Client is ready and Online", time_stamp);#1#
            return Task.CompletedTask;

        }*/
        
        
        
        
        
    }

}