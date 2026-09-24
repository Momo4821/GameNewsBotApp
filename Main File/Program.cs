using DSharpPlus;
using DSharpPlus.CommandsNext;
using GameNewsBotApp.Commands;
using GameNewsBotApp.config;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using GameNewsBotApp.CreateChannels;
using GameNewsBotApp.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using ILogger = Serilog.ILogger;


namespace GameNewsBotApp
{


    internal class Program
    {
        private static DiscordClient Client;
        private static DiscordConfiguration discordconifig;
        private static CommandsNextExtension commands { get; set; }
        private  static CreateChannelsService _createChannels;
        private static ILogger Logger { get; set; }
        
        
       static async Task Main(string[] args)
        {
            
            Logger = Log.Logger;
            _createChannels = CreateChannelsService.CreateChannelsServiceInstance;
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
                MessageCacheSize = 1000,   
                LoggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.AddSerilog(Logger);
                })
             
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
            //DatbaseCommands
            
         
            await Client.ConnectAsync(); // Connect the client to Discord
            
                
            Client.GuildAvailable += async (sender, eventArgs) =>
            {
             
                Logger.Information("GuildAvailable");
                await _createChannels.CreateChannelAsync(eventArgs.Guild);
           
                await _createChannels.StoreChannelInfomrationAsync(eventArgs.Guild);
             
            };
            
            
            Client.GuildCreated += async (sender, eventArgs) =>
            {
               await _createChannels.CreateChannelAsync(eventArgs.Guild);
               Logger.Information($"GuildCreated Event: Channels created for guild: {eventArgs.Guild.Name}, {string.Join(", ", eventArgs.Guild.Channels.Values)}");
        
               await _createChannels.StoreChannelInfomrationAsync(eventArgs.Guild);
               Logger.Information($"GuildCreated Event:Channel information stored for guild: {eventArgs.Guild.Name}, {string.Join(", ", eventArgs.Guild.Channels.Values)}");
     
            };
            
            Client.ChannelDeleted += async (sender, eventArgs) =>
            {
      
                Logger.Warning($"ChannelDeleted Event: {eventArgs.Channel.Name} in guild: {eventArgs.Guild.Name}. Recreating channels Designated for Channels For news.");
                
                await _createChannels.CreateChannelAsync(eventArgs.Guild);
                Logger.Information($"ChannelDeleted Event: Channels recreated {eventArgs.Channel.Name} successfully for guild: {eventArgs.Guild.Name}");
              
           
                };
            
        
             //When a cHannel is deleted, recreate the channels and store the information again
            Client.ChannelCreated += async (sender, eventArgs) =>
            {
                Logger.Information("News Channels Created...Storing Information");
                await _createChannels.StoreChannelInfomrationAsync(eventArgs.Guild);      
                Logger.Information("Channels Stored Information Updated");  
            };

                
                
                
             
            await Task.Delay(-1);  // Wait indefinitely to keep the application running
            Logger.Information("Bot is Running");
    
    }
    }
    }