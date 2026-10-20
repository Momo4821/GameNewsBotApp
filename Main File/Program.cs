using DSharpPlus;
using DSharpPlus.CommandsNext;
using GameNewsBotApp.Commands;
using GameNewsBotApp.config;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using GameNewsBotApp.CreateChannels;
using GameNewsBotApp.Logging;
using GameNewsBotApp.SQLConnection;
using Serilog;



namespace GameNewsBotApp
{


    internal class Program
    {
        private static DiscordClient _client;
        private static DiscordConfiguration _discordconifig;
        private static CommandsNextExtension Commands { get; set; }
        private  static CreateChannelsService _createChannels;
        private static LoggingData _loggingData;
        private static DiscordDatabase _discordDatabase;
      
       static async Task Main(string[] args)
        {
         
            _loggingData = LoggingData.LoggingDataInstance;
            _discordDatabase = DiscordDatabase.DiscordDatabaseInstance;
            var loggerfactory = new LoggerFactory().AddSerilog();
            _createChannels = CreateChannelsService.CreateChannelsServiceInstance;
            var Tokenprovider = new Get_Token();
            var token = Tokenprovider.token;
            Environment.SetEnvironmentVariable("BOT_TOKEN", "Token"); //Bot Token set for security
            if (string.IsNullOrEmpty(token))
            {
                return; 
            }
            
            _discordconifig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MessageCacheSize = 1000,   
                MinimumLogLevel = LogLevel.Debug,
                LoggerFactory = loggerfactory
            };
            
            _client = new DiscordClient(_discordconifig);
            
          //  prefix = new string[] {"!"};
            var discordBotCommands = new CommandsNextConfiguration()
            {
                
                StringPrefixes = new[] { "!","/" },
                CaseSensitive = false,
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false,
                DmHelp = true,
            };
            
            Commands = _client.UseCommandsNext(discordBotCommands);
            
            //Basic Commands
            Commands.RegisterCommands<BasicCommands.PingCommand>();
            Commands.RegisterCommands<BasicCommands.Greet_Command>();
            Commands.RegisterCommands<BasicCommands.BotInfo>();
            
            
            
            //News Commands
            Commands.RegisterCommands<News_Command.Tf2Command>();
            Commands.RegisterCommands<News_Command.MarvelRivals>();
            Commands.RegisterCommands<News_Command.RiskOfRain>();
            Commands.RegisterCommands<News_Command.PalWorld>();
            
          
            //Administrator Commands
            Commands.RegisterCommands<AdministratorCommands.KickCommand>();
            Commands.RegisterCommands<AdministratorCommands.BanCommand>();
            Commands.RegisterCommands<AdministratorCommands.TimeoutCommand>();
            Commands.RegisterCommands<AdministratorCommands.SetLogLevelDebug>();
            Commands.RegisterCommands<AdministratorCommands.SetLogLevelInformation>();
            
         
            await _client.ConnectAsync();
                
            _client.GuildAvailable += async (sender, eventArgs) =>
            {
              Log.Debug("GuildAvaialble Event Hanlder Invoked For Guild {GuildName}", eventArgs.Guild.Name);
          
                    
            };
            
            /*_client.GuildCreated += async (sender, eventArgs) =>
            {
               Log.Debug("GuildCreated Event Handler");
                
       
     
            };*/
            
            _client.ChannelDeleted += async (sender, eventArgs) =>
            { 
                
            Log.Warning("ChannelDeleted Event Handler: User: {DiscordMemeber} has deleted channels: {Channels}", 
                eventArgs.Guild.CurrentMember, eventArgs.Channel);

         
                await _createChannels.CreateChannelAsync(eventArgs.Guild);
                await _createChannels.CreateLogChnanel(eventArgs.Guild);
                _= _createChannels.StoreChannelInfomrationAsync(eventArgs.Guild);
            
            
            };
            /*_client.ChannelCreated += async (sender, eventArgs) =>
            {
                
                Log.Debug("ChannelCreated Event Handler: {DiscordMemeber}");
                
                
           
            };*/
            
            _client.ChannelUpdated += async (sender, eventArgs) =>
            {   
             
                Log.Debug("ChannelUpdated Event Handler: {DiscordUser");
                
              
            };
            
            
            Log.Information("Bot is running in guild {GuildName}", _client.Guilds.Keys.ToString());
            await Task.Delay(-1);  // Wait indefinitely to keep the application running
            
          
    
    }
    }
    }