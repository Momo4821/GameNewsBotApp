using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using GameNewsBotApp.Commands;
using GameNewsBotApp.config;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter.Xml;
using  GameNewsBotApp.Logging;
using Serilog;

using GameNewsBotApp.config;
using GameNewsBotApp.Slash_Commands;

namespace GameNewsBotApp
{


    internal class Program
    {
        
        public static DiscordClient Client { get; set; }
        
        
        public static string [] prefix {get;set;}
       // public static string [] slash {get;set;}
       

        public static CommandsNextExtension commands { get; set; }

        
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
            
            
          //  prefix = new string[] {"!"};
            var Discord_Bot_Commands = new CommandsNextConfiguration()
            {
                
                StringPrefixes = new string[] { "!","/" },
                CaseSensitive = false,
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false,
                DmHelp = true

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
            commands.RegisterCommands<Administrator_Commands.Unban_Command>();
            
            //News Commands
            commands.RegisterCommands<News_Command.TF2_command>();
            commands.RegisterCommands<News_Command.Marvel_rivals>();
            
          
          //log command
          commands.RegisterCommands<Administrator_Commands._GetLogs_Command>();
          

          
          //db commands slash
            commands.RegisterCommands<SlashCommands.testcommand>();

            await Client.ConnectAsync(); // Connect the client to Discord
            await Task.Delay(-1);  // Wait indefinitely to keep the application running

        }
        
        
        
        
      
        
        
        
        
    }

}