using DSharpPlus;
using DSharpPlus.CommandsNext;
using GameNewsBotApp.Commands;
using GameNewsBotApp.config;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus.EventArgs;
using GameNewsBotApp.CreateChannels;

namespace GameNewsBotApp
{


    internal class Program
    {
        public static DiscordClient Client;
        public static DiscordConfiguration discordconifig;
        public static CommandsNextExtension commands { get; set; }
        
       static async Task Main(string[] args)
        {
           
         
         
            var Tokenprovider = new Get_Token();
            var token = Tokenprovider?.token;
            Environment.SetEnvironmentVariable("BOT_TOKEN", "Token"); //Bot Token set for security
            if (string.IsNullOrEmpty(token))
            {
                return; 
            }
            
            discordconifig = new DiscordConfiguration()
            {

                Intents = DiscordIntents.All,
                Token = token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Information,
               LogTimestampFormat = "yyyy-MM-dd HH:mm:ss",
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
                DmHelp = true,
            };
            

            

            commands = Client.UseCommandsNext(Discord_Bot_Commands);
            
            //Basic Commands
            commands.RegisterCommands<Basic_Commands.Ping_command>();
            commands.RegisterCommands<Basic_Commands.Greet_Command>();
            commands.RegisterCommands<Basic_Commands.BotInfo>();
            
            
            
            //News Commands
            commands.RegisterCommands<News_Command.Tf2Command>();
            commands.RegisterCommands<News_Command.MarvelRivals>();
            commands.RegisterCommands<News_Command.RiskOfRain>();
            commands.RegisterCommands<News_Command.PalWorld>();
            
          
            commands.RegisterCommands<AdministratorCommands.KickCommand>();
            commands.RegisterCommands<AdministratorCommands.BanCommand>();
            commands.RegisterCommands<AdministratorCommands.CreateChannelCommand>();
            //DatbaseCommands
            var services = new CreateChannels.CreateChannels();
        
            await Client.ConnectAsync(); // Connect the client to Discord
   
        
            
      await Task.Delay(-1);  // Wait indefinitely to keep the application running
 
      
        
        
  
    }


    }
    }