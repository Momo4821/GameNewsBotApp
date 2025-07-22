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






namespace GameNewsBotApp
{


    internal class Program
    {


        private static DiscordClient Client { get; set; }


        private static CommandsNextExtension commands { get; set; }

        static async Task Main(string[] args)
        {
            var Discord_Logger_service = new Logging.Logging.Discord_Logger_service();


            var Tokenprovider = new Get_Token();
            var token = Tokenprovider?.token;
            var todelete = new Get_Token().delete;
            Environment.SetEnvironmentVariable("BOT_TOKEN", "Token"); //Bot Token set for security
            if (string.IsNullOrEmpty(token))
            {

                Discord_Logger_service.Log_Error("String is Empty",new EventId(1));

                return; 

            }
            
            
          
            
            var discordconifig = new DiscordConfiguration()
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

            Client.Ready += Client_Ready;
            
            //setup commands
            var Discord_Bot_Commands = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { "!" },
                CaseSensitive = false,
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = true,
                DmHelp = true,
                
                
                



            };

            commands = Client.UseCommandsNext(Discord_Bot_Commands);
            //Basic Commands
            commands.RegisterCommands<Basic_Commands.Ping_command>();
            commands.RegisterCommands<Basic_Commands.Greet_Command>();
            commands.RegisterCommands<Basic_Commands.Role_Command>();
            commands.RegisterCommands<Basic_Commands._Invite_Join>();
            //Admin Commnands
            commands.RegisterCommands<Basic_Commands.Kick_Command>();
            commands.RegisterCommands<Basic_Commands.Kick_Rules>();
            commands.RegisterCommands<Basic_Commands.Ban_Command>();
            //News Commands
            commands.RegisterCommands<News_Command.TF2_command>();
            commands.RegisterCommands<News_Command.Marvel_rivals>();
            
           

            await Client.ConnectAsync();
            await Task.Delay(-1);

        }
        
        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {

       
            var Discord_Logger_service = new Logging.Logging.Discord_Logger_service();
            var time_stamp = DateTime.Now.ToString("u");
            /*Discord_Logger_service.Log_information($"Client is ready and Online", time_stamp);*/
            Discord_Logger_service.Log_information("Client is Ready", new EventId(10, "Ready") );
            return Task.CompletedTask;

        }
    }

}